<template>
  <div class="home">
    <h1>Geresnis būdas keliauti</h1>
    <h3>Pakeliui - tai platforma, skirta žmonėms lengvai keliauti bei pavežėti kitus</h3>
    <router-link :to="{ name: 'posts' }">
      <Button text="skelbimai" :isLarge="true" />
    </router-link>

    <router-link :to="{ name: 'post-create' }">
      <Button text="sukurk skelbimą" :isSecondary="true" :isLarge="true" />
    </router-link>

    <img src="../assets/images/hero-image.png" alt="hero">
  </div>
</template>

<script lang='ts'>
import Vue from 'vue';
import Button from '@/components/Button.vue'; // @ is an alias to /src

export default Vue.extend({
  components: {
    Button
  }
});
</script>