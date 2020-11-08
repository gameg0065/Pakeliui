<template>
  <div>
    <h1>{{ post.travel.from + ' - ' + post.travel.to }}</h1>
    <p>{{ post.date }}</p>

    <Comments :comments="post.comments" />
  </div>
</template>

<script>
import PostService from '@/services/PostService.js';
import Comments from '@/components/Comments.vue';

export default {
  props: ['id'],
  components: {
    Comments
  },
  data() {
    return {
      post: {}
    };
  },
  created() {
    this.post = PostService.getPost(this.id);
  }
};
</script>