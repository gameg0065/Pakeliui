<template>
  <div class="body">
    <h2>Kontaktai</h2>
    <form>
      <div>
        <label for="full-name">Vardas, pavardė*</label>
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
          <option v-for="(city, index) in cities" :key="index" :value="city">
            {{ city }}
          </option>
        </select>
      </div>

      <div>
        <label for="agenda">Dėstyk savo reikalus čia</label>
        <textarea id="agenda" cols="30" rows="3"></textarea>
      </div>

      <Button :click="submit" text="Siųsti" :isOutlined="true" />
    </form>

    <img
      src="https://i1.alfi.lt/21081/76/48.png"
      alt="map Lietuva, Vilnius, Naugarduko g 141"
    />
  </div>
</template>

<script>
import Button from '@/components/Button.vue';
import cities from '../assets/cities.json';

export default {
  components: {
    Button,
  },
  data() {
    return {
      cities: [],
      selectedCity: null,
    };
  },
  created() {
    this.cities = cities.sort();
    this.selectedCity = this.cities.find(
      (city) => city.toLowerCase() === 'vilnius'
    );
  },
  methods: {
    submit() {
      alert('Jau bėgu ir siunčiu');
    },
  },
};
</script>


