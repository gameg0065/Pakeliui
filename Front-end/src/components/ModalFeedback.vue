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
        <div class="flex">
          <div class="flex direction-column grow">
            <h3>{{ params.title }}</h3>
            <p>{{ params.text }}</p>
          </div>
          <Avatar :path="user.photo" />
        </div>

        <div>
          <label for="rating">{{ params.ratingTitle }}</label>
          <select v-model="data.ratingValue" id="rating">
            <option v-for="index in 5" :key="index">{{ 5 - index + 1 }}</option>
          </select>
        </div>

        <div :class="{ error: data.text.error }">
          <span class="mt-10">{{ data.text.error }}</span>
          <textarea v-model="data.text.value"></textarea>
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
      const text = this.data.text;
      if (!text.value) {
        text.error = 'laukas negali būti tuščias';
      } else {
        text.error = '';
      }

      if (!text.error) {
        this.button.action(this.data);
        this.data = this.resetToDefaults();
      }
    },
    resetToDefaults() {
      return {
        ratingValue: 5,
        text: {
          value: '',
          error: '',
        },
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