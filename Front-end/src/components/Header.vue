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
      <li v-if="!isLogedIn">
        <ModalLogin />
        <a href="#" @click.prevent="$modal.show('modal-login')">prisijungti</a>
      </li>
      <li v-if="!isLogedIn">
        <ModalRegister />
        <a href="#" @click.prevent="$modal.show('modal-register')"
          >registruotis</a
        >
      </li>
      <li v-if="isLogedIn">
        <router-link :to="{ name: 'user', params: { id: '1' } }"
          >profilis</router-link
        >
      </li>
    </ul>
  </nav>
</template>

<style scoped lang="scss">
@import '../assets/styles/header.scss';
</style>

<script>
import Button from '@/components/Button.vue';
import ModalLogin from '@/components/ModalLogin.vue';
import ModalRegister from '@/components/ModalRegister.vue';

export default {
  components: {
    Button,
    ModalLogin,
    ModalRegister
  },
  data() {
    return {
      isLogedIn: true
    };
  }
};
</script>
