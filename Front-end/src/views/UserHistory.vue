<template>
  <div>
    <div>
      <h2>Mano rezervacijos</h2>
      <div v-if="user.trips.pending && user.trips.pending.length > 0">
        <PostCard
          v-for="post in getTrips('pending')"
          :key="post.id"
          :post="post"
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
      <h3>Rezervacijų istorija TODO</h3>
      <div v-if="user.trips.taken">
        <div v-for="post in getTrips('taken')" :key="post.id" :post="post">
          <router-link :to="{ name: 'post', params: { id: post.id } }">
            <p>{{ post.route.from + ' - ' + post.route.to }}</p>
          </router-link>
        </div>
      </div>
      <div v-else><p>Istorija tuščia</p></div>
    </div>
  </div>
</template>

<script>
import Button from '@/components/Button.vue';
import PostCard from '@/components/PostCard.vue';

import PostService from '@/services/PostService.js';
import UserService from '@/services/UserService.js';

import { mapGetters } from 'vuex';

export default {
  components: {
    Button,
    PostCard,
  },
  computed: {
    ...mapGetters(['isLoggedIn', 'isDriver', 'userID']),
  },
  data() {
    return {
      user: Object,
    };
  },
  created() {
    this.user = UserService.getUser(this.userID);
  },
  methods: {
    getTrips(type) {
      return this.user.trips[type].map(function (obj) {
        return PostService.getPost(obj.id);
      });
    },
  },
};
</script>