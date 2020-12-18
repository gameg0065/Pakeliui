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
      <textarea v-model.trim="text"></textarea>

      <div class="flex justify-between">
        <label
          ><input type="checkbox" v-model="receiveEmail" /> Informuoti mane
          elektroniniu paštu apie komentarus
        </label>

        <small>Rašydami komentarą, sutinkate su Sąlygomis.</small>
      </div>

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
      receiveEmail: null,
      text: null,
    };
  },
  methods: {
    submit() {
      if (!this.text) {
        return;
      }

      const comment = {
        userId: this.user.userId,
        postId: this.post.id,
        date: new Date().toISOString(),
        text: this.text,
      };

      Service.postComment(comment)
        .then((response) => {
          if (response.status === 200) {
            this.text = '';
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