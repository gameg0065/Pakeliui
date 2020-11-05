<template>
  <div>
    <h1>{{ post.title }}</h1>
    <p>{{ post.date }}</p>
  </div>
</template>

<script>
import PostService from '@/services/PostService.js';

export default {
  props: ['id'],
  data() {
    return {
      post: {}
    };
  },
  created() {
    this.post = PostService.getPost(this.id);
    console.log(this.post);
  }
};
</script>