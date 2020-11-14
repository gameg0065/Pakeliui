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
        <router-link v-if="isDriver" :to="{ name: 'post-create' }">
          <Button text="sukurk skelbimą" :isSecondary="true" />
        </router-link>
      </li>
    </ul>
    <ul class="right-links">
      <li v-if="!isLoggedIn">
        <a href="#" @click.prevent="$modal.show('modal-login')">prisijungti</a>
      </li>
      <li v-if="!isLoggedIn">
        <a href="#" @click.prevent="$modal.show('modal-register')"
          >registruotis</a
        >
      </li>
      <li v-if="isLoggedIn">
        <a href="#" @click.prevent="$emit('on-profile-button-click')">
          profilis
          <Avatar :path="getUser().photo" size="small" />
        </a>
      </li>
    </ul>
  </nav>
</template>

<style lang="scss">
@import '../assets/styles/header.scss';
</style>

<script>
import Avatar from '@/components/Avatar.vue';
import Button from '@/components/Button.vue';

import UserService from '@/services/UserService.js';

import { mapGetters } from 'vuex';

export default {
  components: {
    Avatar,
    Button,
  },
  computed: {
    ...mapGetters(['isLoggedIn', 'isDriver', 'userID'])
  },
  methods: {
    getUser() {
      return UserService.getUser(this.userID);
    },
  },
};
</script>
