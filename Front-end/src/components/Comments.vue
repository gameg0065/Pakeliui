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
        <textarea rows="4" v-model.trim="text">
          Mano komentaras goes here </textarea
        >
      </div>

      <label
        ><input type="checkbox" v-model="receiveEmail" /> Informuoti mane apie komentarus el. paštu
      </label>

      <small>Rašydami komentarą, sutinkate su Sąlygomis.</small>

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
  data() {
    return {
      receiveEmail: null,
      text: null,
    };
  },
  methods: {
    submit() {
      alert('TODO');
    },
  },
};
</script>