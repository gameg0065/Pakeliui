<template>
  <div id="app">
    <!-- MODAL DIALOGS -->
    <ModalFeedback />
    <ModalLogin />
    <ModalMessaging />
    <ModalNotification />
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

import ModalFeedback from '@/components/ModalFeedback.vue';
import ModalLogin from '@/components/ModalLogin.vue';
import ModalMessaging from '@/components/ModalMessaging.vue';
import ModalNotification from '@/components/ModalNotification.vue';
import ModalRegister from '@/components/ModalRegister.vue';
import ProfileDropdown from '@/components/ProfileDropdown.vue';

export default {
  name: 'App',
  components: {
    Header,
    Footer,
    ModalFeedback,
    ModalLogin,
    ModalMessaging,
    ModalNotification,
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
@import './assets/styles/global.scss';
</style>
