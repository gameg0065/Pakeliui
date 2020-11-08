<template>
  <nav>
    <ul class="left-links">
      <li>
        <router-link :to="{ name: 'home' }"
          ><img src="../assets/images/logo-pakeliui.svg" class="logo"
        /></router-link>
      </li>
      <li v-if="isLoggedIn">
        <router-link :to="{ name: 'posts' }">
          <Button text="skelbimai" :isSecondary="true" />
        </router-link>
      </li>
      <li v-if="isLoggedIn">
        <router-link :to="{ name: 'post-create' }">
          <Button text="sukurk skelbimą" :isSecondary="true" />
        </router-link>
      </li>
    </ul>
    <ul class="right-links">
      <li v-if="!isLoggedIn">
        <ModalLogin />
        <a href="#" @click.prevent="$modal.show('modal-login')">prisijungti</a>
      </li>
      <li v-if="!isLoggedIn">
        <ModalRegister />
        <a href="#" @click.prevent="$modal.show('modal-register')"
          >registruotis</a
        >
      </li>
      <li v-if="isLoggedIn">
        <router-link :to="{ name: 'user', params: { id: userID } }"
          >profilis</router-link
        >
      </li>
    </ul>
  </nav>
</template>

<style lang="scss">
@import '../assets/styles/header.scss';
</style>

<script>
import Button from '@/components/Button.vue';
import ModalLogin from '@/components/ModalLogin.vue';
import ModalRegister from '@/components/ModalRegister.vue';

import { mapGetters } from 'vuex';

export default {
  components: {
    Button,
    ModalLogin,
    ModalRegister
  },
  computed: {
    ...mapGetters(['isLoggedIn', 'userID'])
  }
};
</script>
