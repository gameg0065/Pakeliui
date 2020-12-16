<template>
  <div class="align-stretch">
    <h2 class="page-title">Rezervacijos, laukiančios patvirtinimo</h2>
    <div v-if="pendingPosts.length > 0">
      <div v-for="post in pendingPosts" :key="post.id">
        <div v-for="passenger in post.passengers" :key="passenger.passengerId">
          <div v-if="passenger.status === 'PENDING'">
            <UserCardForDriver :passengerID="passenger.passengerId" :post="post" />

            <div class="flex justify-center">
              <Button
                text="atmesti"
                :click="dismiss"
                :isOutlined="true"
                :isSecondary="true"
                class="mr-20"
              />
              <Button text="patvirtinti" :click="approve" :isOutlined="true" />
            </div>
          </div>
        </div>
      </div>
    </div>
    <div v-else>
      <p>Rezervacijų nėra</p>
    </div>
  </div>
</template>

<script>
import Button from '@/components/Button.vue';
import UserCardForDriver from '@/components/UserCardForDriver.vue';

import PostService from '@/services/PostService.js';
import UserService from '@/services/UserService.js';

export default {
  name: 'DriverRequests',
  components: {
    Button,
    UserCardForDriver,
  },
  computed: {
    user() {
      return this.$store.getters.getUser;
    },
  },
  data() {
    return {
      pendingPosts: [],
    };
  },
  created() {
    this.pendingPosts = this.getDriverPostsWithPassengersWithStatus('PENDING');
  },
  methods: {
    approve() {
      const modal = this.$modal;
      modal.show('modal-messaging', {
        title: 'Rezervacijos patvirtinimas',
        text: 'Žemiau esančiame laukelyje palikite žinutę keleiviui.',
        button: {
          title: 'patvirtinti',
          action(data) {
            alert('TODO');
            modal.hide('modal-messaging');
          },
        },
      });
    },
    dismiss() {
      const modal = this.$modal;
      modal.show('modal-messaging', {
        title: 'Rezervacijos atmetimas',
        text:
          'Ar tikrai norite atšaukti vartotojo rezervaciją? Mes apie tai informuosime vartotoją. Žemiau esančiame laukelyje palikite žinutę.',
        button: {
          title: 'atmesti',
          action(data) {
            alert('TODO');
            modal.hide('modal-messaging');
          },
        },
      });
    },
    getDriverPostsWithPassengersWithStatus(status) {
      return this.user.posts.reduce((accumulator, post) => {
        if (this.postHasPassengersWithStatus(post, status)) {
          accumulator.push(post);
        }
        return accumulator;
      }, []);
    },
    postHasPassengersWithStatus(post, status) {
      if (post.passengers) {
        return post.passengers.some((passenger) => {
          return passenger.status === status;
        });
      }
    },
  },
};
</script>