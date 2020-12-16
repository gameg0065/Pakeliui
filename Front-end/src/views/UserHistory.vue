<template>
  <div class="align-stretch">
    <div class="pb-50">
      <h2 class="page-title">Mano rezervacijos</h2>
      <div v-if="pendingTrips && pendingTrips.length > 0">
        TODO
        <!-- <PostCard
          v-for="trip in pendingTrips"
          :key="trip.id"
          :post="getPost(trip.post.id)"
          :isPending="true"
        /> -->
      </div>

      <div v-else class="flex direction-column align-center">
        <p>
          Jūs neturite rezervuotų kelionių. Rezervuokite vieną peržiūrėdami
          skelbimus
        </p>
        <router-link :to="{ name: 'posts' }">
          <Button
            text="skelbimai"
            :isSecondary="true"
            :isLarge="true"
          />
        </router-link>
      </div>
    </div>
    <div class="bleed-width">
      <h3 class="section-title">Rezervacijų istorija</h3>
      <div v-if="nonPendingTrips && nonPendingTrips.length > 0">
        <FeedbackCard
          v-for="post in nonPendingTrips"
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
// import PostCard from '@/components/PostCard.vue';

import PostService from '@/services/PostService.js';
import Service from '@/services/Service';

export default {
  name: 'UserHistory',
  components: {
    Button,
    FeedbackCard,
    // PostCard,
  },
  computed: {
    user() {
      return this.$store.getters.getUser;
    },
  },
  data() {
    return {
      nonPendingTrips: [],
      pendingTrips: [],
    };
  },
  created() {
    const nonPendingTrips = this.nonPendingTrips;
    const pendingTrips = this.pendingTrips;
    const userId = this.user.userId;

    Service.getPostsByPassengerId(userId)
      .then((response) => {
        const posts = response.data;
        posts.forEach((post) => {
          const passenger = post.passengers.find(
            (passenger) => passenger.passengerId === userId
          );
          if (passenger.status === 'PENDING') {
            pendingTrips.push(post);
          } else {
            nonPendingTrips.push(post);
          }
        });
      })
      .catch((error) => {
        console.log('Could not get posts by passenger ID ' + userId, error);
      });
  },
  methods: {
    getPost(id) {
      return PostService.getPost(id);
    },
  },
};
</script>