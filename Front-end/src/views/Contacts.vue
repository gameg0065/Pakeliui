<template>
  <div class="body">
    <h2>Kontaktai</h2>
    <form>
      <p>Turite klausimų ar nusiskundimų? Užpildykite formą ir mes su Jumis susisieksime.</p>
      <div>
        <label for="full-name">Vardas, pavardė*</label>
        <input type="text" id="full-name" v-model.trim="name" />
      </div>

      <div>
        <label for="email">Elektroninis paštas*</label>
        <input type="email" id="email" v-model.trim="email" />
      </div>

      <div>
        <label for="phone">Telefono numeris</label>
        <input type="tel" id="phone" v-model.trim="phone" />
      </div>

      <div>
        <label for="city">Miestas</label>
        <input type="text" id="city" v-model.trim="city" />
      </div>

      <div>
        <label for="message">Žinutė</label>
        <textarea
          id="message"
          cols="30"
          rows="3"
          v-model.trim="message"
        ></textarea>
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

export default {
  name: 'Contacts',
  components: {
    Button,
  },
  data() {
    return {
      city: null,
      email: null,
      message: null,
      name: null,
      phone: null,
    };
  },
  methods: {
    submit() {
      alert('TODO\nJau bėgu ir siunčiu');
    },
  },
};
</script>


