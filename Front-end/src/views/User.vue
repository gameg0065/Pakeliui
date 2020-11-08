<template>
  <div>
    <h1>this is USER # {{ id }} page</h1>
    <h1>this is USER # {{ typeof id }} page</h1>
    <Avatar :path="user.photo" size="big" />
    <p>{{ user.name }}</p>
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
import UserService from '@/services/UserService.js';

export default {
  props: ['id'],
  components: {
    Avatar
  },
  data() {
    return {
      user: {}
    };
  },
  created() {
    const id = parseInt(this.id);
    this.user = UserService.getUser(id);
  }
};
</script>