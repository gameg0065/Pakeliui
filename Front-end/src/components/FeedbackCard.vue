<template>
  <div class="card shadow flex direction-column">
    <div class="flex">
      <Avatar :path="post.user.picturePath" size="small" class="mr-20" />

      <div class="flex direction-column grow">
        <router-link :to="{ name: 'post', params: { id: post.id } }">
          <p class="text-color-primary">
            {{ post.travelFrom + ' - ' + post.travelTo }}
          </p>
        </router-link>
        <small>
          {{
            (post.date || 'Kelionės data') +
            ', ' +
            (post.time || 'Kelionės laikas')
          }}</small
        >
      </div>

      <div v-if="passenger.status === 'TAKEN'">
        <div v-if="post.feedback">
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

    <!-- <p v-if="post.feedback" class="mt-10">{{ feedback.text }}</p> -->
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
import Button from '@/components/Button.vue';
// import Rating from '@/components/Rating.vue';

// import FeedbackService from '@/services/FeedbackService.js';

export default {
  name: 'FeedbackCard',
  props: ['post'],
  components: {
    Avatar,
    Button,
    // Rating,
  },
  computed: {
    user() {
      return this.$store.getters.getUser;
    },
  },
  data() {
    return {
      feedback: Object,
      passenger: Object,
    };
  },
  created() {
    const userId = this.user.userId;
    this.passenger = this.post.passengers.find(
      (passenger) => passenger.passengerId === userId
    );

    // if (this.post.feedback) {
    //   this.feedback = FeedbackService.getFeedback(this.post.feedback.id);
    // }
  },
  methods: {
    writeFeedback() {
      alert('TODO');
    },
  },
};
</script>