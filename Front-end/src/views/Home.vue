<template>
  <div class="home">
    <h1>Geresnis būdas keliauti</h1>
    <h3>
      Pakeliui - tai platforma, skirta žmonėms lengvai keliauti bei pavežėti
      kitus
    </h3>
    <div v-if="user">
      <router-link :to="{ name: 'posts' }">
        <Button text="skelbimai" :isLarge="true" />
      </router-link>

      <router-link v-if="user.isDriver" :to="{ name: 'post-create' }">
        <Button text="sukurk skelbimą" :isSecondary="true" :isLarge="true" />
      </router-link>
    </div>
    <div v-if="!user">
      <Button
        :click="openModalLogin"
        text="prisijungti"
        :isSecondary="false"
        :isLarge="true"
      />

      <Button
        :click="openModalRegister"
        text="užsiregistruoti"
        :isSecondary="true"
        :isLarge="true"
      />
    </div>

    <img src="../assets/images/hero-image.png" alt="hero" />
  </div>
</template>

<script>
import Button from '@/components/Button.vue';
export default {
  name: 'Home',
  components: {
    Button,
  },
  computed: {
    user() {
      return this.$store.getters.getUser;
    },
  },
  methods: {
    openModalLogin() {
      this.$modal.show('modal-login');
    },
    openModalRegister() {
      this.$modal.show('modal-register');
    },
  },
};
</script>

