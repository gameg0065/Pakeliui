<template>
  <div class="modal">
    <modal
      name="modal-notification"
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

        <Button
          :text="button.title"
          :click="button.action"
          :isOutlined="true"
        />
      </div>
    </modal>
  </div>
</template>

<script>
import Button from '@/components/Button.vue';

export default {
  name: 'ModalNotification',
  components: {
    Button,
  },
  data() {
    return {
      params: {},
    };
  },
  computed: {
    button() {
      return this.params.button || {};
    },
  },
  methods: {
    hide() {
      this.$modal.hide('modal-notification');
    },
    show() {
      this.$modal.show('modal-notification');
    },
    beforeOpen(event) {
      this.params = event.params || {};
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