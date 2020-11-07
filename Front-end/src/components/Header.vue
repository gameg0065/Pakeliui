<template>
  <nav>
    <ul class="left-links">
      <li>
        <router-link :to="{ name: 'home' }"
          ><img src="../assets/images/logo-pakeliui.svg" class="logo"
        /></router-link>
      </li>
      <li v-if="isLogedIn">
        <router-link :to="{ name: 'posts' }">
          <Button text="skelbimai" :isSecondary="true" />
        </router-link>
      </li>
      <li v-if="isLogedIn">
        <router-link :to="{ name: 'post-create' }">
          <Button text="sukurk skelbimą" :isSecondary="true" />
        </router-link>
      </li>
    </ul>
    <ul class="right-links">
      <li v-if="!isLogedIn"><a href="#">prisijungti</a></li>
      <li v-if="!isLogedIn"><a href="#">registruotis</a></li>
      <li v-if="isLogedIn">
        <router-link :to="{ name: 'user', params: { id: '1' } }"
          >profilis</router-link
        >
      </li>
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
