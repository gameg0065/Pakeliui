<template>
  <div class="card shadow">
    <router-link :to="{ name: 'post', params: { id: post.id } }">
      <h4 class="text-color-primary">
        {{
          post.date +
          ', ' +
          post.time +
          ', ' +
          post.route.from +
          ' - ' +
          post.route.to
        }}
      </h4>
    </router-link>
    <p>Keleiviai:</p>

    <DriverFeedbackCard
      v-for="passenger in getPassengers('TAKEN')"
      :key="passenger.id"
      :passenger="passenger"
    />
  </div>
</template>


<script>
import DriverFeedbackCard from '@/components/DriverFeedbackCard.vue';

export default {
  name: 'DriverExpiredPostCard',
  props: ['post'],
  components: {
    DriverFeedbackCard,
  },
  methods: {
    getPassengers(status) {
      return this.post.passengers.filter(
        (passenger) => passenger.status === status
      );
    },
  },
};
</script>