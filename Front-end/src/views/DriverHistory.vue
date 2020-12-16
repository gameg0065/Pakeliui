<template>
  <div class="align-stretch">
    <div class="pb-50">
      <h2 class="page-title">Aktyvūs skelbimai</h2>
      <div v-if="activePosts.length > 0">
        TODO
        <!-- <DriverActivePostCard
          v-for="post in activePosts"
          :key="post.id"
          :post="post"
        /> -->
      </div>
      <div v-else>
        <p>Jūs neturite aktyvių skelbimų. Įkelkite vieną dabar!</p>
        <router-link :to="{ name: 'post-create' }">
          <Button text="įkelti skelbimą" :isSecondary="true" :isLarge="true" />
        </router-link>
      </div>
    </div>
    <div class="bleed-width">
      <h3 class="section-title">Skelbimų istorija</h3>
      <div v-if="expiredPosts.length > 0">
        <DriverExpiredPostCard
          v-for="post in expiredPosts"
          :key="post.id"
          :post="post"
        />
      </div>
      <div v-else>
        <p>istorija tuščia</p>
      </div>
    </div>
  </div>
</template>

<script>
import DriverActivePostCard from '@/components/DriverActivePostCard.vue';
import DriverExpiredPostCard from '@/components/DriverExpiredPostCard.vue';

import PostService from '@/services/PostService.js';
import UserService from '@/services/UserService.js';

export default {
  name: 'DriverHistory',
  components: {
    // DriverActivePostCard,
    DriverExpiredPostCard,
  },
  computed: {
    user() {
      return this.$store.getters.getUser;
    },
  },
  data() {
    return {
      activePosts: [],
      expiredPosts: [],
    };
  },
  created() {
    const activePosts = this.activePosts;
    const expiredPosts = this.expiredPosts;
    const now = new Date();
    this.user.posts.forEach(function (post) {
      const postDate = new Date(post.date);

      if (postDate.getTime() <= now.getTime()) {
        expiredPosts.push(post);
      } else {
        activePosts.push(post);
      }
    });
  },
};
</script>