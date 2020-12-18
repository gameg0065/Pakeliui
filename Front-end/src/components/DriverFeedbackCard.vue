<template>
  <div class="flex direction-column">
    <div class="flex align-start mt-20">
      <Avatar :path="user.picturePath" size="small" class="mr-10" />
      <div class="flex direction-column grow">
        <router-link :to="{ name: 'user', params: { id: passengerId } }">
          <p class="text-color-primary">{{ user.name }}</p>
        </router-link>
        <!-- <small v-if="feedback"> Įvertinimo data: {{ feedback.date }} </small> -->
      </div>

      <!-- <Rating v-if="feedback" :rating="feedback.rating" />
      <Button
        v-else
        text="įvertink keleivį"
        :click="rateUser"
        :isOutlined="true"
        :isLarge="false"
      /> -->
    </div>

    <!-- <p v-if="feedback">{{ feedback.text }}</p> -->
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
// import Button from '@/components/Button.vue';
// import Rating from '@/components/Rating.vue';

// import FeedbackService from '@/services/FeedbackService.js';

import Service from '@/services/Service';

export default {
  name: 'DriverFeedbackCard',
  props: ['passengerId'],
  components: {
    Avatar,
    // Button,
    // Rating,
  },
  data() {
    return {
      user: {},
      feedback: null,
    };
  },
  async created() {
    await Service.getUserById(this.passengerId)
      .then((response) => {
        if (response.status === 200) {
          this.user = response.data;
        }
      })
      .catch((error) => {
        console.log('Could not get user by ID', error);
      });

    // if (this.passenger.feedback) {
    //   this.feedback = FeedbackService.getFeedback(this.passenger.feedback.id);
    // }
  },
  methods: {
    // rateUser() {
    //   const modal = this.$modal;
    //   modal.show('modal-feedback', {
    //     title: 'Atsiliepimas',
    //     text: 'Atsiliepimo pakeisti nebus galima.',
    //     ratingTitle: 'Įvertinkite keleivį',
    //     user: this.user,
    //     button: {
    //       title: 'skelbti atsiliepimą',
    //       action(data) {
    //         alert('TODO');
    //         modal.hide('modal-feedback');
    //       },
    //     },
    //   });
    // },
  },
};
</script>