<template>
  <div id="map"></div>
</template>

<script>
import mapboxgl from 'mapboxgl';
import mapboxSdk from 'mapboxSdk';

import Service from '@/services/Service';

let map;

export default {
  name: 'Map',
  props: ['cities'],
  data() {
    return {
      //   cities: ['Vilnius', 'Kaunas', 'Utena', 'Klaipėda', 'Palanga'],
      accessToken:
        'pk.eyJ1IjoicmVuZGVydG9tIiwiYSI6ImNraTdyZWlwNzBmYWYycnAybXN1OHJxMHIifQ.rjWk6YchjWs6dmkMdG0MCQ',
      mapCenter: [23.93333, 54.9], // Kaunas
      mapZoom: 5,
      mapMaxBounds: [
        [20.3, 53.6],
        [27.3, 56.6],
      ],
      circleColor: '#BB83FF',
      lineColor: '#F784AD',
      travelDistance: 0,
      travelTime: 0,
    };
  },
  methods: {
    drawPoint(id, coordinates) {
      map.addLayer({
        id: id,
        type: 'circle',
        source: {
          type: 'geojson',
          data: {
            type: 'FeatureCollection',
            features: [
              {
                type: 'Feature',
                properties: {},
                geometry: {
                  type: 'Point',
                  coordinates: coordinates,
                },
              },
            ],
          },
        },
        paint: {
          'circle-radius': 10,
          'circle-color': this.circleColor,
        },
      });
    },

    drawPoints(features) {
      features.forEach((feature) => {
        this.drawPoint(feature.text, feature.center);
      });
    },

    drawLine(id, coordinates) {
      map.addLayer({
        id: id,
        type: 'line',
        source: {
          type: 'geojson',
          data: {
            type: 'Feature',
            properties: {},
            geometry: {
              type: 'LineString',
              coordinates: coordinates,
            },
          },
        },
        layout: {
          'line-join': 'round',
          'line-cap': 'round',
        },
        paint: {
          'line-color': this.lineColor,
          'line-width': 5,
          'line-opacity': 0.75,
        },
      });
    },

    drawRoute(id, start, end) {
      const url =
        'https://api.mapbox.com/directions/v5/mapbox/driving/' +
        start[0] +
        ',' +
        start[1] +
        ';' +
        end[0] +
        ',' +
        end[1] +
        '?steps=true&geometries=geojson&access_token=' +
        this.accessToken;

      return Service.getUrl(url)
        .then((response) => {
          if (response.status === 200) {
            const routes = response.data.routes;
            if (routes && routes.length > 0) {
              const route = routes[0];
              this.travelDistance += route.distance;
              this.travelTime += route.duration;
              this.drawLine(id, route.geometry.coordinates);
            }
          }
        })
        .catch((error) => {
          console.log('Maps. Could not get URL', error);
        });
    },
    async drawRoutes(features) {
      for (let i = 1; i < features.length; i++) {
        const start = features[i - 1].center;
        const end = features[i].center;
        await this.drawRoute('route' + i, start, end);
      }
    },
  },
  mounted() {
    mapboxgl.accessToken = this.accessToken;

    map = new mapboxgl.Map({
      container: 'map',
      style: 'mapbox://styles/mapbox/streets-v11',
      center: this.mapCenter, // Kaunas
      zoom: this.mapZoom,
      maxBounds: this.mapMaxBounds,
    });

    map.on('load', () => {
      //   map.resize();
      const mapboxClient = mapboxSdk({
        accessToken: mapboxgl.accessToken,
      });

      const features = this.cities.map((cityName) => {
        return mapboxClient.geocoding
          .forwardGeocode({
            query: cityName + ', Lithuania',
          })
          .send()
          .then((response) => {
            if (
              response &&
              response.body &&
              response.body.features &&
              response.body.features.length
            ) {
              return response.body.features[0];
            }
          });
      });

      Promise.all(features)
        .then((features) => {
          this.drawPoints(features);
          this.drawRoutes(features).then(() => {
            this.$emit(
              'on-distance-calculated',
              this.travelDistance,
              this.travelTime
            );
          });
        })
        .catch((e) => {
          console.log('Maps error accured:', e);
        });
    });
  },
};
</script>

<style>
#map {
  height: 300px;
  width: 400px;
}
.mapboxgl-control-container {
  display: none;
}
</style>