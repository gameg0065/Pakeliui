<template>
  <div class="modal">
    <modal
      name="modal-messaging"
      :adaptive="true"
      height="auto"
      :width="600"
      :styles="{ 'border-radius': '10px' }"
      :focusTrap="true"
      @before-open="beforeOpen"
    >
      <div class="container">
        <h3>{{ params.title }}</h3>
        <p>{{ params.text }}</p>

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
import Button from '@/components/Button.vue';

export default {
  name: 'ModalMessaging',
  components: {
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
  },
  methods: {
    beforeOpen(event) {
      this.params = event.params || {};
    },
    hide() {
      this.$modal.hide('modal-messaging');
    },
    show() {
      this.$modal.show('modal-messaging');
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