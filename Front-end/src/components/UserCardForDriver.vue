<template>
  <div class="card shadow flex direction-column">
    <div class="flex">
      <Avatar :path="user.photo" class="mr-20" />

      <div class="flex direction-column grow">
        <router-link :to="{ name: 'user', params: { id: user.id } }">
          <h4 class="text-color-primary mb-10">{{ user.name }}</h4>
        </router-link>

        <small> Kelionių skaičius: {{ countTrips() }} </small>
        <p>Susisiekite su manimi: {{ getContactInfo() }}</p>
      </div>

      <Rating :rating="user.rating" />
    </div>
    <router-link :to="{ name: 'post', params: { id: post.id } }">
      <Button text="atidaryti skelbimą" :isOutlined="true" class="mt-10"/>
    </router-link>
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
import Button from '@/components/Button.vue';
import Rating from '@/components/Rating.vue';

import PostService from '@/services/PostService.js';
import UserService from '@/services/UserService.js';

export default {
  name: 'UserCardForDriver',
  props: ['passengerID', 'post'],
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
    countTrips() {
      const posts = PostService.getPosts();
      const user = this.user;

      let counter = 0;
      posts.forEach(function (post) {
        post.passengers.forEach(function (passenger) {
          if (passenger.id === user.id && passenger.status === 'TAKEN') {
            counter++;
          }
        });
      });

      return counter;
    },
    getContactInfo() {
      const contactMethod = this.user.contactMethod;
      const contactInfo = this.user.contacts[contactMethod];
      return contactInfo;
    },
  },
};
</script>