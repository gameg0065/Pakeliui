<template>
  <div class="card shadow flex">
    <Avatar :path="user.picturePath" class="mr-20" />

    <div class="flex direction-column grow">
      <router-link :to="{ name: 'user', params: { id: post.userId } }">
        <h4 class="text-color-primary mb-10">{{ user.name }}</h4>
      </router-link>

      <small>
        Pavėžėjimų skaičius: {{ user.posts ? user.posts.length : 0 }}</small
      >

      <p>Susisiekite su manimi: {{ getContactInfo() }}</p>
    </div>

  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';

import Service from '@/services/Service';

export default {
  name: 'UserCardInPost',
  props: ['post'],
  components: {
    Avatar,
  },
  data() {
    return {
      // Use `user` data from Post, but do an API call
      // to overwrite it, because `Post` doesn't have
      // all the data needed for user to display
      user: this.post.user || {},
    };
  },
  created() {
    Service.getUserById(this.post.userId)
      .then((response) => {
        if (response.status === 200) {
          this.user = response.data;
        }
      })
      .catch((error) => {
        console.log('Could not get user by ID', error);
      });
  },
  methods: {
    getContactInfo() {
      const contactMethod = this.user.driverContactMethod;
      const contactInfo = this.user[contactMethod];
      return contactInfo;
    },
  },
};
</script>