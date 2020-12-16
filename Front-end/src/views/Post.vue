<template>
  <div class="post align-stretch">
    <div class="page-title flex align-baseline">
      <h2>Skelbimas</h2>
      <h5 v-if="isActive" class="text-color-primary">
        Skelbimo būsena: aktyvus
      </h5>
      <h5 v-else class="text-color-secondary">
        Skelbimo būsena: nebegaliojantis
      </h5>
    </div>

    <div class="flex direction-column pb-50">
      <UserCardInPost :post="post" />
      <Button
        text="rezervuoti"
        :click="reserve"
        :isDisabled="!isActive || userIsAuthor"
        :isOutlined="true"
        class="align-self-center"
      />
    </div>

    <div class="info">
      <div>
        <small>Kelionės data </small>
        <p>{{ post.date }}</p>
      </div>
      <div>
        <small>Kelionės laikas </small>
        <p>{{ post.time }}</p>
      </div>
      <div>
        <small>Iš miesto </small>
        <p>{{ post.travelFrom }}</p>
      </div>
      <div>
        <small>Paėmimo vieta</small>
        <p>{{ post.pickup }}</p>
      </div>
      <div>
        <small>Į miestą</small>
        <p>{{ post.travelTo }}</p>
      </div>
      <div>
        <small>Pristatymo vieta</small>
        <p>{{ post.dropoff }}</p>
      </div>
      <div>
        <small>Galimas keleivių skaičius</small>
        <p>{{ post.seetCount }}</p>
      </div>
      <!-- <div>
        <small>Laisvų vietų skaičius</small>
        <p>TODO</p>
      </div> -->
      <div>
        <small>Kelionės kaina</small>
        <p>{{ post.price }}€</p>
      </div>
      <div class="extra">
        <small>Papildoma informacija</small>
        <p>{{ post.info }}</p>
      </div>

      <img src="https://i.stack.imgur.com/yEshb.gif" alt="map" class="map" />
    </div>

    <Button
      text="rezervuoti"
      :click="reserve"
      :isDisabled="!isActive || userIsAuthor"
      :isLarge="true"
      class="mb-50"
    />

    <div class="bleed-width pb-50">
      <Comments :comments="post.comments" :isActive="isActive" />
    </div>
  </div>
</template>

<script>
import Button from '@/components/Button.vue';
import Comments from '@/components/Comments.vue';
import UserCardInPost from '@/components/UserCardInPost.vue';

import PostService from '@/services/PostService.js';

export default {
  name: 'Post',
  // TODO
  props: ['id', 'POST_temp'], // I should remove POST once getPostById() is imlemented
  components: {
    Comments,
    Button,
    UserCardInPost,
  },
  data() {
    return {
      isActive: Boolean,
      post: {},
    };
  },
  computed: {
    user() {
      return this.$store.getters.getUser;
    },
    userIsAuthor() {
      console.log(this.post.user.userId);
      console.log(this.user.userId);
      return this.user ? this.post.user.userId === this.user.userId : false;
    },
  },
  created() {
    // TODO
    // this.post = PostService.getPost(parseInt(this.id));
    this.post = this.POST_temp; // should get `post` by ID, once getPostById() is implemented in backend

    const now = new Date();
    const postDate = new Date(this.post.date);

    this.isActive = postDate.getTime() >= now.getTime();
  },
  methods: {
    reserve() {
      const modal = this.$modal;
      modal.show('modal-messaging', {
        title: 'Kelionės rezervacija',
        text:
          'Žinutė apie Jūsų rezervaciją bus išsiųsta vairuotojui, kai paspausite mygtuką „REZERVUOTI“. Žemiau esančiame laukelyje palikite žinutę vairuotojui.',
        button: {
          title: 'rezervuoti',
          action(data) {
            alert('TODO');
            modal.hide('modal-messaging');
          },
        },
      });
    },
  },
};
</script>


<style lang="scss">
@import '../assets/styles/post.scss';
</style>