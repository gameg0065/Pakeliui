<template>
  <div class="align-stretch">
    <div class="pb-50">
      <h2 class="page-title">Mano rezervacijos</h2>
      <div v-if="futurePosts && futurePosts.length > 0">
        <PostCard
          v-for="post in futurePosts"
          :key="post.id"
          :post="post"
          @on-cancel-reservation="onCancelReservation"
        />
      </div>

      <div v-else class="flex direction-column align-center">
        <p>
          Jūs neturite rezervuotų kelionių. Rezervuokite vieną peržiūrėdami
          skelbimus.
        </p>
        <router-link :to="{ name: 'posts' }">
          <Button
            text="skelbimai"
            class="mt-20"
            :isSecondary="true"
            :isLarge="true"
          />
        </router-link>
      </div>
    </div>
    <div class="bleed-width">
      <h3 class="section-title">Rezervacijų istorija</h3>
      <div v-if="expiredPosts && expiredPosts.length > 0">
        <FeedbackCard
          v-for="post in expiredPosts"
          :key="post.id"
          :post="post"
        />
      </div>
      <p v-else>Istorija tuščia</p>
    </div>
  </div>
</template>

<script>
import Button from '@/components/Button.vue';
import FeedbackCard from '@/components/FeedbackCard.vue';
import PostCard from '@/components/PostCard.vue';

import Service from '@/services/Service';

export default {
  name: 'UserHistory',
  components: {
    Button,
    FeedbackCard,
    PostCard,
  },
  computed: {
    user() {
      return this.$store.getters.getUser;
    },
  },
  data() {
    return {
      expiredPosts: [],
      futurePosts: [],
    };
  },
  created() {
    this.loadPosts();
  },
  methods: {
    loadPosts() {
      this.expiredPosts = [];
      this.futurePosts = [];

      const now = new Date();

      Service.getPostsByPassengerId(this.user.userId)
        .then((response) => {
          if (response.status === 200) {
            const posts = response.data;
            posts.forEach((post) => {
              const postDate = new Date(post.date);
              if (postDate.getTime() >= now.getTime()) {
                this.futurePosts.push(post);
              } else {
                this.expiredPosts.push(post);
              }
            });
          }
        })
        .catch((error) => {
          console.log('Could not get posts by passenger ID', error);
        });
    },
    onCancelReservation(post, reservation) {
      this.loadPosts();
    },
  },
};
</script>