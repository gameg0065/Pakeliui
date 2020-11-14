<template>
  <div class="card shadow">
    <Avatar :path="user.photo" />

    <router-link :to="{ name: 'user', params: { id: user.id } }">
      <h4 class="link">{{ user.name }}</h4>
    </router-link>

    <small> Kelionių skaičius: TODO </small>
    <p>Susisiek su manim: {{ getContactInfo() }}</p>

    <Rating :rating="user.rating" />

    <router-link :to="{ name: 'post', params: { id: postID } }">
      <Button text="atidaryti skelbimą" :isOutlined="true" />
    </router-link>
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
import Button from '@/components/Button.vue';
import Rating from '@/components/Rating.vue';

import UserService from '@/services/UserService.js';

export default {
  props: ['passengerID', 'postID'],
  components: {
    Avatar,
    Button,
    Rating,
  },
  data() {
    return {
      user: Object,
    };
  },
  created() {
    this.user = UserService.getUser(this.passengerID);
  },
  methods: {
    getContactInfo() {
      const contactMethod = this.user.contactMethod;
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