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

    <div class="card">
      <div>
        <textarea rows="4">Mano komentaras goes here</textarea>
      </div>

      <label><input type="checkbox" /> Informuoti mane apie komentarus </label>

      <small>Rašydami komentarą, sutinkate su portalo taisyklėmis.</small>

      <div>
        <Button text="komentuoti" :isOutlined="true" />
      </div>
    </div>
  </div>
</template>

<script>
import Button from '@/components/Button.vue';
import CommentCard from '@/components/CommentCard.vue';

export default {
  props: ['comments'],
  components: {
    Button,
    CommentCard
  }
};
</script>