<template>
  <div class="header">
    <nav>
      <ul class="left-links">
        <li>
          <router-link :to="{ name: 'home' }"
            ><img src="../assets/images/logo-pakeliui.svg" class="logo"
          /></router-link>
        </li>
        <li v-if="user">
          <router-link :to="{ name: 'posts' }">
            <Button text="skelbimai" :isSecondary="true" />
          </router-link>
        </li>
        <li v-if="user">
          <router-link v-if="user.isDriver" :to="{ name: 'post-create' }">
            <Button text="įkelti skelbimą" :isSecondary="true" />
          </router-link>
        </li>
      </ul>
      <ul class="right-links">
        <li v-if="!user">
          <a href="#" @click.prevent="$modal.show('modal-register')"
            >registruotis</a
          >
        </li>
        <li v-if="!user">
          <a href="#" @click.prevent="$modal.show('modal-login')"
            >prisijungti</a
          >
        </li>
        <li v-if="user">
          <a
            href="#"
            @click.prevent="$emit('on-profile-button-click')"
            class="profile-button"
          >
            profilis
            <Avatar :path="user.picturePath" size="small" />
          </a>
        </li>
      </ul>
    </nav>
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
import Button from '@/components/Button.vue';

export default {
  name: 'Header',
  components: {
    Avatar,
    Button,
  },
  computed: {
    user() {
      return this.$store.getters.getUser;
    },
  },
};
</script>

<style lang="scss">
@import '../assets/styles/header.scss';
</style>