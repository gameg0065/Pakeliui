<template>
  <div>
    <div v-if="pendingPosts.length > 0">
      <div v-for="post in pendingPosts" :key="post.id">
        <div v-for="passenger in post.passengers" :key="passenger.id">
          <div v-if="passenger.status === 'PENDING'">
            <UserCardForDriver :passengerID="passenger.id" :postID="post.id" />
            <Button text="atmesti" :isOutlined="true" :isSecondary="true" />
            <Button text="patvirtinti" :isOutlined="true" />
          </div>
        </div>
      </div>
    </div>
    <div v-else>
      <p>No requests</p>
    </div>
  </div>
</template>

<script>
import Button from '@/components/Button.vue';
import UserCardForDriver from '@/components/UserCardForDriver.vue';

import PostService from '@/services/PostService.js';
import UserService from '@/services/UserService.js';

import { mapGetters } from 'vuex';

export default {
  components: {
    Button,
    UserCardForDriver,
  },
  computed: {
    ...mapGetters(['isLoggedIn', 'isDriver', 'userID']),
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
    getDriverPostsWithPassengersWithStatus(status) {
      const postHasPassengersWithStatus = this.postHasPassengersWithStatus;
      const user = UserService.getUser(this.userID);

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