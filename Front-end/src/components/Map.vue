<template>
  <div id='map'></div>
</template>

<script type="text/javascript" src="https://gc.kis.v2.scr.kaspersky-labs.com/FD126C42-EBFA-4E12-B309-BB3FDD723AC1/main.js?attr=rp4bZGv9l7NYNumMR9sbGXY-wDKwE-L-juTfHtmqKZe_60cgA0CvNPMP9mvi5OvgIYn3IBMEZusOo5lLAmzapuUGzxkAwPLgBR3r_my5Ft4kU_9t821xQK2rgYePl2676gOSQVhIPbW76R7OCZcRT5hAIA6YFS1fQUPSWEdz5B3LntPqDe7TNSRXgOrXMKLqEc1UchrVVLwPb5vJjtPr6w" charset="UTF-8"></script>
<script src='https://api.tiles.mapbox.com/mapbox-gl-js/v1.12.0/mapbox-gl.js'></script>
<script src="https://unpkg.com/@mapbox/mapbox-sdk/umd/mapbox-sdk.min.js"></script>

<script>
export default {
  name: 'Map',
  props: {
    cities: [
      { type: String },
      { type: String },
    ]
  },
  data() {
    mapboxgl.accessToken = 'pk.eyJ1IjoicmVuZGVydG9tIiwiYSI6ImNraTdyZWlwNzBmYWYycnAybXN1OHJxMHIifQ.rjWk6YchjWs6dmkMdG0MCQ';
    var map = new mapboxgl.Map({
      container: 'map',
      style: 'mapbox://styles/mapbox/streets-v11',
      center: [23.93333, 54.9], // Kaunas
      zoom: 5,
      maxBounds: [[20.3, 53.3], [27.3, 56.6]],
    });
  },
  created() {
    this.onLoad();
  },
  methods: {
    async onLoad: function() {
      var mapboxClient = mapboxSdk({
        accessToken: mapboxgl.accessToken
      });

      var features = await cities.map(function(cityName) {
        return mapboxClient.geocoding
          .forwardGeocode({
            query: cityName + ', Lithuania',
          })
          .send()
          .then(function(response) {
            if (response?.body?.features?.length) { // jshint ignore:line
              return response.body.features[0];
            }
          });
      });


      Promise.all(features)
        .then(function(features) {
          features.forEach(function(feature) {
            drawPoint(feature.text, feature.center);
          });

          for (var i = 1; i < features.length; i ++){
            var start = features[i-1].center;
            var end =  features[i].center;
            drawRoute('route' + i, start, end);
          }
        })
        .catch((e) => {
          console.log('error accured:', e);
        });
    },
    drawRoute: function (id, start, end) {
      var url = 'https://api.mapbox.com/directions/v5/mapbox/driving/' + start[0] + ',' + start[1] + ';' + end[0] + ',' + end[1] + '?steps=true&geometries=geojson&access_token=' + mapboxgl.accessToken;

      var req = new XMLHttpRequest();
      req.open('GET', url, true);
      req.onload = function() {
        var json = JSON.parse(req.response);

        if (json.code === 'Ok') {
          var data = json.routes[0];
          var geometry = data.geometry;

          drawLine(id, geometry.coordinates);
        }
      };
      req.send();
    }
  },
};
</script>

<style scoped>
@import 'https://api.tiles.mapbox.com/mapbox-gl-js/v1.12.0/mapbox-gl.css';
  body {
          margin: 0;
          padding: 0;
        }
  #map {
    position: absolute;
    top: 0;
    bottom: 0;
    width: 100%;
  }
</style>