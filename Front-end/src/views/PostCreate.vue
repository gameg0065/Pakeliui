<template>
  <div class="post-create">
    <h2 class="page-title" v-if="isEditMode">Redaguoti skelbimą</h2>
    <h2 class="page-title" v-else>Įkelti skelbimą</h2>

    <div class="line">
      <label for="post-date">Kelionės data*</label>
      <Datepicker
        id="post-date"
        v-model="post.date"
        format="yyyy-MM-dd"
        :monday-first="true"
      />
    </div>

    <div class="flex align-end" :class="{ error: timeError }">
      <label for="post-time">Kelionės laikas*</label>
      <div class="flex direction-column">
        <span>{{ timeError }}</span>
        <input type="text" id="post-time" v-model.trim="post.time" />
      </div>
    </div>

    <!-- <div class="line">
      <label for="post-time">Kelionės laikas*</label>
      <input type="text" id="post-time" v-model="post.time" />
    </div> -->

    <div class="line">
      <label for="route-from">Iš miesto*</label>
      <input type="text" id="route-from" v-model.trim="post.route.from" />
    </div>

    <div class="line">
      <label for="route-pickup">Paėmimo vieta</label>
      <input type="text" id="route-pickup" v-model.trim="post.route.pickup" />
    </div>

    <div class="line">
      <label for="route-to">Į miestą*</label>
      <input type="text" id="route-to" v-model.trim="post.route.to" />
    </div>

    <div class="line">
      <label for="route-dropoff">Pristatymo vieta</label>
      <input type="text" id="route-dropoff" v-model.trim="post.route.dropoff" />
    </div>

    <div class="line">
      <label for="post-seetCount">Galimas keleivių skaičius*</label>
      <input
        type="number"
        id="post-seetCount"
        v-model.number="post.seetCount"
      />
    </div>

    <div class="line">
      <label for="post-price">Kelionės kaina</label>
      <input type="number" id="post-price" v-model.number="post.price" />
    </div>

    <div class="line">
      <label for="post-info">Papildoma informacija</label>
      <textarea id="post-info" v-model.trim="post.info" />
    </div>

    <Button
      :click="submit"
      text="išsaugoti"
      :isOutlined="true"
      class="button"
    />
  </div>
</template>

<script>
import Button from '@/components/Button.vue';
import Datepicker from 'vuejs-datepicker';

import PostService from '@/services/PostService.js';
export default {
  name: 'PostCreate',
  props: ['id'],
  components: {
    Button,
    Datepicker,
  },
  data() {
    return {
      post: Object,
      isEditMode: {
        type: Boolean,
        default: false,
      },
      timeError: '',
    };
  },
  created() {
    if (this.id) {
      this.isEditMode = true;
      this.post = PostService.getPost(parseInt(this.id));
    } else {
      this.isEditMode = false;
    }

    this.post.distance = this.post.distance || 0;
    this.post.driver = this.post.driver || {};
    this.post.passengers = this.post.passengers || [];
    this.post.route = this.post.route || {};
  },
  methods: {
    submit() {
      if (!this.post.time) {
        this.timeError = 'enter time';
      } else {
        this.timeError = '';
      }
      // alert('TODO');
    },
  },
};
</script>

<style lang="scss">
@import '../assets/styles/post-create.scss';
</style>