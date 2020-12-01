<template>
  <div class="card shadow flex">
    <Avatar :path="user.photo" class="mr-20"/>

    <div class="flex direction-column grow">
      <router-link :to="{ name: 'user', params: { id: user.id } }">
        <h4 class="text-color-primary mb-10">{{ user.name }}</h4>
      </router-link>

      <small> Pavėžėjimų skaičius: {{ this.user.driver.posts.length }}</small>

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