<template>
  <div class="post">
    <div>
      <h2>Skelbimas</h2>
      <p v-if="isActive" class="post-active">Skelbimo būsena: aktyvus</p>
      <p v-else class="post-expired">Skelbimo būsena: nebegaliojantis</p>
    </div>

    <div>
      <UserCardInPost :post="post" />
      <Button
        text="rezervuoti"
        :click="reserve"
        :isDisabled="!isActive || userIsAuthor"
        :isOutlined="true"
      />
    </div>

    <div>
      <div>
        <small>Kelionės data </small>
        <p>{{ post.date }}</p>
      </div>
      <div>
        <small>Kelionės laikas </small>
        {{ post.time }}
      </div>
      <div>
        <small>Iš miesto </small>
        <p>{{ post.route.from }}</p>
      </div>
      <div>
        <small>Paėmimo vieta</small>
        <p>{{ post.route.pickup }}</p>
      </div>
      <div>
        <small>Į miestą</small>
        <p>{{ post.route.to }}</p>
      </div>
      <div>
        <small>Pristatymo vieta</small>
        <p>{{ post.route.dropoff }}</p>
      </div>
      <div>
        <small>Galimas keleivių skaičius</small>
        <p>{{ post.seetCount }}</p>
      </div>
      <div>
        <small>Laisvų vietų skaičius</small>
        <p>paskaičiuoti</p>
      </div>
      <div>
        <small>Kelionės kaina</small>
        <p>{{ post.price }}€</p>
      </div>
      <div>
        <small>Papildoma informacija</small>
        <p>{{ post.info }}</p>
      </div>
    </div>

    <img src="https://i.stack.imgur.com/yEshb.gif" alt="map" />

    <Button
      text="rezervuoti"
      :click="reserve"
      :isDisabled="!isActive || userIsAuthor"
    />
    <Comments :comments="post.comments" :isActive="isActive" />
  </div>
</template>

<script>
import Button from '@/components/Button.vue';
import Comments from '@/components/Comments.vue';
import UserCardInPost from '@/components/UserCardInPost.vue';

import PostService from '@/services/PostService.js';

export default {
  name: 'Post',
  props: ['id'],
  components: {
    Comments,
    Button,
    UserCardInPost,
  },
  data() {
    return {
      isActive: Boolean,
      post: Object,
    };
  },
  computed: {
    user() {
      return this.$store.getters.getUser;
    },
    userIsAuthor() {
      return this.user ? this.post.driver.id === this.user.id : false;
    },
  },
  created() {
    this.post = PostService.getPost(parseInt(this.id));

    const now = new Date();
    const postDate = new Date(this.post.date);

    this.isActive = postDate.getTime() >= now.getTime();
  },
  methods: {
    reserve() {
      alert('TODO');
    },
  },
};
</script>

<style scoped>
p.post-active {
  color: var(--color-primary);
}

p.post-expired {
  color: var(--color-secondary);
}
</style>