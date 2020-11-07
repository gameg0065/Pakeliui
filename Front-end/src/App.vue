<template>
  <div id="app">
    <Header />

    <router-view />

    <Footer />
  </div>
</template>

<script>
import Header from '@/components/Header.vue';
import Footer from '@/components/Footer.vue';
export default {
  components: {
    Header,
    Footer
  }
};
</script>

<style lang="scss">
@import './assets/styles/_typography.css';
@import './assets/styles/_variables.css';

* {
  padding: 0;
  margin: 0;
}
</style>
