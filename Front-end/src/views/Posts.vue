<template>
  <div class="posts">
    <h2>Skelbimai</h2>
    <div class="posts-container">
      <PostFilter @on-post-filter-changed="onPostFilterChanged" />
      <div class="posts-list">
        <PostCard v-for="post in posts" :key="post.id" :post="post" />
      </div>
    </div>
  </div>
</template>

<script>
import PostCard from '@/components/PostCard.vue';
import PostFilter from '@/components/PostFilter.vue';

import PostService from '@/services/PostService.js';

export default {
  name: 'Posts',
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
      const stringsAreEqual = this.stringsAreEqual;

      this.posts = posts.filter(function (post) {
        if (route.from) {
          if (!stringsAreEqual(route.from, post.route.from)) {
            return false;
          }
        }

        if (route.to) {
          if (!stringsAreEqual(route.to, post.route.to)) {
            return false;
          }
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
    stringsAreEqual(string1, string2) {
      return string1.toLowerCase() === string2.toLowerCase();
    },
  },
};
</script>


<style lang="scss">
@import '../assets/styles/posts.scss';
</style>