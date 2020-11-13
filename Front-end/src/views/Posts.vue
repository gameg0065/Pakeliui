<template>
  <div>
    <h2>Skelbimai</h2>
    <PostFilter />
    <PostCard v-for="post in posts" :key="post.id" :post="post" />
  </div>
</template>

<script>
import PostCard from '@/components/PostCard.vue';
import PostFilter from '@/components/PostFilter.vue';

import PostService from '@/services/PostService.js';

export default {
  components: {
    PostCard,
    PostFilter,
  },
  data() {
    return {
      posts: [],
    };
  },
  created() {
    this.posts = PostService.getPosts();
  },
};
</script>