<template>
  <div class="card shadow flex direction-column">
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
      <div v-for="user in takenPassengers" :key="user.userId">
        <router-link :to="{ name: 'user', params: { id: user.userId } }">
          <Avatar :path="user.picturePath" class="mr-20" />
        </router-link>
      </div>
    </div>

    <div class="flex align-baseline">
      <small>Keleiviai, laukiantys patvirtinimo</small>
      <div v-for="user in pendingPassengers" :key="user.userId">
        <router-link :to="{ name: 'user', params: { id: user.userId } }">
          <Avatar :path="user.picturePath" class="mr-20" />
        </router-link>
      </div>
    </div>

    <div class="flex justify-end mt-50">
      <Button
        text="ištrinti skelbimą"
        :click="deletePost"
        :isOutlined="true"
        :isSecondary="true"
        class="mr-20"
      />
      <Button
        text="atšaukti visus keleivius"
        :click="deleteAllReservations"
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

export default {
  name: 'DriverActivePostCard',
  props: ['post'],
  components: {
    Avatar,
    Button,
  },
  data() {
    return {
      pendingPassengers: [],
      takenPassengers: [],
    };
  },
  created() {
    this.DateFormat = DateFormat;
    this.sortPassengers();
  },
  computed: {
    user() {
      return this.$store.getters.getUser;
    },
  },
  methods: {
    deleteAllReservations() {
      return Service.getPostById(this.post.id)
        .then((response) => {
          if (response.status === 200) {
            const reservations = response.data.passengers;
            if (reservations) {
              const promises = reservations.map((reservation) => {
                return Service.deleteReservation(reservation).catch((error) => {
                  console.log('Could not delete reservatins', error);
                });
              });
              Promise.all(promises).then(() => {
                this.pendingPassengers = [];
                this.takenPassengers = [];
              });
            }
          }
        })
        .catch((error) => {
          console.log('Could not get post by ID', error);
        });
    },
    deletePost() {
      this.$emit('on-post-delete', this.post);
    },
    pushPassengers(userId, array) {
      Service.getUserById(userId)
        .then((response) => {
          if (response.status === 200) {
            array.push(response.data);
          }
        })
        .catch((error) => {
          console.log('Could not get all comments', error);
        });
    },
    sortPassengers() {
      Service.getPostById(this.post.id)
        .then((response) => {
          if (response.status === 200) {
            const passengers = response.data.passengers;
            if (!passengers) {
              return;
            }

            passengers.forEach((passenger) => {
              let array;
              if (passenger.status === 'PENDING') {
                array = this.pendingPassengers;
              } else if (passenger.status === 'TAKEN') {
                array = this.takenPassengers;
              }
              this.pushPassengers(passenger.passengerId, array);
            });
          }
        })
        .catch((error) => {
          console.log('Could not get post by ID', error);
        });
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