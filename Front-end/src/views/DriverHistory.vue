<template>
  <div class="align-stretch">
    <div class="pb-50">
      <h2 class="page-title">Aktyvūs skelbimai</h2>
      <div v-if="activePosts.length > 0">
        <DriverActivePostCard
          @on-post-delete="onPostDelete"
          v-for="post in activePosts"
          :key="post.id"
          :post="post"
        />
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

export default {
  name: 'DriverHistory',
  components: {
    DriverActivePostCard,
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
    const now = new Date();
    const posts = this.user.posts;

    if (posts) {
      posts.forEach((post) => {
        const postDate = new Date(post.date);

        if (postDate.getTime() <= now.getTime()) {
          this.expiredPosts.push(post);
        } else {
          this.activePosts.push(post);
        }
      });
    }
  },
  methods: {
    removeArrayItemBy(array, object, key) {
      array.splice(
        array.findIndex((item) => item[key] === object[key]),
        1
      );
    },
    onPostDelete(post) {
      const posts = this.user.posts;

      if (posts) {
        this.removeArrayItemBy(posts, post, 'id');

        this.$store.dispatch('updateUser', this.user).then(() => {
          this.removeArrayItemBy(this.activePosts, post, 'id');
        });
      }
    },
  },
};
</script>