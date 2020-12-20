<template>
  <div class="card shadow flex">
    <div class="flex direction-column align-center mr-20">
      <Avatar :path="post.user.picturePath" />
      <!-- <div class="flex align-center pt-10">
        <img src="../assets/icons/star.svg" alt="star" class="mr-10"/>
        <small>{{ driver.driver.rating }} / 5</small>
      </div> -->
    </div>
    <div class="flex direction-column grow">
      <router-link :to="{ name: 'post', params: { id: post.id } }">
        <h4 class="text-color-primary mb-10">
          {{ post.travelFrom + ' - ' + post.travelTo }}
        </h4>
      </router-link>
      <p>
        {{ DateFormat.getYearMonthDate(post.date) + ', ' + DateFormat.getHoursMinutes(post.time) }}
      </p>
      <small>{{ post.user.name }}</small>
      <p>Laisvų vietų: {{ post.seetCount - post.passengers.length }}</p>
    </div>

    <div>
      <p v-if="hasExpired()" class="text-color-secondary">NEBEGALIOJANTIS</p>

      <div v-if="reservation" class="flex direction-column align-end">
        <p v-if="reservation.status === 'PENDING'" class="text-color-primary">
          LAUKIAMA PATVIRTINIMO
        </p>
        <p v-if="reservation.status === 'TAKEN'" class="text-color-primary">
          PATVIRTiNTA
        </p>
        <Button
          text="Atšaukti rezervaciją"
          :click="cancelReservation"
          :isSecondary="true"
          :isOutlined="true"
        />
      </div>
    </div>
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
import Button from '@/components/Button.vue';

import DateFormat from '@/assets/DateFormat.js';
import Service from '@/services/Service';

export default {
  name: 'PostCard',
  props: {
    post: Object,
  },
  components: {
    Avatar,
    Button,
  },
  data() {
    return {
      reservation: {},
    };
  },
  computed: {
    user() {
      return this.$store.getters.getUser;
    },
  },
  created() {
    this.DateFormat = DateFormat;

    if (this.post.passengers) {
      this.reservation = this.post.passengers.find((passenger) => {
        return passenger.passengerId === this.user.userId;
      });
    }
  },
  methods: {
    cancelReservation() {
      if (this.reservation) {
        Service.deleteReservation(this.reservation)
          .then((response) => {
            if (response.status === 200) {
              this.$emit('on-cancel-reservation', this.post, this.reservation);
            }
          })
          .catch((error) => {
            console.log('Could not remove reservation', error);
          });
      }
    },
    hasExpired() {
      const now = new Date();
      const postDate = new Date(this.post.date);

      return now.getTime() >= postDate.getTime();
    },
  },
};
</script>
