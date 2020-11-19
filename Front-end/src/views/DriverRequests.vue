<template>
  <div>
		<h2>Rezervacijos, laukiančios patvirtinimo</h2>
    <div v-if="pendingPosts.length > 0">
      <div v-for="post in pendingPosts" :key="post.id">
        <div v-for="passenger in post.passengers" :key="passenger.id">
          <div v-if="passenger.status === 'PENDING'">
            <UserCardForDriver :passengerID="passenger.id" :post="post" />
            <Button
              text="atmesti"
              :click="dismiss"
              :isOutlined="true"
              :isSecondary="true"
            />
            <Button text="patvirtinti" :click="approve" :isOutlined="true" />
          </div>
        </div>
      </div>
    </div>
    <div v-else>
      <p>Rezervacijų nėra</p>
    </div>
  </div>
</template>

<script>
import Button from '@/components/Button.vue';
import UserCardForDriver from '@/components/UserCardForDriver.vue';

import PostService from '@/services/PostService.js';
import UserService from '@/services/UserService.js';

export default {
  name: 'DriverRequests',
  components: {
    Button,
    UserCardForDriver,
  },
  computed: {
    user() {
      return this.$store.getters.getUser;
    },
  },
  data() {
    return {
      pendingPosts: [],
    };
  },
  created() {
    this.pendingPosts = this.getDriverPostsWithPassengersWithStatus('PENDING');
  },
  methods: {
    approve() {
      alert('TODO');
    },
    dismiss() {
      alert('TODO');
    },
    getDriverPostsWithPassengersWithStatus(status) {
      const postHasPassengersWithStatus = this.postHasPassengersWithStatus;
      const user = this.user;

      return user.driver.posts.reduce(function (accumulator, trip) {
        const post = PostService.getPost(trip.id);
        if (postHasPassengersWithStatus(post, status)) {
          accumulator.push(post);
        }
        return accumulator;
      }, []);
    },
    postHasPassengersWithStatus(post, status) {
      return post.passengers.some(function (passenger) {
        return passenger.status === status;
      });
    },
  },
};
</script>