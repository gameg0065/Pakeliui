<template>
  <div class="card shadow">
    <Avatar :path="user.photo" />

    <h4>{{ user.name }}</h4>
    <small v-if="displayedInPost">
      Pavežimų skaičius: {{ getPostCount() }}</small
    >
    <small v-else> Kelionių skaičius: {{ getTripCount() }}</small>

    <p>Susisiek su main: {{ getContactInfo() }}</p>

    <Rating :rating="getRating()" />

    <router-link
      v-if="!displayedInPost"
      :to="{ name: 'post', params: { id: post.id } }"
    >
      <Button text="atidaryti skelbimą" />
    </router-link>
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
import Button from '@/components/Button.vue';
import Rating from '@/components/Rating.vue';

import UserService from '@/services/UserService.js';

export default {
  props: ['post', 'displayedInPost'],
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
    let userID = 100; // TODO
    if (this.displayedInPost) {
      userID = this.post.driver.id;
    }
    this.user = UserService.getUser(userID);
  },
  methods: {
    getRating() {
      let rating = this.user.rating;
      if (this.displayedInPost) {
        rating = this.user.driver.rating;
      }
      return rating;
    },
    getContactInfo() {
      let contactMethod = this.user.contact;
      if (this.displayedInPost) {
        contactMethod = this.user.driver.contact;
      }

      const contactInfo = this.user.contacts[contactMethod];
      return contactInfo;
    },
    getPostCount() {
      return this.user.driver.posts.length;
    },
    getTripCount() {
      const tripsTaken = this.user.trips.filter(function (trip) {
        return trip.status === 'TAKEN';
      });
      return tripsTaken.length;
    },
  },
};
</script>