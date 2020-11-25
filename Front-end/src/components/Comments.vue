<template>
  <div class="flex direction-column">
    <h3 class="section-title">Komentarai</h3>

    <div v-if="comments && comments.length">
      <CommentCard
        v-for="comment in comments"
        :key="comment.id"
        :comment="comment"
      />
    </div>

    <div v-if="isActive">
      <!-- <div> -->
        <textarea v-model.trim="text"></textarea>
      <!-- </div> -->

      <div class="flex justify-between">
        <label
          ><input type="checkbox" v-model="receiveEmail" /> Informuoti mane apie komentarus el. paštu
        </label>

        <small>Rašydami komentarą, sutinkate su Sąlygomis.</small>
      </div>

      <div class="flex justify-end">
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

<style>
textarea {
  height: 100px;
  resize: none;
  width: 100%;
}
</style>