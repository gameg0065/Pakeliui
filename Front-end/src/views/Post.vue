<template>
  <div class="post">
    <div>
      <h2>Skelbimas</h2>
      <p v-if="isActive" class="post-active">Skelbimo būsena: aktyvus</p>
      <p v-else class="post-expired">Skelbimo būsena: pasibaigęs</p>
    </div>

    <div>
      <UserCardInPost :post="post" />
      <Button v-if="isActive" text="rezervuoti" :isOutlined="true" />
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
        <small>Paėmimo adresas</small>
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
        <small>Kiek gali paimti keleivių</small>
        <p>{{ post.seetCount }}</p>
      </div>
      <div>
        <small>Liko laisvų vietų</small>
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

    <Button v-if="isActive" text="REZERVUOTI" />
    <Comments :comments="post.comments" :isActive="isActive" />
  </div>
</template>

<script>
import Button from '@/components/Button.vue';
import Comments from '@/components/Comments.vue';
import UserCardInPost from '@/components/UserCardInPost.vue';

import PostService from '@/services/PostService.js';

export default {
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
  created() {
    this.post = PostService.getPost(parseInt(this.id));

    const now = new Date();
    const postDate = new Date(this.post.date);

    this.isActive = postDate.getTime() >= now.getTime();
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