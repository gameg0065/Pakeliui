<template>
  <nav>
    <ul class="left-links">
      <li>
        <a href="#"
          ><img src="../assets/images/logo-pakeliui.svg" class="logo"
        /></a>
      </li>
      <li v-show="isLogedIn">
        <Button text="skelbimai" :isSecondary="true"></Button>
      </li>
      <li v-show="isLogedIn">
        <Button text="įkelk skelbimą" :isSecondary="true"></Button>
      </li>
    </ul>
    <ul class="right-links">
      <li v-show="!isLogedIn"><a href="#">prisijungti</a></li>
      <li v-show="!isLogedIn"><a href="#">registruotis</a></li>
      <li v-show="isLogedIn"><a href="#">profilis</a></li>
    </ul>
  </nav>
</template>

<style lang="scss">
@import '../assets/styles/_variables.css';
@import '../assets/styles/_typography.css';
@import '../assets/styles/header.scss';
@import '../assets/styles/Button.css';
</style>

<script lang="ts">
import Vue from 'vue';
import Button from '@/components/Button.vue';

export default {
  components: {
    Button
  },
  data() {
    return {
      isLogedIn: true
    };
  }
};
</script>
