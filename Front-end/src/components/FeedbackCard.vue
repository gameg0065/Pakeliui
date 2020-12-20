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
            DateFormat.getYearMonthDate(post.date) +
            ', ' +
            DateFormat.getHoursMinutes(post.time)
          }}</small
        >
      </div>

      <p v-if="passenger.status !== 'TAKEN'" class="text-color-secondary">
        {{ passenger.status }}
      </p>
    </div>
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
import Button from '@/components/Button.vue';

import DateFormat from '@/assets/DateFormat.js';

export default {
  name: 'FeedbackCard',
  props: ['post'],
  components: {
    Avatar,
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
    this.DateFormat = DateFormat;

    const userId = this.user.userId;
    this.passenger = this.post.passengers.find(
      (passenger) => passenger.passengerId === userId
    );
  },
};
</script>