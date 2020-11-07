<template>
  <div class="home">
    <router-link :to="{ name: 'posts' }">
      <Button text="skelbimai" :isLarge="true" />
    </router-link>

    <router-link :to="{ name: 'post-create' }">
      <Button text="sukurk skelbimą" :isSecondary="true" :isLarge="true" />
    </router-link>
  </div>
</template>

<script lang='ts'>
import Vue from 'vue';
import Button from '@/components/Button.vue'; // @ is an alias to /src

export default Vue.extend({
  components: {
    Button
  }
});
</script>