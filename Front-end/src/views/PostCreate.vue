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

    <div class="line">
      <label for="post-time">Kelionės laikas*</label>
      <input type="text" id="post-time" v-model="post.time" />
    </div>

    <div class="line">
      <label for="route-from">Iš miesto*</label>
      <input type="text" id="route-from" v-model.trim="post.travelFrom" />
    </div>

    <div class="line">
      <label for="route-pickup">Paėmimo vieta</label>
      <input type="text" id="route-pickup" v-model.trim="post.pickup" />
    </div>

    <div class="line">
      <label for="route-to">Į miestą*</label>
      <input type="text" id="route-to" v-model.trim="post.travelTo" />
    </div>

    <div class="line">
      <label for="route-dropoff">Pristatymo vieta</label>
      <input type="text" id="route-dropoff" v-model.trim="post.dropoff" />
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

import Service from '@/services/Service';

export default {
  name: 'PostCreate',
  props: ['id'],
  components: {
    Button,
    Datepicker,
  },
  computed: {
    user() {
      return this.$store.getters.getUser;
    },
  },
  data() {
    return {
      post: {},
      isEditMode: {
        type: Boolean,
        default: false,
      },
    };
  },
  created() {
    this.isEditMode = false;
    if (this.id && this.user && this.user.posts) {
      this.post = this.user.posts.find((post) => {
        return parseInt(post.id) === parseInt(this.id);
      });
      if (this.post) {
        this.isEditMode = true;
      } else {
        this.$router.push({
          name: '404',
        });
      }
    }
  },
  methods: {
    submit() {
      const post = this.post;
      const user = this.user;
      const redirectToUserHistory = (user, post) => {
        this.$store.dispatch('updateUser', user).then(() => {
          post = {};
          this.$router.push({
            name: 'driver-history',
            params: { id: user.userId },
          });
        });
      };

      if (this.isEditMode) {
        Service.putPost(post)
          .then((response) => {
            redirectToUserHistory(user, post);
          })
          .catch((error) => {
            console.log('Could not put post', error);
          });
      } else {
        post.userId = user.userId;

        Service.postPost(post)
          .then((response) => {
            if (!user.posts) {
              user.posts = [];
            }

            post.id = response.data.id;
            user.posts.push(post);

            redirectToUserHistory(user, post);
          })
          .catch((error) => {
            console.log('Could not create post', error);
          });
      }
    },
  },
};
</script>

<style lang="scss">
@import '../assets/styles/post-create.scss';
</style>