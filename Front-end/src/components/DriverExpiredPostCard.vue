<template>
  <div class="card shadow">
    <router-link :to="{ name: 'post', params: { id: post.id } }">
      <h4 class="text-color-primary">
        {{
          DateFormat.getYearMonthDate(post.date) +
          ', ' +
          DateFormat.getHoursMinutes(post.time) +
          ', ' +
          post.travelFrom +
          ' - ' +
          post.travelTo
        }}
      </h4>
    </router-link>
    <p>Keleiviai:</p>

    <DriverFeedbackCard
      v-for="passenger in getPassengers('TAKEN')"
      :key="passenger.passengerId"
      :passenger="passenger"
    />
  </div>
</template>


<script>
import DriverFeedbackCard from '@/components/DriverFeedbackCard.vue';

import DateFormat from '@/assets/DateFormat.js';

export default {
  name: 'DriverExpiredPostCard',
  props: ['post'],
  components: {
    DriverFeedbackCard,
  },
  created() {
    this.DateFormat = DateFormat;
  },
  methods: {
    getPassengers(status) {
      if (this.post.passengers) {
        return this.post.passengers.filter(
          (passenger) => passenger.status === status
        );
      }
    },
  },
};
</script>