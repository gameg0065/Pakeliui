<template>
  <div id="app">
    <!-- MODAL DIALOGS -->
    <ModalLogin />
    <ModalRegister />

    <ProfileDropdown
      v-if="dropdownIsVisible"
      @on-profile-button-click="onProfileButtonClick"
    />

    <Header @on-profile-button-click="onProfileButtonClick" />

    <router-view :key="$route.fullPath" class="page" />

    <Footer />
  </div>
</template>

<script>
import Header from '@/components/Header.vue';
import Footer from '@/components/Footer.vue';

import ModalLogin from '@/components/ModalLogin.vue';
import ModalRegister from '@/components/ModalRegister.vue';
import ProfileDropdown from '@/components/ProfileDropdown.vue';

export default {
  name: 'App',
  components: {
    Header,
    Footer,
    ModalLogin,
    ModalRegister,
    ProfileDropdown,
  },
  data() {
    return {
      dropdownIsVisible: false,
    };
  },
  methods: {
    onProfileButtonClick(event) {
      this.dropdownIsVisible = !this.dropdownIsVisible;
    },
  },
};
</script>

<style lang="scss">
@import './assets/styles/_typography.css';
@import './assets/styles/_variables.css';

.page {
  align-items: center;
  display: flex;
  flex-direction: column;
  justify-content: center;
  min-height: calc(100vh - 200px);
}

* {
  padding: 0;
  margin: 0;
}
</style>
