<template>
  <div class="card shadow flex direction-column">
    <div class="flex">
      <Avatar :path="driver.photo" size="small" class="mr-20" />

      <div class="flex direction-column grow">
        <router-link :to="{ name: 'post', params: { id: post.id } }">
          <p class="text-color-primary">
            {{ post.route.from + ' - ' + post.route.to }}
          </p>
        </router-link>
        <small> {{ post.date + ', ' + post.time }}</small>
      </div>

      <div v-if="passenger.status === 'TAKEN'">
        <div v-if="trip.feedback">
          <Rating :rating="feedback.rating" />
        </div>

        <Button
          v-else
          text="rašyti atsiliepimą"
          :click="writeFeedback"
          :isOutlined="true"
        />
      </div>
      <p v-else class="text-color-secondary">
        {{ passenger.status }}
      </p>
    </div>

    <p v-if="trip.feedback" class="mt-10">{{ feedback.text }}</p>
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
import Button from '@/components/Button.vue';
import Rating from '@/components/Rating.vue';

import FeedbackService from '@/services/FeedbackService.js';
import PostService from '@/services/PostService.js';
import UserService from '@/services/UserService.js';

export default {
  name: 'FeedbackCard',
  props: ['trip'],
  components: {
    Avatar,
    Button,
    Rating,
  },
  computed: {
    user() {
      return this.$store.getters.getUser;
    },
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
    const userID = this.user.id;

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