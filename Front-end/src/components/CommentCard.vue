<template>
  <div class="comment-card shadow">
    <div class="comment-info">

      <div class="info">
        <Avatar :path="comentator.photo" />
        <div>
          <router-link :to="{ name: 'user', params: { id: comentator.id } }">
            <p class="link">{{ comentator.name }}</p>
          </router-link>

          <small>{{ comment.date }}</small>                            
        </div>
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

<style>
@import '../assets/styles/comment-card.scss';
</style>