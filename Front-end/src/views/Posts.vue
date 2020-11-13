<template>
  <div>
    <h2>Skelbimai</h2>
    <PostFilter @post-filter-changed="onPostFilterChanged" />
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
  methods: {
    onPostFilterChanged(route, date) {
      const posts = PostService.getPosts();
      this.posts = posts.filter(function (post) {
        if (route.from && post.route.from !== route.from) {
          return false;
        }
        
        if (route.to && post.route.to !== route.to) {
          return false;
        }

        if (date) {
          const postDate = new Date(post.date);
          const routeDate = new Date(date);

          if (postDate.getTime() <= routeDate.getTime()) {
            return false;
          }
        }
        return true;
      });
    },
  },
};
</script>