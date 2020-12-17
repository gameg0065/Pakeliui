<template>
  <div class="card shadow flex direction-column">
    <div class="flex">
      <Avatar :path="comentator.picturePath" class="mr-20" />

      <div class="flex direction-column grow">
        <router-link :to="{ name: 'user', params: { id: comentator.userId } }">
          <p class="text-color-primary">{{ comentator.name }}</p>
        </router-link>

        <small>{{ DateFormat.getYearMonthDate(comment.date) }}</small>
      </div>

      <!-- <Rating :rating="comentator.rating" /> -->
    </div>

    <p>{{ comment.text }}</p>
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
// import Rating from '@/components/Rating.vue';

import DateFormat from '@/assets/DateFormat.js';
import Service from '@/services/Service';

export default {
  name: 'CommentCard',
  props: {
    comment: {
      type: Object,
    },
  },
  components: {
    Avatar,
    // Rating,
  },
  data() {
    return {
      comentator: Object,
    };
  },
  created() {
    this.DateFormat = DateFormat;

    Service.getUserById(this.comment.userId)
      .then((response) => {
        this.comentator = response.data;
      })
      .catch((error) => {
        console.log('Could not get user by ID', error);
      });
  },
};
</script>