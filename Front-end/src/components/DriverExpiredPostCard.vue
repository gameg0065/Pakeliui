<template>
  <div class="card shadow">
    <div class="flex justify-between">
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
      <Button
        text="x"
        :isOutlined="true"
        :isSecondary="true"
        :click="deletePost"
      />
    </div>
    <p>Keleiviai:</p>
    <DriverFeedbackCard
      v-for="passenger in passengers"
      :key="passenger.passengerId"
      :passengerId="passenger.passengerId"
    />
  </div>
</template>


<script>
import Button from '@/components/Button.vue';
import DriverFeedbackCard from '@/components/DriverFeedbackCard.vue';

import DateFormat from '@/assets/DateFormat.js';
import Service from '@/services/Service';

export default {
  name: 'DriverExpiredPostCard',
  props: ['post'],
  components: {
    Button,
    DriverFeedbackCard,
  },
  data() {
    return {
      passengers: [],
    };
  },
  created() {
    this.DateFormat = DateFormat;
    this.getPassengers();
  },
  methods: {
    deletePost() {
      this.$emit('on-post-delete', this.post);
    },
    getPassengers() {
      Service.getPostById(this.post.id)
        .then((response) => {
          if (response.status === 200) {
            const passengers = response.data.passengers;
            if (passengers) {
              this.passengers = passengers.filter((passenger) => {
                return passenger.status === 'TAKEN';
              });
            }
          }
        })
        .catch((error) => {
          console.log('Could not get post by ID', error);
        });
    },
  },
};
</script>