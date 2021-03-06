<template>
  <div class="post align-stretch">
    <div class="page-title flex align-baseline">
      <h2>Skelbimas</h2>
      <h5 v-if="isActive" class="text-color-primary">
        Skelbimo būsena: aktyvus
      </h5>
      <h5 v-else class="text-color-secondary">
        Skelbimo būsena: nebegaliojantis
      </h5>
    </div>

    <div class="flex direction-column pb-50">
      <UserCardInPost v-if="!isLoading" :post="post" />
      <Button
        text="rezervuoti"
        :click="reserve"
        :isDisabled="!isActive || userIsAuthor || carIsFull()"
        :isOutlined="true"
        class="align-self-center"
      />
    </div>

    <div class="flex">
      <div class="flex direction-column grow">
        <div class="flex align-baseline">
          <small class="fixed-width">Kelionės data</small>
          <p>{{ DateFormat.getYearMonthDate(post.date) }}</p>
        </div>
        <div class="flex align-baseline">
          <small class="fixed-width">Kelionės laikas</small>
          <p>{{ DateFormat.getHoursMinutes(post.time) }}</p>
        </div>
        <div class="flex align-baseline">
          <small class="fixed-width">Iš miesto</small>
          <p>{{ post.travelFrom }}</p>
        </div>
        <div v-if="post.pickup" class="flex align-baseline">
          <small class="fixed-width">Paėmimo vieta</small>
          <p>{{ post.pickup }}</p>
        </div>
        <div class="flex align-baseline">
          <small class="fixed-width">Į miestą</small>
          <p>{{ post.travelTo }}</p>
        </div>
        <div v-if="post.dropoff" class="flex align-baseline">
          <small class="fixed-width">Pristatymo vieta</small>
          <p>{{ post.dropoff }}</p>
        </div>
        <div v-if="post.intermediateCities" class="flex align-baseline">
          <small class="fixed-width">Tarpiniai miestai</small>
          <p>{{ post.intermediateCities }}</p>
        </div>
        <div class="flex align-baseline">
          <small class="fixed-width">Galimas keleivių skaičius</small>
          <p>{{ post.seetCount }}</p>
        </div>
        <!-- <div>
        <small>Laisvų vietų skaičius</small>
        <p>TODO</p>
      </div> -->
        <div class="flex align-baseline">
          <small class="fixed-width">Kelionės kaina</small>
          <p>{{ post.price }}€</p>
        </div>

        <div class="flex align-baseline">
          <small class="fixed-width">Maršruto ilgis</small>
          <p>{{ distance || 'skaičiuoju' }} Km</p>
        </div>

        <div class="flex align-baseline">
          <small class="fixed-width">Kelionės trukmė</small>
          <p>{{ duration || 'skaičiuoju' }}</p>
        </div>

        <div
          v-if="!isLoading && takenUsers.length > 0"
          class="flex align-baseline"
        >
          <small class="fixed-width align-self-center"
            >Patvirtinti keleiviai</small
          >
          <div v-for="takenUser in takenUsers" :key="takenUser.userId">
            <router-link
              :to="{ name: 'user', params: { id: takenUser.userId } }"
            >
              <Avatar
                :path="takenUser.picturePath"
                size="small"
                class="mr-10"
              />
            </router-link>
          </div>
        </div>

        <div
          v-if="!isLoading && pendingUsers.length > 0"
          class="flex align-baseline"
        >
          <small class="fixed-width align-self-center"
            >Nepatvirtinti keleiviai</small
          >
          <div v-for="pendingUser in pendingUsers" :key="pendingUser.userId">
            <router-link
              :to="{ name: 'user', params: { id: pendingUser.userId } }"
            >
              <Avatar
                :path="pendingUser.picturePath"
                size="small"
                class="mr-10"
              />
            </router-link>
          </div>
        </div>

        <div v-if="post.info" class="flex align-baseline">
          <small class="fixed-width">Papildoma informacija</small>
          <p>{{ post.info }}</p>
        </div>
      </div>
      <Map
        v-if="!isLoading"
        :cities="cities"
        @on-distance-calculated="onDistanceCalculated"
        class="mb-10"
      />
    </div>

    <Button
      text="rezervuoti"
      :click="reserve"
      :isDisabled="!isActive || userIsAuthor || carIsFull()"
      :isLarge="true"
      class="mb-50"
    />

    <div class="bleed-width pb-50">
      <Comments
        :isActive="isActive"
        :post="post"
        :user="user"
        @on-comment-submit="loadPost"
      />
    </div>
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
import Button from '@/components/Button.vue';
import Comments from '@/components/Comments.vue';
import Map from '@/components/Map.vue';
import UserCardInPost from '@/components/UserCardInPost.vue';

import DateFormat from '@/assets/DateFormat.js';
import Service from '@/services/Service';

export default {
  name: 'Post',
  props: ['id'],
  components: {
    Avatar,
    Button,
    Comments,
    Map,
    UserCardInPost,
  },
  data() {
    return {
      cities: [],
      distance: 0,
      duration: '',
      isLoading: true,
      post: {},
      pendingUsers: [],
      takenUsers: [],
    };
  },
  computed: {
    isActive() {
      const now = new Date();
      const postDate = new Date(this.post.date);
      return postDate.getTime() >= now.getTime();
    },
    user() {
      return this.$store.getters.getUser;
    },
    userIsAuthor() {
      return this.user ? this.post.user.userId === this.user.userId : false;
    },
  },
  created() {
    this.DateFormat = DateFormat;
    this.loadPost();
  },
  methods: {
    carIsFull() {
      return this.post.seetCount <= this.takenUsers.length;
    },
    loadPost() {
      this.isLoading = true;
      Service.getPostById(parseInt(this.id))
        .then((response) => {
          this.post = response.data;
        })
        .then(() => {
          this.parseCities();
        })
        .then(() => {
          this.parseUsers();
          this.isLoading = false;
        })
        .catch((error) => {
          console.log('Could not get Post with ID ' + this.id, error);
        });
    },
    onDistanceCalculated(distance, duration) {
      this.distance = parseInt(distance / 1000);
      this.duration = DateFormat.toHHMMSS(duration);
    },
    parseCities() {
      const post = this.post;
      this.cities = [post.travelFrom];

      const intermediateCities = post.intermediateCities;
      if (intermediateCities) {
        const citiesArray = intermediateCities.split(',').map((item) => {
          return item.trim();
        });
        this.cities = this.cities.concat(citiesArray);
      }
      this.cities.push(post.travelTo);
    },
    parseUsers() {
      const passengers = this.post.passengers;
      if (passengers) {
        this.pendingUsers = [];
        this.takenUsers = [];

        passengers.forEach((passenger) => {
          const passengerId = passenger.passengerId;
          if (passenger.status === 'TAKEN') {
            this.pushUserToArray(passengerId, this.takenUsers);
          } else if (passenger.status === 'PENDING') {
            this.pushUserToArray(passengerId, this.pendingUsers);
          }
        });
      }
    },
    pushUserToArray(userId, array) {
      Service.getUserById(userId)
        .then((response) => {
          if (response.status === 200) {
            array.push(response.data);
          }
        })
        .catch((error) => {
          console.log('Could not get user by ID', error);
        });
    },
    reserve() {
      if (!this.post.passengers) {
        this.post.passengers = [];
      }

      let reservation = this.post.passengers.find((passenger) => {
        return passenger.passengerId === this.user.userId;
      });

      if (reservation) {
        let message;
        const status = reservation.status;

        if (status === 'PENDING') {
          message =
            'Jūs jau rezervavote šią kelionę. Palaukite kol vairuotojas ją patvirtins.';
        } else if (status === 'TAKEN') {
          message = 'Jūs jau dalyvaujate šioje kelionėje';
        }

        this.showMessage(message, 'Gerai, palauksiu');
      } else {
        reservation = {
          passengerId: this.user.userId,
          postId: this.post.id,
          status: 'PENDING',
        };

        Service.postReservation(reservation)
          .then((response) => {
            if (response.status === 200) {
              this.showMessage('Rezervacijos užklausa išsiųsta vairuotojui');
              this.loadPost();
            }
          })
          .catch((error) => {
            console.log('Could not get all reservations', error);
          });
      }
    },
    showMessage(text, buttonTitle) {
      const modal = this.$modal;
      modal.show('modal-notification', {
        title: 'Kelionės rezervacija',
        text: text,
        button: {
          title: buttonTitle || 'Gerai',
          action(data) {
            modal.hide('modal-notification');
          },
        },
      });
    },
  },
};
</script>


<style lang="scss">
@import '../assets/styles/post.scss';
</style>