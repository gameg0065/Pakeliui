<template>
  <div class="card shadow flex direction-column">
    TODO
    <router-link :to="{ name: 'post', params: { id: post.id } }">
      <h4 class="text-color-primary mb-10">
        {{ post.travelFrom + ' - ' + post.travelTo }}
      </h4>
    </router-link>

    <div class="flex align-baseline">
      <small>Kelionės data</small>
      <p>{{ DateFormat.getYearMonthDate(post.date) }}</p>
    </div>

    <div class="flex align-baseline">
      <small>Kelionės laikas</small>
      <p>{{ DateFormat.getHoursMinutes(post.time) }}</p>
    </div>

    <div class="flex align-baseline">
      <small>Iš miesto</small>
      <p>{{ post.travelFrom }}</p>
    </div>

    <div class="flex align-baseline">
      <small>Paėmimo vieta</small>
      <p>{{ post.pickup }}</p>
    </div>

    <div class="flex align-baseline">
      <small>Į miestą</small>
      <p>{{ post.travelTo }}</p>
    </div>

    <div class="flex align-baseline">
      <small>Pristatymo vieta</small>
      <p>{{ post.dropoff }}</p>
    </div>

    <div class="flex align-baseline">
      <small>Galimas keleivių skaičius</small>
      <p>{{ post.seetCount }}</p>
    </div>

    <div class="flex align-baseline">
      <small>Patvirtinti keleiviai</small>
      <div v-for="user in getApprovedPassengers('TAKEN')" :key="user.userId">
        <router-link :to="{ name: 'user', params: { id: user.userId } }">
          <Avatar :path="user.picturePath" />
        </router-link>
      </div>
    </div>

    <div class="flex align-baseline">
      <small>Keleiviai, laukiantys patvirtinimo</small>
      <div v-for="user in getApprovedPassengers('PENDING')" :key="user.userId">
        <router-link :to="{ name: 'user', params: { id: user.userId } }">
          <Avatar :path="user.picturePath" />
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

import DateFormat from '@/assets/DateFormat.js';
import Service from '@/services/Service';
// import UserService from '@/services/UserService.js';

export default {
  name: 'DriverActivePostCard',
  props: ['post'],
  components: {
    Avatar,
    Button,
  },
  created() {
    this.DateFormat = DateFormat;
  },
  methods: {
    deletePost() {
      const post = this.post;
      this.$modal.show('modal-notification', {
        title: 'Patvirtinimas',
        text: 'Ar tikrai norite ištrinti skelbimą? Kelio atgal nėra.',
        button: {
          title: 'ištrinti',
          action() {
            Service.deletePost(post)
              .then(() => {
                alert(
                  'post deleted (you need to logoff/logon to see the effect)'
                );
                this.$modal.hide('modal-notification');
              })
              .catch((error) => {
                console.log('Could not delete post', error);
              });
          },
        },
      });
    },
    getApprovedPassengers(status) {
      const passengers = this.post.passengers;
      const users = [];

      if (passengers) {
        passengers.forEach((passenger) => {
          if (passenger.status === status) {
            // TODO
            // Need Users.getUserById() endpoint:
            // const user = UserService.getUser(passenger.id);
            // users.push(user);
          }
        });
      }

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