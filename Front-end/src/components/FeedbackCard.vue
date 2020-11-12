<template>
  <div class="feedback card shadow">
    <Avatar :path="driver.photo" size="small" />
    <router-link :to="{ name: 'post', params: { id: post.id } }">
      <p>{{ post.route.from + ' - ' + post.route.to }}</p>
    </router-link>
    <small> {{ post.date + ', ' + post.time }}</small>

    <div v-if="trip.status === 'TAKEN'">
      <div v-if="trip.feedback">
        <p>{{ feedback.text }}</p>
        <Rating :rating="feedback.rating" />
      </div>

      <Button v-else text="parašyk atsiliepimą" :isOutlined="true" />
    </div>
    <div v-else>
      <p class="tripStatus">{{ trip.status }}</p>
    </div>
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
import Button from '@/components/Button.vue';
import Rating from '@/components/Rating.vue';

import UserService from '@/services/UserService.js';
import FeedbackService from '@/services/FeedbackService.js';
import PostService from '@/services/PostService.js';

export default {
  props: ['trip'],
  components: {
    Avatar,
    Button,
    Rating,
  },
  data() {
    return {
      driver: Object,
      feedback: Object,
      post: Object,
    };
  },
  created() {
    this.post = PostService.getPost(this.trip.post.id);
    this.driver = UserService.getUser(this.post.driver.id);
    if (this.trip.feedback) {
      this.feedback = FeedbackService.getFeedback(this.trip.feedback.id);
    }
  },
};
</script>

<style>
p.tripStatus {
  color: red;
}
</style>