<template>
  <div class="card shadow flex direction-column">
    <div class="flex">
      <Avatar :path="comentator.photo" class="mr-20" />

      <div class="flex direction-column grow">
        <router-link :to="{ name: 'user', params: { id: comentator.id } }">
          <p class="text-color-primary">{{ comentator.name }}</p>
        </router-link>

        <small>{{ comment.date }}</small>
      </div>

      <Rating :rating="comentator.rating" />
    </div>

    <p>{{ comment.text }}</p>
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
import Rating from '@/components/Rating.vue';
import UserService from '@/services/UserService.js';

export default {
  name: 'CommentCard',
  props: {
    comment: {
      type: Object,
    },
  },
  components: {
    Avatar,
    Rating,
  },
  data() {
    return {
      comentator: Object,
    };
  },
  created() {
    this.comentator = UserService.getUser(this.comment.author.id);
  },
};
</script>