<template>
  <div class="card shadow flex">
    <Avatar :path="user.picturePath" class="mr-20" />

    <div class="flex direction-column grow">
      <router-link :to="{ name: 'user', params: { id: user.userId } }">
        <h4 class="text-color-primary mb-10">{{ user.name }}</h4>
      </router-link>

      <small> Pavėžėjimų skaičius: {{ this.user.posts.length }}</small>

      <p>Susisiekite su manimi: {{ getContactInfo() }}</p>
    </div>

    <!-- <Rating :rating="user.driver.rating" /> -->
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
// import Rating from '@/components/Rating.vue';

export default {
  name: 'UserCardInPost',
  props: ['post'],
  components: {
    Avatar,
    // Rating,
  },
  data() {
    return {
      user: this.post.user,
    };
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