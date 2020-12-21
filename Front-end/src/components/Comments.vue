<template>
  <div class="flex direction-column">
    <h3 class="section-title">Komentarai</h3>

    <div v-if="post.comments && post.comments.length">
      <CommentCard
        v-for="comment in post.comments"
        :key="comment.id"
        :comment="comment"
      />
    </div>

    <div v-if="isActive">
      <div class="flex direction-column grow" :class="{ error: text.error }">
        <span>{{ text.error }}</span>
        <textarea
          id="post-info"
          v-model.trim="text.value"
          @keydown="resetTextError"
        />
      </div>

      <small
        >Rašydami komentarą, sutinkate su
        <router-link :to="{ name: 'terms' }"> Sąlygomis</router-link>.
      </small>
      <div class="flex justify-end">
        <Button
          text="skelbti komentarą"
          :click="submit"
          :isOutlined="true"
          class="mt-20"
        />
      </div>
    </div>
  </div>
</template>

<script>
import Button from '@/components/Button.vue';
import CommentCard from '@/components/CommentCard.vue';

import Service from '@/services/Service';

export default {
  name: 'Comments',
  props: {
    isActive: Boolean,
    post: {},
    user: {},
  },
  components: {
    Button,
    CommentCard,
  },
  data() {
    return {
      text: {
        value: '',
        error: '',
      },
    };
  },
  methods: {
    resetTextError() {
      this.text.error = '';
    },
    submit() {
      const maxInfoLength = 500;
      if (this.text.value && this.text.value.length > maxInfoLength) {
        this.text.error =
          'Čia ne mokslinis traktatas. Max ' + maxInfoLength + ' simbolių.';
      } else {
        this.resetTextError();
      }

      if (this.text.error) {
        return;
      }

      const comment = {
        userId: this.user.userId,
        postId: this.post.id,
        date: new Date().toISOString(),
        text: this.text.value,
      };

      Service.postComment(comment)
        .then((response) => {
          if (response.status === 200) {
            this.text.value = '';
            this.$emit('on-comment-submit');
          }
        })
        .catch((error) => {
          console.log('Could not post comment', error);
        });
    },
  },
};
</script>

<style>
textarea {
  height: 100px;
  resize: none;
  width: 100%;
}
</style>