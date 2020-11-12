<template>
  <div class="card shadow">
    <Avatar :path="driver.photo" size="small" />
    <router-link :to="{ name: 'post', params: { id: post.id } }">
      <p>{{ post.route.from + ' - ' + post.route.to }}</p>
    </router-link>
    <small> {{ post.date + ', ' + post.time }}</small>

    <div v-if="isCanceled">
      <p>ATMESTA</p>
    </div>

    <div v-else>
      <div v-if="feedback.id">
        {{ feedback.text }}
        <Rating :rating="feedback.rating" />
      </div>
      <div v-else>
        <Button
          :click="leaveFeedback"
          text="parašyk atsiliepimą"
          :isOutlined="true"
        />
      </div>
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
  props: {
    trip: Object,
    userID: Number,
    isCanceled: Boolean,
  },
  components: {
    Avatar,
    Button,
    Rating,
  },
  data() {
    return {
      driver: Object,
      post: Object,
      feedback: Object,
    };
  },
  created() {
    this.post = PostService.getPost(this.trip.id);
    this.driver = UserService.getUser(this.post.driver.id);
    if (this.trip.feedback) {
      this.feedback = FeedbackService.getFeedback(this.trip.feedback.id);
    }
  },
  methods: {
    leaveFeedback() {
      alert(
        'TODO\n' +
          'feedback sender ID: ' +
          this.userID +
          '\n' +
          'feedback receiver ID: ' +
          this.driver.id
      );
    },
  },
};
</script>