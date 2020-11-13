<template>
  <div>
    <h2>Skelbimai</h2>
    <PostCard v-for="post in posts" :key="post.id" :post="post" />
  </div>
</template>

<script>
import PostCard from '@/components/PostCard.vue';
import PostService from '@/services/PostService.js';

export default {
  components: {
    PostCard
  },
  data() {
    return {
      posts: []
    };
  },
  created() {
    this.posts = PostService.getPosts();
  }
};
</script>