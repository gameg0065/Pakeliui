<template>
  <div class="home">
    <ModalLogin />
    <ModalRegister />

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
      <Button
        :click="openModalLogin"
        text="prisijungti"
        :isSecondary="false"
        :isLarge="true"
      />

      <Button
        :click="openModalRegister"
        text="užsiregistruoti"
        :isSecondary="true"
        :isLarge="true"
      />
    </div>

    <img src="../assets/images/hero-image.png" alt="hero" />
  </div>
</template>

<script lang='ts'>
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
    ...mapGetters(['isLoggedIn'])
  },
  methods: {
    openModalLogin() {
      this.$modal.show('modal-login');
    },
    openModalRegister() {
      this.$modal.show('modal-register');
    }
  }
};
</script>

