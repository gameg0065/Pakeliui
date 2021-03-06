<template>
  <div class="align-stretch">
    <h2 class="page-title">Rezervacijos, laukiančios patvirtinimo</h2>
    <div v-if="pendingPosts.length > 0">
      <div v-for="post in pendingPosts" :key="post.id">
        <div
          v-for="reservation in post.passengers"
          :key="reservation.passengerId"
        >
          <div v-if="reservation.status === 'PENDING'">
            <UserCardForDriver
              :passengerID="reservation.passengerId"
              :post="post"
            />

            <div class="flex justify-center">
              <Button
                text="atmesti"
                @click.native.prevent="dismiss(reservation)"
                :isOutlined="true"
                :isSecondary="true"
                aaaaaa="aaaaaa"
                class="mr-20"
              />
              <Button
                text="patvirtinti"
                @click.native.prevent="approve(reservation, post)"
                :isOutlined="true"
              />
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

import Service from '@/services/Service';
import Utils from '@/assets/Utils.js';

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
    this.getDriverPostsWithPendingPassengers();
  },
  methods: {
    approve(reservation, post) {
      const modal = this.$modal;

      if (Utils.isCarFull(post)) {
        modal.show('modal-notification', {
          title: 'Rezervacijos patvirtinimas',
          text: 'Sorry, automobilyje nebėra laisvų vietų',
          button: {
            title: 'O tai tau!',
            action(data) {
              modal.hide('modal-notification');
            },
          },
        });
      } else {
        reservation.status = 'TAKEN';
        Service.putReservation(reservation)
          .then((response) => {
            if (response.status === 200) {
              this.getDriverPostsWithPendingPassengers().then(() => {
                modal.show('modal-notification', {
                  title: 'Rezervacijos patvirtinimas',
                  text: 'Rezervacija sėkmingai patvirtinta',
                  button: {
                    title: 'Valio!',
                    action(data) {
                      modal.hide('modal-notification');
                    },
                  },
                });
              });
            }
          })
          .catch((error) => {
            console.log('Could not put reservation', error);
          });
      }
    },
    dismiss(reservation) {
      const modal = this.$modal;
      const reloadPosts = this.getDriverPostsWithPendingPassengers;

      modal.show('modal-notification', {
        title: 'Rezervacijos atmetimas',
        text: 'Ar tikrai norite atšaukti vartotojo rezervaciją?',
        button: {
          title: 'Žinoma',
          action(data) {
            Service.deleteReservation(reservation)
              .then((response) => {
                reloadPosts().then(() => {
                  modal.hide('modal-notification');
                });
              })
              .catch((error) => {
                console.log('Could not remove reservation', error);
              });
          },
        },
      });
    },
    getDriverPostsWithPendingPassengers() {
      this.pendingPosts = [];
      return Service.getPostsByAuthorId(this.user.userId)
        .then((response) => {
          if (response.status === 200) {
            response.data.forEach((post) => {
              const passengers = post.passengers;
              if (passengers && this.containsPendingPassengers(passengers)) {
                this.pendingPosts.push(post);
              }
            });
          }
        })
        .catch((error) => {
          console.log('Could not get all posts', error);
        });
    },
    containsPendingPassengers(array, key, value) {
      return array.some((item) => item.status === 'PENDING');
    },
  },
};
</script>