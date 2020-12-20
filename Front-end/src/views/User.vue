<template>
  <div class="user align-stretch">
    <h2 class="page-title">Profilis</h2>
    <div class="flex pb-50">
      <Avatar :path="user.picturePath" size="big" />

      <div>
        <div class="flex align-baseline">
          <small class="fixed-width">Vardas, pavardė</small>
          <p>{{ user.name }}</p>
        </div>

        <div class="flex align-baseline">
          <small class="fixed-width">Registracijos data</small>
          <p>{{ DateFormat.getYearMonthDate(user.registrationDate) }}</p>
        </div>

        <div class="flex align-baseline">
          <small class="fixed-width">Kelionių skaičius</small>
          <p>{{ userTrips.length }}</p>
        </div>

        <!-- <div class="flex align-baseline">
          <small class="fixed-width">Nukeliauta</small>
          <p> TODO ' km' </p>
        </div> -->

        <!-- <div class="flex align-baseline">
          <small class="fixed-width">Įvertinimas</small>
          <Rating TODO />
        </div> -->

        <div class="flex align-baseline">
          <small class="fixed-width">Apie mane</small>
          <p>{{ user.userInfo }}</p>
        </div>

        <div class="flex align-baseline">
          <small class="fixed-width">Miestas</small>
          <p>{{ user.city }}</p>
        </div>

        <div class="flex align-baseline">
          <small class="fixed-width">Elektroninis paštas</small>
          <p>{{ user.email }}</p>
        </div>

        <div class="flex align-baseline">
          <small class="fixed-width">Telefono numeris</small>
          <p>{{ user.phoneNumber }}</p>
        </div>

        <div class="flex align-baseline">
          <small class="fixed-width">Facebook paskyra</small>
          <p>{{ user.facebookLink }}</p>
        </div>
      </div>
    </div>

    <div v-if="user.isDriver">
      <h3 class="section-title">Vairuotojo profilis</h3>
      <div class="flex pb-50">
        <Avatar :path="user.car.picturePath" size="big" />

        <div>
          <div class="flex align-baseline">
            <small class="fixed-width">Pavėžėjimų skaičius</small>
            <p>{{ user.posts ? user.posts.length : 0 }}</p>
          </div>

          <!-- <div class="flex align-baseline">
            <small class="fixed-width">Nukeliauta</small>
            <p> TODO + ' km' </p>
          </div> -->

          <!-- <div class="flex align-baseline">
            <small class="fixed-width">Pavėžėtų keleivių skaičius</small>
            <p> TODO </p>
          </div> -->

          <!-- <div class="flex align-baseline">
            <small class="fixed-width">Vairuotojo įvertinimas</small>
            <Rating TODO />
          </div> -->

          <div class="flex align-baseline">
            <small class="fixed-width">Transporto priemonė</small>
            <p>{{ user.car.model }}</p>
          </div>

          <div class="flex align-baseline">
            <small class="fixed-width">Pagaminimo metai</small>
            <p>{{ DateFormat.getYearMonthDate(user.car.date) }}</p>
          </div>

          <div class="flex align-baseline">
            <small class="fixed-width">Susisiekite su manimi</small>
            <p>{{ user[user.driverContactMethod] }}</p>
          </div>

          <div class="flex align-baseline">
            <small class="fixed-width">Vairavimo įgūdžiai</small>
            <p>{{ user.aboutDriver }}</p>
          </div>
        </div>
      </div>
    </div>

    <div v-if="userFeedbacks && userFeedbacks > 0">
      <h3 class="section-title">Atsiliepimai apie mane kaip keleivį</h3>
      <div class="pb-50">
        <CommentCard
          v-for="feedback in userFeedbacks"
          :key="feedback.id"
          :comment="feedback"
        />
      </div>
    </div>

    <div v-if="driverFeedbacks && driverFeedbacks.length > 0">
      <h3 class="section-title">Atsiliepimai apie mane kaip vairuotoją</h3>
      <div class="pb-50">
        <CommentCard
          v-for="feedback in driverFeedbacks"
          :key="feedback.id"
          :comment="feedback"
        />
      </div>
    </div>
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
import CommentCard from '@/components/CommentCard.vue';

import DateFormat from '@/assets/DateFormat.js';
import Service from '@/services/Service';

export default {
  name: 'User',
  props: ['id'],
  components: {
    Avatar,
    CommentCard,
  },
  data() {
    return {
      user: {},
      userTrips: [],
      userFeedbacks: [],
      driverFeedbacks: [],
    };
  },
  computed: {
    currentUser() {
      return this.$store.getters.getUser;
    },
  },
  async created() {
    this.DateFormat = DateFormat;

    const userId = parseInt(this.id);
    if (this.currentUser.userId === userId) {
      this.user = this.currentUser;
    } else {
      await Service.getUserById(userId)
        .then((response) => {
          this.user = response.data;
        })
        .catch((error) => {
          console.log('Could not get user by ID', error);
        });
    }

    this.countUserTrips(this.user);
    this.loadFeedbacks(this.user);
  },
  methods: {
    countUserTrips(user) {
      Service.getPostsByPassengerId(user.userId)
        .then((response) => {
          if (response.status === 200) {
            this.userTrips = response.data;
          }
        })
        .catch((error) => {
          console.log('Could not get posts by passenger ID', error);
        });
    },
    loadFeedbacks(user) {
      Service.getAllFeedbacks(user.userId)
        .then((response) => {
          if (response.status === 200) {
            response.data.forEach((feedback) => {
              if (feedback.receiverId === user.userId) {
                if (feedback.receiverIsDriver) {
                  this.driverFeedbacks.push(feedback);
                } else {
                  this.userFeedbacks.push(feedback);
                }
              }
            });
          }
        })
        .catch((error) => {
          console.log('Could not get all feedbacks', error);
        });
    },
  },
};
</script>

<style lang="scss">
@import '../assets/styles/user.scss';
</style>