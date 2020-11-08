<template>
  <router-link :to="{ name: 'post', params: { id: post.id } }">
    <div class="card shadow">
      <div>
        <Avatar :path="driver.photo" />
        <img src="../assets/icons/star.svg" alt="star" />
        <small>{{ driver.driver.rating }} / 5</small>
      </div>
      <div>
        <h4>{{ post.title }}</h4>
        <p>{{ post.date + ', ' + post.dayName + ' ' + post.time }}</p>
        <small>{{ driver.name }}</small>
        <p>Laisvų vietų: {{ post.seetCount - post.passengers.length }}</p>
      </div>

      <div v-if="!todo">
        <p class="request-status">PENDING</p>
        <Button
          text="Atšaukti rezervaciją"
          :isSecondary="true"
          :isOutlined="true"
        />
      </div>
    </div>
  </router-link>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
import Button from '@/components/Button.vue';
import UserService from '@/services/UserService.js';

export default {
  props: {
    post: Object
  },
  components: {
    Avatar,
    Button
  },
  data() {
    return {
      driver: Object,
      todo: true
    };
  },
  created() {
    this.driver = UserService.getUser(this.post.driver.id);
  }
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
</style>