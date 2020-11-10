<template>
  <div class="post">
    <div class="name">
      <h2>Skelbimas</h2>
      <p>skelbimo busena: aktyvus/pasibaiges</p>
    </div>
    <div class="userCard">
      <h3>userCard</h3>
      <Button text="rezervuoti" />
    </div>

    <div class="post-info">
      <ul>
        <li><small>Keliones data: </small></li>
        <li><small>Keliones laikas </small></li>
        <li><small>Is miesto </small></li>
        <li><small>Paemimo adresas</small></li>
        <li><small>I miesta</small></li>
        <li><small>Pristatymo vieta</small></li>
        <li><small>Kiek ali paimti keleiviu</small></li>
        <li><small>Liko laisvu vietu</small></li>
        <li><small>Keliones kaina</small></li>
      </ul>
      <ul class="info">
        <li>
          <p>{{ post.date }}</p>
        </li>
        <li>
          <p>{{ post.time }}</p>
        </li>
        <li>
          <p>{{ post.route.from }}</p>
        </li>
        <li>
          <p>{{ post.route.pickup }}</p>
        </li>
        <li>
          <p>{{ post.route.to }}</p>
        </li>
        <li>
          <p>{{ post.route.dropoff }}</p>
        </li>
        <li>
          <p>{{ post.seetCount }}</p>
        </li>
        <li><p>paskaiciuoti</p></li>
        <li>
          <p>{{ post.price }}€</p>
        </li>
      </ul>
      <img src="https://i.stack.imgur.com/yEshb.gif" alt="map" />

      <ul>
        <li><small>Papildoma informacija</small></li>
      </ul>
      <ul>
        <li>
          <p>{{ post.info }}</p>
        </li>
      </ul>
    </div>

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
    Button
  },
  data() {
    return {
      post: {}
    };
  },
  created() {
    this.post = PostService.getPost(this.id);
  }
};
</script>

<style lang="scss">
@import '../assets/styles/post.css';
</style>
