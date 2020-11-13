<template>
  <div>
    <Avatar :path="user.photo" />
    <p>{{ user.name }}</p>

    <div v-if="feedback">
      <small> Įvertinimo data: {{ feedback.date }} </small>
      <p>{{ feedback.text }}</p>
      <Rating :rating="feedback.rating" />
    </div>

    <Button
      v-else
      :click="rateUser"
      text="įvertink keleivį"
      :isOutlined="true"
    />
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
import Button from '@/components/Button.vue';
import Rating from '@/components/Rating.vue';

import FeedbackService from '@/services/FeedbackService.js';
import UserService from '@/services/UserService.js';

export default {
  props: ['passenger'],
  components: {
    Avatar,
    Button,
    Rating,
  },
  data() {
    return {
      user: [],
      feedback: null,
    };
  },
  created() {
    this.user = UserService.getUser(this.passenger.id);
    if (this.passenger.feedback) {
      this.feedback = FeedbackService.getFeedback(this.passenger.feedback.id);
    }
  },
  methods: {
    rateUser() {
      alert('TODO');
    },
  },
};
</script>