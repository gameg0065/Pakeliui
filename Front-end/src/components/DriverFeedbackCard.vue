<template>
  <div class="flex direction-column">
    <div class="flex align-start mt-20">
      <Avatar :path="user.picturePath" size="small" class="mr-10" />
      <div class="flex direction-column grow">
        <router-link :to="{ name: 'user', params: { id: passengerId } }">
          <p class="text-color-primary">{{ user.name }}</p>
        </router-link>
      </div>
    </div>
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';

import Service from '@/services/Service';

export default {
  name: 'DriverFeedbackCard',
  props: ['passengerId'],
  components: {
    Avatar,
  },
  data() {
    return {
      user: {},
    };
  },
  async created() {
    await Service.getUserById(this.passengerId)
      .then((response) => {
        if (response.status === 200) {
          this.user = response.data;
        }
      })
      .catch((error) => {
        console.log('Could not get user by ID', error);
      });
  },
};
</script>