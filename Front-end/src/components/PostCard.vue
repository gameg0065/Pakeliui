<template>
  <div class="card shadow post-card">
    <div class="column center user">
      <Avatar :path="driver.photo" />
      <div class="rating">
        <img src="../assets/icons/star.svg" alt="star" />
        <small>{{ driver.driver.rating }} / 5</small>
      </div>
    </div>
    <div class="column">
      <router-link :to="{ name: 'post', params: { id: post.id } }">
        <h4>{{ post.route.from + ' - ' + post.route.to }}</h4>
      </router-link>
      <p>{{ post.date + ', ' + post.time }}</p>
      <small>{{ driver.name }}</small>
      <p>Laisvų vietų: {{ post.seetCount - post.passengers.length }}</p>
    </div>

    <div class="right">
      <p v-if="hasExpired()" class="danger">NEBEGALIOJANTIS</p>

      <div v-if="isPending" class="right">
        <p class="request-status">LAUKIAMA PATVIRTINIMO</p>
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
import UserService from '@/services/UserService.js';

export default {
  name: 'PostCard',
  props: {
    isPending: Boolean,
    post: Object,
  },
  components: {
    Avatar,
    Button,
  },
  data() {
    return {
      driver: Object,
    };
  },
  created() {
    this.driver = UserService.getUser(this.post.driver.id);
  },
  methods: {
    cancelReservation() {
      const modal = this.$modal;
      modal.show('modal-messaging', {
        title: 'Rezervacijos atšaukimas',
        text:
          'Ar tikrai norite atšaukti rezervaciją? Mes apie tai informuosime vairuotoją. Žemiau esančiame laukelyje palikite žinutę vairuotojui.',
        button: {
          title: 'atšaukti rezervaciją',
          action(data) {
            alert('TODO');
            modal.hide('modal-messaging');
          },
        },
      });
    },
    hasExpired() {
      const now = new Date();
      const postDate = new Date(this.post.date);

      return now.getTime() >= postDate.getTime();
    },
  },
};
</script>

<style lang="scss">
@import '../assets/styles/card.scss';
@import '../assets/styles/post-card.scss';
</style>
