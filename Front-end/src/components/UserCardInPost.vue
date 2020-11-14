<template>
  <div class="card shadow">
    <Avatar :path="user.photo" />

    <router-link :to="{ name: 'user', params: { id: user.id } }">
      <h4 class="link">{{ user.name }}</h4>
    </router-link>

    <small> Pavežimų skaičius: {{ this.user.driver.posts.length }}</small>

    <p>Susisiek su main: {{ getContactInfo() }}</p>

    <Rating :rating="user.driver.rating" />
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
import Rating from '@/components/Rating.vue';

import UserService from '@/services/UserService.js';

export default {
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

<style scoped>
h4.link {
  color: var(--color-primary);
}
</style>