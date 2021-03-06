<template>
  <div class="posts align-stretch">
    <h2 class="page-title">Skelbimai</h2>
    <label>
      <input
        type="checkbox"
        v-model="hideExpiredPosts"
        v-on:change="loadPosts"
      />
      Rodyti tik galiojančius skelbimus
    </label>
    <div class="posts-container flex">
      <PostFilter @on-post-filter-changed="onPostFilterChanged" class="mr-20" />
      <p v-if="isLoading">Prašome palaukti</p>
      <p v-if="!isLoading && posts.length === 0">Skelbimų nerasta</p>
      <div class="flex direction-column grow">
        <PostCard
          v-for="post in posts"
          :key="post.id"
          :post="post"
          @on-cancel-reservation="onCancelReservation"
        />
      </div>
    </div>
  </div>
</template>

<script>
import PostCard from '@/components/PostCard.vue';
import PostFilter from '@/components/PostFilter.vue';

import Service from '@/services/Service';
import Utils from '@/assets/Utils.js';

export default {
  name: 'Posts',
  components: {
    PostCard,
    PostFilter,
  },
  data() {
    return {
      posts: [],
      isLoading: false,
      hideExpiredPosts: true,
    };
  },
  async created() {
    this.loadPosts();
  },
  methods: {
    async loadPosts() {
      this.posts = await this.getAllPosts();
    },
    getAllPosts() {
      this.posts = [];
      this.isLoading = true;

      const now = new Date();
      return Service.getAllPosts()
        .then((response) => {
          this.isLoading = false;

          const posts = response.data.sort(Utils.sortPostsByDateAndTime);

          if (this.hideExpiredPosts) {
            return posts.filter((post) => {
              const postDate = new Date(post.date);
              return postDate.getTime() >= now.getTime();
            });
          } else {
            return posts;
          }
        })
        .catch((error) => {
          this.isLoading = false;
          console.log('Could not get all posts', error);
        });
    },
    async onPostFilterChanged(route, date) {
      const posts = await this.getAllPosts();

      this.posts = posts.filter((post) => {
        if (route.from) {
          if (!Utils.stringsAreEqual(route.from, post.travelFrom)) {
            return false;
          }
        }

        if (route.to) {
          if (!Utils.stringsAreEqual(route.to, post.travelTo)) {
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
    onCancelReservation(post, reservation) {
      this.loadPosts();
    },
  },
};
</script>