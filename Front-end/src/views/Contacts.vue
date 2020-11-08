<template>
  <div class="body">
    <h2>Kontaktai</h2>
    <form>
      <div>
        <label for="full-name">Vardas,pavardė*</label>
        <input type="text" id="full-name" />
      </div>

      <div>
        <label for="email">Elektroninis paštas*</label>
        <input type="email" id="email" />
      </div>
      <div>
        <label for="phone">Telefono numeris</label>
        <input type="tel" id="phone" />
      </div>

      <div>
        <label for="city-drop">Miestas</label>
        <select id="city-drop" v-model="selectedCity">
          <option v-for="(city, index) in cities" :key="index" :value="city"
            >{{ city }}
          </option>
        </select>
      </div>

      <div>
        <label for="agenda">Dėstyk savo reikalus čia</label>
        <textarea id="agenda" cols="30" rows="3"></textarea>
      </div>

      <button @click.prevent>Siųsti</button>
    </form>
    <img
      src="https://i1.alfi.lt/21081/76/48.png"
      alt="map Lietuva, Vilnius, Naugarduko g 141"
    />
  </div>
</template>

<script>
import cities from '../assets/cities.json';
export default {
  data() {
    return {
      selectedCity: null,
      cities: []
    };
  },
  created() {
    this.cities = cities.sort();
    this.selectedCity = this.cities.find(
      city => city.toLowerCase() === 'vilnius'
    );
  }
};
</script>


