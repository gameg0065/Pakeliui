<template>
  <div class="feedback card shadow">
    <Avatar :path="driver.photo" size="small" />
    <router-link :to="{ name: 'post', params: { id: post.id } }">
      <p class="link">
        {{ post.route.from + ' - ' + post.route.to }}
      </p>
    </router-link>
    <small> {{ post.date + ', ' + post.time }}</small>

    <div v-if="passenger.status === 'TAKEN'">
      <div v-if="trip.feedback">
        <p>{{ feedback.text }}</p>
        <Rating :rating="feedback.rating" />
      </div>
      <Button
        v-else
        text="parašyk atsiliepimą"
        :click="writeFeedback"
        :isOutlined="true"
      />
    </div>

    <div v-else>
      <p class="tripStatus">{{ passenger.status }}</p>
    </div>
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
import Button from '@/components/Button.vue';
import Rating from '@/components/Rating.vue';

import FeedbackService from '@/services/FeedbackService.js';
import PostService from '@/services/PostService.js';
import UserService from '@/services/UserService.js';

import { mapGetters } from 'vuex';

export default {
  props: ['trip'],
  components: {
    Avatar,
    Button,
    Rating,
  },
  computed: {
    ...mapGetters(['isLoggedIn', 'isDriver', 'userID']),
  },
  data() {
    return {
      driver: Object,
      feedback: Object,
      passenger: Object,
      post: Object,
    };
  },
  created() {
    const userID = this.userID;

    this.post = PostService.getPost(this.trip.post.id);

    this.passenger = this.post.passengers.find(
      (passenger) => passenger.id === userID
    );

    this.driver = UserService.getUser(this.post.driver.id);

    if (this.trip.feedback) {
      this.feedback = FeedbackService.getFeedback(this.trip.feedback.id);
    }
  },
  methods: {
    writeFeedback() {
      alert('TODO');
    },
  },
};
</script>

<style>
p.tripStatus {
  color: var(--color-secondary);
}

p.link {
  color: var(--color-primary);
}
</style>