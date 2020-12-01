<template>
  <div class="user align-stretch">
    <h2 class="page-title">Profilis</h2>
    <div class="flex pb-50">
      <Avatar :path="user.photo" size="big" />
      <div>
        <div class="flex align-baseline">
          <small class="fixed-width">Vardas, pavardė</small>
          <p>{{ user.name }}</p>
        </div>

        <div class="flex align-baseline">
          <small class="fixed-width">Registracijos data</small>
          <p>{{ user.registrationDate }}</p>
        </div>

        <div class="flex align-baseline">
          <small class="fixed-width">Kelionių skaičius</small>
          <p>{{ user.trips.length }}</p>
        </div>

        <div class="flex align-baseline">
          <small class="fixed-width">Nukeliauta</small>
          <p>{{ countDistance(this.user.trips) + ' km' }}</p>
        </div>

        <div class="flex align-baseline">
          <small class="fixed-width">Įvertinimas</small>
          <Rating :rating="user.rating" />
        </div>

        <div class="flex align-baseline">
          <small class="fixed-width">Apie mane</small>
          <p>{{ user.about }}</p>
        </div>

        <div class="flex align-baseline">
          <small class="fixed-width">Miestas</small>
          <p>{{ user.contacts.city }}</p>
        </div>

        <div class="flex align-baseline">
          <small class="fixed-width">Elektroninis paštas</small>
          <p>{{ user.contacts.email }}</p>
        </div>

        <div class="flex align-baseline">
          <small class="fixed-width">Telefono numeris</small>
          <p>{{ user.contacts.phone }}</p>
        </div>

        <div class="flex align-baseline">
          <small class="fixed-width">Facebook paskyra</small>
          <p>{{ user.contacts.facebook }}</p>
        </div>
      </div>
    </div>

    <div v-if="user.isDriver">
      <h3 class="section-title">Vairuotojo profilis</h3>
      <div class="flex pb-50">
        <Avatar :path="user.driver.car.photo" size="big" />

        <div>
          <div class="flex align-baseline">
            <small class="fixed-width">Pavėžėjimų skaičius</small>
            <p>{{ user.driver.posts.length }}</p>
          </div>

          <div class="flex align-baseline">
            <small class="fixed-width">Nukeliauta</small>
            <p>{{ countDistance(this.user.driver.posts) + ' km' }}</p>
          </div>

          <div class="flex align-baseline">
            <small class="fixed-width">Pavėžėtų keleivių skaičius</small>
            <p>{{ countPassangers() }}</p>
          </div>

          <div class="flex align-baseline">
            <small class="fixed-width">Vairuotojo įvertinimas</small>
            <Rating :rating="user.driver.rating" />
          </div>

          <div class="flex align-baseline">
            <small class="fixed-width">Transporto priemonė</small>
            <p>{{ user.driver.car.model }}</p>
          </div>

          <div class="flex align-baseline">
            <small class="fixed-width">Pagaminimo metai</small>
            <p>{{ user.driver.car.date }}</p>
          </div>

          <div class="flex align-baseline">
            <small class="fixed-width">Susisiekite su manimi</small>
            <p>{{ user.contacts[user.driver.contactMethod] }}</p>
          </div>

          <div class="flex align-baseline">
            <small class="fixed-width">Vairavimo įgūdžiai</small>
            <p>{{ user.driver.about }}</p>
          </div>
        </div>
      </div>
    </div>

    <div
      v-if="
        user.feedbacks &&
        user.feedbacks.received &&
        user.feedbacks.received.length > 0
      "
    >
      <h3 class="section-title">Atsiliepimai apie mane kaip keleivį</h3>
      <div class="pb-50">
        <CommentCard
          v-for="feedback in getFeedbacks(user.feedbacks.received)"
          :key="feedback.id"
          :comment="feedback"
        />
      </div>
    </div>
    <div
      v-if="
        user.driver.feedbacks &&
        user.driver.feedbacks.received &&
        user.driver.feedbacks.received.length > 0
      "
    >
      <h3 class="section-title">Atsiliepimai apie mane kaip vairuotoją</h3>
      <div class="pb-50">
        <CommentCard
          v-for="feedback in getFeedbacks(user.driver.feedbacks.received)"
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
import Rating from '@/components/Rating.vue';

import FeedbackService from '@/services/FeedbackService.js';
import PostService from '@/services/PostService.js';
import UserService from '@/services/UserService.js';

export default {
  name: 'User',
  props: ['id'],
  components: {
    Avatar,
    CommentCard,
    Rating,
  },
  computed: {
    user() {
      const currentUser = this.$store.getters.getUser;
      const id = parseInt(this.id);
      return currentUser.id === id ? currentUser : UserService.getUser(id);
    },
  },
  methods: {
    countDistance(trips) {
      return trips.reduce((accumulator, trip) => {
        const post = PostService.getPost(trip.id);
        accumulator += post.distance;
        return accumulator;
      }, 0);
    },
    countDistanceAsDriver() {
      return this.user.driver.posts.reduce((accumulator, trip) => {
        const post = PostService.getPost(trip.id);
        accumulator += post.distance;
        return accumulator;
      }, 0);
    },
    countPassangers() {
      return this.user.driver.posts.reduce((accumulator, trip) => {
        const post = PostService.getPost(trip.id);
        accumulator += post.passengers.length;
        return accumulator;
      }, 0);
    },
    getFeedbacks(feedbacks) {
      return feedbacks.map((feedback) =>
        FeedbackService.getFeedback(feedback.id)
      );
    },
  },
};
</script>

<style lang="scss">
@import '../assets/styles/user.scss';
</style>