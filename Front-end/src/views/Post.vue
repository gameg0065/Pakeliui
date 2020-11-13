<template>
  <div class="post">
    <div>
      <h2>Skelbimas</h2>
      <p>skelbimo busena: aktyvus/pasibaiges</p>
    </div>

    <div>
      <h3>userCard</h3>
      <Button text="rezervuoti" :isOutlined="true" />
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

    <Button text="REZERVUOTI" />
    <Comments :comments="post.comments" />
  </div>
</template>

<script>
import PostService from '@/services/PostService.js';
import Comments from '@/components/Comments.vue';
import Button from '@/components/Button.vue';

export default {
  props: ['id'],
  components: {
    Comments,
    Button,
  },
  data() {
    return {
      post: {},
    };
  },
  created() {
    this.post = PostService.getPost(this.id);
  },
};
</script>

