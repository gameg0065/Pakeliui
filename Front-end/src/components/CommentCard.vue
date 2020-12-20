<template>
  <div class="card shadow flex direction-column">
    <div class="flex">
      <Avatar :path="comentator.picturePath" class="mr-20" />

      <div class="flex direction-column grow">
        <router-link
          :to="{ name: 'user', params: { id: comentator.userId || 0 } }"
        >
          <p class="text-color-primary">{{ comentator.name }}</p>
        </router-link>

        <small>{{
          DateFormat.getYearMonthDate(comment.date || comment.createDate)
        }}</small>
      </div>
    </div>

    <p>{{ comment.text }}</p>
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';

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
  },
  data() {
    return {
      comentator: Object,
    };
  },
  created() {
    this.DateFormat = DateFormat;
    const userId = this.comment.userId || this.comment.senderId;
    Service.getUserById(userId)
      .then((response) => {
        this.comentator = response.data;
      })
      .catch((error) => {
        console.log('Could not get user by ID', error);
      });
  },
};
</script>