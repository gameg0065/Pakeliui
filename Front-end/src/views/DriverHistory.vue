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
      <div v-else class="flex direction-column align-center">
        <p>
          Jūs neturite aktyvių skelbimų. Įkelkite vieną dabar!
        </p>
        <router-link :to="{ name: 'post-create' }">
          <Button
            text="įkelti skelbimą"
            class="mt-20"
            :isSecondary="true"
            :isLarge="true"
          />
        </router-link>
      </div>
    </div>
    <div class="bleed-width">
      <h3 class="section-title">Skelbimų istorija</h3>
      <div v-if="expiredPosts.length > 0">
        <DriverExpiredPostCard
          @on-post-delete="onPostDelete"
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
import Button from '@/components/Button.vue';
import DriverActivePostCard from '@/components/DriverActivePostCard.vue';
import DriverExpiredPostCard from '@/components/DriverExpiredPostCard.vue';

import Service from '@/services/Service';

export default {
  name: 'DriverHistory',
  components: {
    Button,
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
    this.sortPosts();
  },
  methods: {
    deletePostFromCache(post) {
      const posts = this.user.posts;

      if (posts) {
        this.removeArrayItemBy(posts, post, 'id');

        this.$store.dispatch('updateUser', this.user).then(() => {
          this.sortPosts();
        });
      }
    },
    onPostDelete(post) {
      const deletePostFromCache = this.deletePostFromCache;
      const modal = this.$modal;

      modal.show('modal-notification', {
        title: 'Patvirtinimas',
        text: 'Ar tikrai norite ištrinti skelbimą? Kelio atgal nėra.',
        button: {
          title: 'ištrinti',
          action() {
            Service.deletePost(post)
              .then((response) => {
                deletePostFromCache(post);
                modal.hide('modal-notification');
              })
              .catch((error) => {
                console.log('Could not delete post', error);
              });
          },
        },
      });
    },
    removeArrayItemBy(array, object, key) {
      const index = array.findIndex((item) => item[key] === object[key]);
      if (index !== -1) {
        array.splice(index, 1);
      }
    },
    sortPosts() {
      this.activePosts = [];
      this.expiredPosts = [];

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
  },
};
</script>