<template>
  <div class="posts align-stretch">
    <h2 class="page-title">Skelbimai</h2>
    <div class="posts-container flex">
      <PostFilter @on-post-filter-changed="onPostFilterChanged" class="mr-20" />
      <div class="flex direction-column grow">
        <PostCard v-for="post in posts" :key="post.id" :post="post" />
      </div>
    </div>
  </div>
</template>

<script>
import PostCard from '@/components/PostCard.vue';
import PostFilter from '@/components/PostFilter.vue';

import Service from '@/services/Service';

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
  async created() {
    this.posts = await Service.getAllPosts()
      .then((response) => {
        return response.data;
      })
      .catch((error) => {
        console.log('Could not get all posts', error);
      });
  },
  methods: {
    onPostFilterChanged(route, date) {
      const stringsAreEqual = this.stringsAreEqual;

      this.posts = this.posts.filter(function (post) {
        if (route.from) {
          if (!stringsAreEqual(route.from, post.travelFrom)) {
            return false;
          }
        }

        if (route.to) {
          if (!stringsAreEqual(route.to, post.travelTo)) {
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
      string1 = string1 ? string1 : '';
      string2 = string2 ? string2 : '';

      return string1.toLowerCase() === string2.toLowerCase();
    },
  },
};
</script>