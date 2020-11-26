<template>
  <div class="modal">
    <modal
      name="modal-feedback"
      :adaptive="true"
      height="auto"
      :width="600"
      :styles="{ 'border-radius': '10px' }"
      :focusTrap="true"
      @before-open="beforeOpen"
    >
      <div class="container">
        <div class="line" style="align-items: unset;">
          <div>
            <h3>{{ params.title }}</h3>
            <p>{{ params.text }}</p>
          </div>
          <Avatar :path="user.photo" />
        </div>

        <div class="line" style="padding-top: 20px">
          <label for="rating">{{ params.ratingTitle }}</label>
          <select v-model="data.ratingValue" id="rating">
            <option v-for="index in 5" :key="index">{{ 5 - index + 1 }}</option>
          </select>
        </div>

        <div>
          <textarea v-model="data.text"></textarea>
        </div>

        <Button :text="button.title" :click="submit" :isOutlined="true" />
      </div>
    </modal>
  </div>
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

<style lang="scss">
@import '../assets/styles/modal.scss';
</style>