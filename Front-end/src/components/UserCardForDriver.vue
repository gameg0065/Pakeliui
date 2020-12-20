<template>
  <div class="card shadow flex direction-column">
    <div class="flex">
      <Avatar :path="user.picturePath" class="mr-20" />

      <div class="flex direction-column grow">
        <router-link :to="{ name: 'user', params: { id: user.userId || 0 } }">
          <h4 class="text-color-primary mb-10">{{ user.name }}</h4>
        </router-link>

        <small> Kelionių skaičius: {{ userTrips.length }} </small>
        <p>Susisiekite su manimi: {{ user[user.contactMethod] }}</p>
      </div>

    </div>
    <router-link :to="{ name: 'post', params: { id: post.id } }">
      <Button text="atidaryti skelbimą" :isOutlined="true" class="mt-10" />
    </router-link>
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
import Button from '@/components/Button.vue';

import Service from '@/services/Service';

export default {
  name: 'UserCardForDriver',
  props: ['passengerID', 'post'],
  components: {
    Avatar,
    Button,
  },
  data() {
    return {
      user: Object,
      userTrips: [],
    };
  },
  created() {
    this.getUser(this.passengerID);
    this.getUserTrips(this.passengerID);
  },
  methods: {
    getUser(userId) {
      Service.getUserById(userId)
        .then((response) => {
          if (response.status === 200) {
            this.user = response.data;
          }
        })
        .catch((error) => {
          console.log('Could not getUserById', error);
        });
    },
    getUserTrips(userId) {
      Service.getPostsByPassengerId(userId)
        .then((response) => {
          if (response.status === 200) {
            this.userTrips = response.data;
          }
        })
        .catch((error) => {
          console.log('Could not getPostsByPassengerId', error);
        });
    },
  },
};
</script>