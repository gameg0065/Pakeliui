<template>
  <div>
    <Avatar :path="user.photo" />
    <router-link :to="{ name: 'user', params: { id: user.id } }">
      <p class="link">{{ user.name }}</p>
    </router-link>

    <div v-if="feedback">
      <small> Įvertinimo data: {{ feedback.date }} </small>
      <p>{{ feedback.text }}</p>
      <Rating :rating="feedback.rating" />
    </div>

    <Button
      v-else
      text="įvertink keleivį"
      :click="rateUser"
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
  name: 'DriverFeedbackCard',
  props: ['passenger'],
  components: {
    Avatar,
    Button,
    Rating,
  },
  data() {
    return {
      user: null,
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
      const modal = this.$modal;
      modal.show('modal-feedback', {
        title: 'Atsiliepimas',
        text: 'Atsiliepimo pakeisti nebus galima.',
        ratingTitle: 'Įvertinkite keleivį',
        user: this.user,
        button: {
          title: 'skelbti atsiliepimą',
          action(data) {
            alert('TODO');
            modal.hide('modal-feedback');
          },
        },
      });
    },
  },
};
</script>

<style>
p.link {
  color: var(--color-primary);
}
</style>