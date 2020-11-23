<template>
  <div class="home">
    <div class="hero-text">
      <h1>Geresnis būdas keliauti</h1>
      <h3>
        Pakeliui - tai platforma, skirta žmonėms lengvai keliauti bei pavežėti
        kitus
      </h3>
    </div>
    <div v-if="user">
      <router-link :to="{ name: 'posts' }">
        <Button text="skelbimai" :isLarge="true" />
      </router-link>

      <router-link v-if="user.isDriver" :to="{ name: 'post-create' }">
        <Button
          class="home-button"
          text="sukurk skelbimą"
          :isSecondary="true"
          :isLarge="true"
        />
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
        class="home-button"
        :click="openModalRegister"
        text="registruotis"
        :isSecondary="true"
        :isLarge="true"
      />
    </div>
  </div>
</template>

<style lang="scss">
@import '../assets/styles/home.scss';
</style>

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

