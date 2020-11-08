<template>
  <div id="app">
    <!-- MODAL DIALOGS -->
    <ModalLogin />
    <ModalRegister />

    <Header />

    <router-view />

    <Footer />
  </div>
</template>

<script>
import Header from '@/components/Header.vue';
import Footer from '@/components/Footer.vue';

import ModalLogin from '@/components/ModalLogin.vue';
import ModalRegister from '@/components/ModalRegister.vue';

export default {
  components: {
    Header,
    Footer,
    ModalLogin,
    ModalRegister
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
