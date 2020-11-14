<template>
  <div class="card shadow">
    <div>
      <small>Kelionės data</small>
      <p>{{ post.date }}</p>
    </div>

    <div>
      <small>Kelionės laikas</small>
      <p>{{ post.time }}</p>
    </div>

    <div>
      <small>Iš miesto</small>
      <p>{{ post.route.from }}</p>
    </div>

    <div>
      <small>Paėmimo vieta</small>
      <p>{{ post.route.pickup }}</p>
    </div>

    <div>
      <small>Į miestą</small>
      <p>{{ post.route.to }}</p>
    </div>

    <div>
      <small>Pristatymo vieta</small>
      <p>{{ post.route.dropoff }}</p>
    </div>

    <div>
      <small>Kiek gali paimti keleivių</small>
      <p>{{ post.seetCount }}</p>
    </div>

    <div>
      <small>Patvirtinti keleiviai</small>
      <Avatar
        v-for="user in getApprovedPassengers(post, 'TAKEN')"
        :key="user.id"
        :path="user.photo"
      />
    </div>

    <div>
      <small>Keleiviai, laukiantys patvirtinimo</small>
      <Avatar
        v-for="user in getApprovedPassengers(post, 'PENDING')"
        :key="user.id"
        :path="user.photo"
      />
    </div>

    <Button text="peržiūrėti skelbimą" :isOutlined="true" />
    <Button text="ištrinti" :isOutlined="true" :isSecondary="true" />

    <router-link :to="{ name: 'post-edit', params: { postedit: post } }">
      <Button text="redaguoti" :isOutlined="true" />
    </router-link>
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
import Button from '@/components/Button.vue';

import UserService from '@/services/UserService.js';

export default {
  props: ['post'],
  components: {
    Avatar,
    Button,
  },
  methods: {
    getApprovedPassengers(post, status) {
      const users = [];

      post.passengers.forEach(function (passenger) {
        if (passenger.status === status) {
          const user = UserService.getUser(passenger.id);
          users.push(user);
        }
      });

      return users;
    },
  },
};
</script>