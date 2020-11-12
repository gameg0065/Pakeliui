<template>
  <div>
    <h2>Profilis #{{ id }}</h2>
    <Avatar :path="user.photo" size="big" />
    <div>
      <small>Vardas, pavardė</small>
      <p>{{ user.name }}</p>
    </div>

    <div>
      <small>Registracijos data</small>
      <p>{{ user.registrationDate }}</p>
    </div>

    <div>
      <small>Buvo prisijungęs</small>
      <p>TODO</p>
    </div>

    <div>
      <small>Kelionių skaičius</small>
      <p>{{ user.trips.length }}</p>
    </div>

    <div>
      <small>Nukeliauta kilometrų</small>
      <p>{{ countDistance(this.user.trips) + ' km'}}</p>
    </div>

    <div>
      <small>Įvertinimas</small>
      <Rating :rating="user.rating" />
    </div>

    <div>
      <small>Preferencijos</small>
      <p>TODO</p>
    </div>

    <div>
      <small>Apie name</small>
      <p>{{ user.about }}</p>
    </div>

    <div>
      <small>Miestas</small>
      <p>{{ user.contacts.city }}</p>
    </div>

    <div>
      <small>Elektroninis paštas</small>
      <p>{{ user.contacts.email }}</p>
    </div>

    <div>
      <small>Telefono numeris</small>
      <p>{{ user.contacts.phone }}</p>
    </div>

    <div>
      <small>Facebook'as</small>
      <p>{{ user.contacts.facebook }}</p>
    </div>

    <div v-if="user.isDriver">
      <h3>Vairuotojo profilis</h3>
      <Avatar :path="user.driver.car.photo" size="big" />

      <div>
        <small>Pavežimų skaičius</small>
        <p>{{ user.driver.posts.length }}</p>
      </div>

      <div>
        <small>Pavežta kilometrų</small>
        <p>{{ countDistance(this.user.driver.posts) + ' km'}}</p>
      </div>

      <div>
        <small>Pavežta keleivių</small>
        <p>{{ countPassangers() }}</p>
      </div>

      <div>
        <small>Vairuotojo įvertinimas</small>
        <Rating :rating="user.driver.rating" />
      </div>

      <div>
        <small>Transporto priemonė</small>
        <p>{{ user.driver.car.model }}</p>
      </div>

      <div>
        <small>Pagaminimo metai</small>
        <p>{{ user.driver.car.date }}</p>
      </div>

      <div>
        <small>Susisiek su manim</small>
        <p>{{ user.contacts[user.driver.contact] }}</p>
      </div>

      <div>
        <small>Kaip aš vairuoju</small>
        <p>{{ user.driver.about }}</p>
      </div>
    </div>

    <div
      v-if="
        user.feedbacks &&
          user.feedbacks.received &&
          user.feedbacks.received.length > 0
      "
    >
      <h3>Atsiliepimai apie mane kaip keleivį</h3>

      <CommentCard
        v-for="feedback in getFeedbacks(user.feedbacks.received)"
        :key="feedback.id"
        :comment="feedback"
      />
    </div>
    <div
      v-if="
        user.driver.feedbacks &&
          user.driver.feedbacks.received &&
          user.driver.feedbacks.received.length > 0
      "
    >
      <h3>Atsiliepimai apie mane kaip vairuotoją</h3>
      <CommentCard
        v-for="feedback in getFeedbacks(user.driver.feedbacks.received)"
        :key="feedback.id"
        :comment="feedback"
      />
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
  props: ['id'],
  components: {
    Avatar,
    Rating,
    CommentCard
  },
  data() {
    return {
      user: Object
    };
  },
  created() {
    const id = parseInt(this.id);
    this.user = UserService.getUser(id);
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
      return feedbacks.map(function(feedback) {
        return FeedbackService.getFeedback(feedback.id);
      });
    }
  }
};
</script>