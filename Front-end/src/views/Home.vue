<template>
  <div class="home">
    <InProgressBanner />
    <div class="hero-text">
      <h1>Geresnis būdas keliauti</h1>
      <h3>
        Pakeliui - tai platforma, skirta žmonėms lengvai keliauti bei pavėžėti
        kitus
      </h3>
    </div>
    <div v-if="user">
      <router-link :to="{ name: 'posts' }">
        <Button text="skelbimai" :isLarge="true" class="mr-50" />
      </router-link>

      <router-link v-if="user.isDriver" :to="{ name: 'post-create' }">
        <Button text="ikelti skelbimą" :isSecondary="true" :isLarge="true" />
      </router-link>
    </div>
    <div v-else>
      <Button
        text="prisijungti"
        :click="openModalLogin"
        :isSecondary="false"
        :isLarge="true"
        class="mr-50"
      />

      <Button
        text="registruotis"
        :click="openModalRegister"
        :isSecondary="true"
        :isLarge="true"
      />
    </div>
  </div>
</template>

<script>
import Button from '@/components/Button.vue';
import InProgressBanner from '../components/InProgressBanner';
export default {
  name: 'Home',
  components: {
    Button,
    InProgressBanner,
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

<style lang="scss">
@import '../assets/styles/home.scss';
</style>