<template>
  <div class="body">
    <h2>Kontaktai</h2>
    <form action="#">
      <div class="full-name">
        <label for="full-name">Vardas Pavardė</label>
        <input type="text" name="full-name" id="full-name" />
      </div>

      <div class="email">
        <label for="email">Elektroninis paštas</label>
        <input type="email" name="email" id="email" />
      </div>
      <div class="phone">
        <label for="phone">Telefono numeris</label>
        <input type="tel" name="phone" id="phone" />
      </div>

      <div class="city-drop">
        <label for="city-drop">Miestas</label>
        <select name="city-drop" id="city-drop">
          <option v-for="(city, index) in cities" :key="index" :value="city"
            >{{ city }}
          </option>
        </select>
      </div>

      <div class="agenda">
        <label for="agenda">Dėstyk savo reikalus čia</label>
        <textarea name="agenda" id="agenda" cols="30" rows="3"></textarea>
      </div>

      <button class="submit">Siųsti</button>
    </form>
    <img
      src="https://i1.alfi.lt/21081/76/48.png"
      alt="map Lietuva, Vilnius, Naugarduko g 141"
    />
  </div>
</template>

<script>
export default {
  data() {
    return {
      cities: ['Vilnius', 'Klaipeda', 'Siauliai', 'Panevezys', 'Alytus']
    };
  },
  created() {
    this.cities.sort();
  }
};
</script>
