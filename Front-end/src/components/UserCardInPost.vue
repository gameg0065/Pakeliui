<template>
  <div class="card shadow user-card-in-post">
    <Avatar class="user" :path="user.photo" />

    <div class="flex-column grow">
      <router-link :to="{ name: 'user', params: { id: user.id } }">
        <h4 class="link">{{ user.name }}</h4>
      </router-link>

      <small> Pavežėjimų skaičius: {{ this.user.driver.posts.length }}</small>

      <p>Susisiekite su manimi: {{ getContactInfo() }}</p>
    </div>

    <Rating :rating="user.driver.rating" />
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
import Rating from '@/components/Rating.vue';

import UserService from '@/services/UserService.js';

export default {
  name: 'UserCardInPost',
  props: ['post'],
  components: {
    Avatar,
    Rating,
  },
  data() {
    return {
      user: Object,
    };
  },
  created() {
    this.user = UserService.getUser(this.post.driver.id);
  },
  methods: {
    getContactInfo() {
      const contactMethod = this.user.driver.contactMethod;
      const contactInfo = this.user.contacts[contactMethod];
      return contactInfo;
    },
  },
};
</script>

<style lang="scss">
@import '../assets/styles/user-card-in-post.scss';
</style>