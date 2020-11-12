<template>
  <div>
    <div>
      <h2>Mano rezervacijos</h2>
      <div v-if="pendingTrips && pendingTrips.length > 0">
        <PostCard
          v-for="trip in pendingTrips"
          :key="trip.id"
          :post="getPost(trip.post.id)"
          :isReserved="true"
        />
      </div>
      <div v-else>
        <p>
          Jūs neturite rezervuotų kelionių. Rezervuokite vieną peržiūrėdami
          skelbimus
        </p>
        <router-link :to="{ name: 'posts' }">
          <Button text="skelbimai" :isSecondary="true" :isLarge="true" />
        </router-link>
      </div>
    </div>
    <div>
      <h3>Rezervacijų istorija</h3>
      <div v-if="nonPendingTrips && nonPendingTrips.length > 0">
        <FeedbackCard
          v-for="trip in nonPendingTrips"
          :key="trip.id"
          :trip="trip"
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

import PostService from '@/services/PostService.js';
import UserService from '@/services/UserService.js';

import { mapGetters } from 'vuex';

export default {
  components: {
    Button,
    FeedbackCard,
    PostCard,
  },
  computed: {
    ...mapGetters(['isLoggedIn', 'isDriver', 'userID']),
  },
  data() {
    return {
      nonPendingTrips: [],
      pendingTrips: [],
      user: Object,
    };
  },
  created() {
    this.user = UserService.getUser(this.userID);

    if (this.user.trips && this.user.trips.length > 0) {
      this.nonPendingTrips = this.user.trips.filter(
        (trip) => trip.status !== 'PENDING'
      );
      this.pendingTrips = this.user.trips.filter(
        (trip) => trip.status === 'PENDING'
      );
    }
  },
  methods: {
    getPost(id) {
      return PostService.getPost(id);
    },
  },
};
</script>