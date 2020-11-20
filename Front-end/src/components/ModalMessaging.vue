<template>
  <modal
    name="modal-messaging"
    :adaptive="true"
    :height="400"
    :width="600"
    :styles="{ 'border-radius': '10px' }"
    :focusTrap="true"
    @before-open="beforeOpen"
  >
    <div class="container">
      <h3>{{ params.title }}</h3>
      <p>{{ params.text }}</p>

      <div>
        <textarea cols="30" rows="3"></textarea>
      </div>

      <Button :text="button.title" :click="button.action" :isOutlined="true" />
    </div>
  </modal>
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
    };
  },
  computed: {
    button() {
      return this.params.button || {};
    },
  },
  methods: {
    hide() {
      this.$modal.hide('modal-messaging');
    },
    show() {
      this.$modal.show('modal-messaging');
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

<style scoped>
.container {
  padding: 20px;
}
</style>