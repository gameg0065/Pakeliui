<template>
  <div>
    <div>
      <h2>Aktyvūs skelbimai</h2>
      <div v-if="activePosts.length > 0">
        <DriverActivePostCard
          v-for="post in activePosts"
          :key="post.id"
          :post="post"
        />
      </div>
      <div v-else>
        <p>Jūs neturite aktyvių skelbimų. Sukurkite vieną dabar!</p>
        <router-link :to="{ name: 'post-create' }">
          <Button text="sukurk skelbimą" :isSecondary="true" :isLarge="true" />
        </router-link>
      </div>
    </div>
    <div>
      <h3>Skelbimų istorija</h3>
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

import { mapGetters } from 'vuex';

export default {
  components: {
    DriverActivePostCard,
    DriverExpiredPostCard,
  },
  computed: {
    ...mapGetters(['isLoggedIn', 'isDriver', 'userID']),
  },
  data() {
    return {
      activePosts: [],
      expiredPosts: [],
      user: Object,
    };
  },
  created() {
    this.user = UserService.getUser(this.userID);

    const activePosts = this.activePosts;
    const expiredPosts = this.expiredPosts;
    const now = new Date();
    this.user.driver.posts.forEach(function (obj) {
      const post = PostService.getPost(obj.id);
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