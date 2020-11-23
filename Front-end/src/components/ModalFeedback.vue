<template>
  <modal
    name="modal-feedback"
    :adaptive="true"
    :height="400"
    :width="600"
    :styles="{ 'border-radius': '10px' }"
    :focusTrap="true"
    @before-open="beforeOpen"
  >
    <div class="container">
      <h3>{{ params.title }}</h3>
      <Avatar :path="user.photo" />
      <p>{{ params.text }}</p>

      <label for="rating">{{ params.ratingTitle }}</label>
      <select v-model="data.ratingValue" id="rating">
        <option v-for="index in 5" :key="index">{{ 5 - index + 1 }}</option>
      </select>

      <div>
        <textarea rows="3" v-model="data.text"></textarea>
      </div>

      <Button :text="button.title" :click="submit" :isOutlined="true" />
    </div>
  </modal>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
import Button from '@/components/Button.vue';

export default {
  name: 'ModalFeedback',
  components: {
    Avatar,
    Button,
  },
  data() {
    return {
      params: {},
      data: this.resetToDefaults(),
    };
  },
  computed: {
    button() {
      return this.params.button || {};
    },
    user() {
      return this.params.user || {};
    },
  },
  methods: {
    beforeOpen(event) {
      this.params = event.params || {};
    },
    hide() {
      this.$modal.hide('modal-feedback');
    },
    show() {
      this.$modal.show('modal-feedback');
    },
    submit() {
      this.button.action(this.data);
      this.data = this.resetToDefaults();
    },
    resetToDefaults() {
      return {
        ratingValue: 5,
        text: '',
      };
    },
  },
  mount() {
    this.show();
  },
};
</script>

<style scoped>
.container {
  padding: 20px;
}
</style>