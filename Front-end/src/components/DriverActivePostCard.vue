<template>
  <div class="card shadow flex direction-column">
    <router-link :to="{ name: 'post', params: { id: post.id } }">
      <h4 class="text-color-primary">
        {{ post.route.from + ' - ' + post.route.to }}
      </h4>
    </router-link>

    <div class="flex align-baseline">
      <small>Kelionės data</small>
      <p>{{ post.date }}</p>
    </div>

    <div class="flex align-baseline">
      <small>Kelionės laikas</small>
      <p>{{ post.time }}</p>
    </div>

    <div class="flex align-baseline">
      <small>Iš miesto</small>
      <p>{{ post.route.from }}</p>
    </div>

    <div class="flex align-baseline">
      <small>Paėmimo vieta</small>
      <p>{{ post.route.pickup }}</p>
    </div>

    <div class="flex align-baseline">
      <small>Į miestą</small>
      <p>{{ post.route.to }}</p>
    </div>

    <div class="flex align-baseline">
      <small>Pristatymo vieta</small>
      <p>{{ post.route.dropoff }}</p>
    </div>

    <div class="flex align-baseline">
      <small>Galimas keleivių skaičius</small>
      <p>{{ post.seetCount }}</p>
    </div>

    <div class="flex align-baseline">
      <small>Patvirtinti keleiviai</small>
      <div v-for="user in getApprovedPassengers(post, 'TAKEN')" :key="user.id">
        <router-link :to="{ name: 'user', params: { id: user.id } }">
          <Avatar :path="user.photo" />
        </router-link>
      </div>
    </div>

    <div class="flex align-baseline">
      <small>Keleiviai, laukiantys patvirtinimo</small>
      <div
        v-for="user in getApprovedPassengers(post, 'PENDING')"
        :key="user.id"
      >
        <router-link :to="{ name: 'user', params: { id: user.id } }">
          <Avatar :path="user.photo" />
        </router-link>
      </div>
    </div>

    <div class="flex justify-end mt-50">
      <Button
        text="ištrinti"
        :click="deletePost"
        :isOutlined="true"
        :isSecondary="true"
        class="mr-20"
      />

      <router-link :to="{ name: 'post-edit', params: { id: post.id } }">
        <Button text="redaguoti" :isOutlined="true" />
      </router-link>
    </div>
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
import Button from '@/components/Button.vue';

import UserService from '@/services/UserService.js';

export default {
  name: 'DriverActivePostCard',
  props: ['post'],
  components: {
    Avatar,
    Button,
  },
  methods: {
    deletePost() {
      this.$modal.show('modal-notification', {
        title: 'Patvirtinimas',
        text: 'Ar tikrai norite ištrinti skelbimą? Kelio atgal nėra.',
        button: {
          title: 'ištrinti',
          action() {
            alert('TODO');
            this.$modal.hide('modal-notification');
          },
        },
      });
    },
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

<style lang="scss" scoped>
small {
  padding-right: 20px;
  text-align: right;
  width: 220px;
}
</style>