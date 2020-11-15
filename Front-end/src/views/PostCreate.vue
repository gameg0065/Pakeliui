<template>
  <div>
    <h2 v-if="isEditMode">Redaguok skelbimą</h2>
    <h2 v-else>Sukurk skelbimą</h2>

    <div>
      <label for="post-date">Kelionės data*</label>
      <Datepicker
        id="post-date"
        v-model="post.date"
        format="yyyy-MM-dd"
        :monday-first="true"
      />
    </div>

    <div>
      <label for="post-time">Kelionės laikas*</label>
      <input type="text" id="post-time" v-model="post.time" />
    </div>

    <div>
      <label for="route-from">Iš miesto*</label>
      <input type="text" id="route-from" v-model="post.route.from" />
    </div>

    <div>
      <label for="route-pickup">Paėmimo vieta</label>
      <input type="text" id="route-pickup" v-model="post.route.pickup" />
    </div>

    <div>
      <label for="route-to">Į miestą*</label>
      <input type="text" id="route-to" v-model="post.route.to" />
    </div>

    <div>
      <label for="route-dropoff">Pristatymo vieta</label>
      <input type="text" id="route-dropoff" v-model="post.route.dropoff" />
    </div>

    <div>
      <label for="post-seetCount">Keleivių skaičius</label>
      <input type="number" id="post-seetCount" v-model="post.seetCount" />
    </div>

    <div>
      <label for="post-price">Kelionės kaina</label>
      <input type="number" id="post-price" v-model="post.price" />
    </div>

    <div>
      <label for="post-info">Papildoma informacija</label>
      <textarea id="post-info" rows="3" v-model="post.info" />
    </div>

    <Button :click="submit" text="išsaugoti" :isOutlined="true" />
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
      alert('TODO');
    },
  },
};
</script>