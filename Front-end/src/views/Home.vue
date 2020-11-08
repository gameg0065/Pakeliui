<template>
  <div class="home">
    <h1>Geresnis būdas keliauti</h1>
    <h3>
      Pakeliui - tai platforma, skirta žmonėms lengvai keliauti bei pavežėti
      kitus
    </h3>
    <div v-if="isLoggedIn">
      <router-link :to="{ name: 'posts' }">
        <Button text="skelbimai" :isLarge="true" />
      </router-link>

      <router-link :to="{ name: 'post-create' }">
        <Button text="sukurk skelbimą" :isSecondary="true" :isLarge="true" />
      </router-link>
    </div>
    <div v-if="!isLoggedIn">
      <Button text="prisijungti" :isSecondary="false" :isLarge="true" />
      <Button text="užsiregistruoti" :isSecondary="true" :isLarge="true" />
    </div>

    <img src="../assets/images/hero-image.png" alt="hero" />
  </div>
</template>

<script lang='ts'>
import Button from '@/components/Button.vue';

import { mapGetters } from 'vuex';
export default {
  components: {
    Button
  },
  computed: {
    ...mapGetters(['isLoggedIn'])
  }
};
</script>