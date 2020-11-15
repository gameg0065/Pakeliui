<template>
  <div class="card shadow">
    <div>
      <Avatar :path="driver.photo" />
      <img src="../assets/icons/star.svg" alt="star" />
      <small>{{ driver.driver.rating }} / 5</small>
    </div>
    <div>
      <router-link :to="{ name: 'post', params: { id: post.id } }">
        <h4>{{ post.route.from + ' - ' + post.route.to }}</h4>
      </router-link>
      <p>{{ post.date + ', ' + post.time }}</p>
      <small>{{ driver.name }}</small>
      <p>Laisvų vietų: {{ post.seetCount - post.passengers.length }}</p>
    </div>

    <p v-if="hasExpired()" class="expired">EXPIRED</p>

    <div v-if="isPending">
      <p class="request-status">PENDING</p>
      <Button
        text="Atšaukti rezervaciją"
        :click="cancelReservation"
        :isSecondary="true"
        :isOutlined="true"
      />
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
      alert('TODO');
    },
    hasExpired() {
      const now = new Date();
      const postDate = new Date(this.post.date);

      return now.getTime() >= postDate.getTime();
    },
  },
};
</script>

<style scoped>
.card {
  transition: all 0.2s linear;
  margin: 20px;
  padding: 20px;
}

.card:hover {
  transform: scale(1.01);
}

.shadow {
  -webkit-box-shadow: 0px 4px 10px 0px rgba(0, 0, 0, 0.25); /* Safari 3-4, iOS 4.0.2 - 4.2, Android 2.3+ */
  -moz-box-shadow: 0px 4px 10px 0px rgba(0, 0, 0, 0.25); /* Firefox 3.5 - 3.6 */
  box-shadow: 0px 4px 10px 0px rgba(0, 0, 0, 0.25); /* Opera 10.5, IE 9, Firefox 4+, Chrome 6+, iOS 5 */
}

h4,
.request-status {
  color: var(--color-primary);
}

a {
  text-decoration: none;
}

p.expired {
  color: var(--color-secondary);
}
</style>