<template>
  <div>
    <h3>Komentarai</h3>

    <div v-if="comments && comments.length">
      <CommentCard
        v-for="comment in comments"
        :key="comment.id"
        :comment="comment"
      />
    </div>

    <div v-if="isActive">
      <div>
        <textarea rows="4">Mano komentaras goes here</textarea>
      </div>

      <label><input type="checkbox" /> Informuoti mane apie komentarus </label>

      <small>Rašydami komentarą, sutinkate su portalo taisyklėmis.</small>

      <div>
        <Button text="komentuoti" :click="submit" :isOutlined="true" />
      </div>
    </div>
  </div>
</template>

<script>
import Button from '@/components/Button.vue';
import CommentCard from '@/components/CommentCard.vue';

export default {
  name: 'Comments',
  props: {
    comments: Array,
    isActive: Boolean,
  },
  components: {
    Button,
    CommentCard,
  },
  methods: {
    submit() {
      alert('TODO');
    },
  },
};
</script>