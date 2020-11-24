<template>
  <div class="contacts">
    <h2 class="page-title">Kontaktai</h2>
    <p>Turite klausimų ar nusiskundimų? Užpildykite formą ir mes su Jumis susisieksime.</p>
    <form>
      <div class="line">
        <label for="full-name">Vardas, pavardė*</label>
        <input type="text" id="full-name" v-model.trim="name" />
      </div>

      <div class="line">
        <label for="email">Elektroninis paštas*</label>
        <input type="email" id="email" v-model.trim="email" />
      </div>

      <div class="line">
        <label for="phone">Telefono numeris</label>
        <input type="tel" id="phone" v-model.trim="phone" />
      </div>

      <div class="line">
        <label for="city">Miestas</label>
        <input type="text" id="city" v-model.trim="city" />
      </div>

      <div class="line">
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


<style lang="scss">
@import '../assets/styles/contacts.scss';
</style>