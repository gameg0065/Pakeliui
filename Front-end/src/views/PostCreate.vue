<template>
  <div class="post-create">
    <h2 class="page-title" v-if="isEditMode">Redaguoti skelbimą</h2>
    <h2 class="page-title" v-else>Įkelti skelbimą</h2>

    <div class="flex align-end" :class="{ error: wipPost.date.error }">
      <label for="post-date"> Kelionės data* </label>
      <div class="flex direction-column grow">
        <span>{{ wipPost.date.error }}</span>
        <Datepicker
          id="post-date"
          v-model="wipPost.date.value"
          format="yyyy-MM-dd"
          :monday-first="true"
          @selected="resetErrorFor('date')"
        />
      </div>
    </div>

    <div class="flex align-end" :class="{ error: wipPost.time.error }">
      <label for="post-time"> Kelionės laikas* </label>
      <div class="flex direction-column grow">
        <span>{{ wipPost.time.error }}</span>
        <input
          type="text"
          id="post-time"
          v-model.trim="wipPost.time.value"
          @keydown="resetErrorFor('time')"
        />
      </div>
    </div>

    <div class="flex align-end" :class="{ error: wipPost.travelFrom.error }">
      <label for="post-from"> Iš miesto* </label>
      <div class="flex direction-column grow">
        <span>{{ wipPost.travelFrom.error }}</span>
        <input
          type="text"
          id="post-from"
          v-model.trim="wipPost.travelFrom.value"
          @keydown="resetErrorFor('travelFrom')"
        />
      </div>
    </div>

    <div class="line">
      <label for="post-pickup">Paėmimo vieta</label>
      <input type="text" id="post-pickup" v-model.trim="post.pickup" />
    </div>

    <div class="flex align-end" :class="{ error: wipPost.travelTo.error }">
      <label for="post-to"> Į miestą* </label>
      <div class="flex direction-column grow">
        <span>{{ wipPost.travelTo.error }}</span>
        <input
          type="text"
          id="post-to"
          v-model.trim="wipPost.travelTo.value"
          @keydown="resetErrorFor('travelTo')"
        />
      </div>
    </div>

    <div class="line">
      <label for="route-dropoff">Pristatymo vieta</label>
      <input type="text" id="route-dropoff" v-model.trim="post.dropoff" />
    </div>

    <div class="line">
      <label for="route-intermediate">Tarpiniai miestai</label>
      <input type="text" id="route-intermediate" v-model.trim="post.intermediateCities" />
    </div>

    <div class="flex align-end" :class="{ error: wipPost.seetCount.error }">
      <label for="post-seetCount"> Galimas keleivių skaičius* </label>
      <div class="flex direction-column grow">
        <span>{{ wipPost.seetCount.error }}</span>
        <input
          type="number"
          id="post-seetCount"
          v-model.trim="wipPost.seetCount.value"
          @keydown="resetErrorFor('seetCount')"
        />
      </div>
    </div>

    <div class="line">
      <label for="post-price">Kelionės kaina</label>
      <input type="number" id="post-price" v-model.number="post.price" />
    </div>

    <div class="flex align-end" :class="{ error: wipPost.info.error }">
      <label for="post-info"> Papildoma informacija </label>
      <div class="flex direction-column grow">
        <span>{{ wipPost.info.error }}</span>
        <textarea
          id="post-info"
          v-model.trim="wipPost.info.value"
          @keydown="resetErrorFor('info')"
        />
      </div>
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
      wipPost: this.resetToDefaults(),
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

    // Copy `post` values to `wipPost`
    Object.keys(this.wipPost).forEach((key) => {
      this.wipPost[key].value = this.post[key] || '';
    });
  },
  methods: {
    resetErrorFor(key) {
      this.wipPost[key].error = '';
    },
    submit() {
      const post = this.post;
      const user = this.user;
      const wipPost = this.wipPost;
      const redirectToUserHistory = (user, post) => {
        this.$store.dispatch('updateUser', user).then(() => {
          post = {};
          this.$router.push({
            name: 'driver-history',
            params: { id: user.userId },
          });
        });
      };

      if (wipPost.date.value) {
        const now = new Date();
        const postDate = new Date(wipPost.date.value);
        const isToday =
          now.getDate() === postDate.getDate() &&
          now.getMonth() === postDate.getMonth() &&
          now.getFullYear() === postDate.getFullYear();

        if (!isToday && now.getTime() > postDate.getTime()) {
          wipPost.date.error = 'Kelionė praeityje negalima';
        } else {
          wipPost.date.error = '';
          post.date = wipPost.date.value;
        }
      } else {
        wipPost.date.error = 'Įveskite kelionės datą';
      }

      wipPost.time.error = !wipPost.time.value ? 'Įveskite kelionės laiką' : '';
      post.time = wipPost.time.value;

      wipPost.travelFrom.error = !wipPost.travelFrom.value
        ? 'Įveskite maršruto pradžią'
        : '';
      post.travelFrom = wipPost.travelFrom.value;

      wipPost.travelTo.error = !wipPost.travelTo.value
        ? 'Įveskite maršruto pabaigą'
        : '';
      post.travelTo = wipPost.travelTo.value;

      wipPost.seetCount.error = !wipPost.seetCount.value
        ? 'Įveskite galimą keleivių skaičių'
        : '';
      post.seetCount = wipPost.seetCount.value;

      const maxInfoLength = 500;
      if (wipPost.info.value && wipPost.info.value.length > maxInfoLength) {
        wipPost.info.error =
          'Čia ne mokslinis traktatas. Max ' + maxInfoLength + ' simbolių.';
      } else {
        wipPost.info.error = '';
        post.info = wipPost.info.value;
      }

      const formHasErrors = Object.keys(wipPost).some((key) => {
        return wipPost[key].error !== '';
      });

      if (!formHasErrors) {
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
      }
    },
    resetToDefaults() {
      return {
        date: {
          value: '',
          error: '',
        },
        time: {
          value: '',
          error: '',
        },
        travelFrom: {
          value: '',
          error: '',
        },
        travelTo: {
          value: '',
          error: '',
        },
        seetCount: {
          value: '',
          error: '',
        },
        info: {
          value: '',
          error: '',
        },
      };
    },
  },
};
</script>

<style lang="scss">
@import '../assets/styles/post-create.scss';
</style>