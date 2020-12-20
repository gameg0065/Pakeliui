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
                @click.native.prevent="approve(reservation)"
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
    approve(reservation) {
      reservation.status = 'TAKEN';

      Service.putReservation(reservation)
        .then((response) => {
          if (response.status === 200) {
            this.getDriverPostsWithPendingPassengers();

            const modal = this.$modal;
            modal.show('modal-notification', {
              title: 'Rezervacijos patvirtinimas',
              text: 'Rezervacija sėkmingai patvirtinta',
              button: {
                title: 'Nice!',
                action(data) {
                  modal.hide('modal-notification');
                },
              },
            });
          }
        })
        .catch((error) => {
          console.log('Could not put reservation', error);
        });
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
                reloadPosts();
                modal.hide('modal-notification');
              })
              .catch((error) => {
                console.log('Could not remove reservation', error);
              });
          },
        },
      });
    },
    getDriverPostsWithPendingPassengers() {
      Service.getAllPosts()
        .then((response) => {
          const posts = response.data;
          if (response.status === 200 && posts) {
            const userPosts = posts.filter((post) => {
              return post.userId === this.user.userId;
            });

            this.pendingPosts = userPosts.reduce((accumulator, post) => {
              if (
                post.passengers &&
                this.postHasPassengersWithStatus(post, 'PENDING')
              ) {
                accumulator.push(post);
              }
              return accumulator;
            }, []);
          }
        })
        .catch((error) => {
          console.log('Could not get all posts', error);
        });
    },
    postHasPassengersWithStatus(post, status) {
      return post.passengers.some((passenger) => {
        return passenger.status === status;
      });
    },
  },
};
</script>