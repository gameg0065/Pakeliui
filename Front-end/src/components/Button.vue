<template>
  <button
    @click="onClick"
    class="button"
    :class="computeClass"
    :disabled="isDisabled"
  >
    {{ text }}
  </button>
</template>

<script>
export default {
  name: 'Button',
  props: {
    click: {
      required: false,
      type: Function,
    },
    isDisabled: {
      default: false,
      required: false,
      type: Boolean,
    },
    isLarge: {
      required: false,
      type: Boolean,
    },
    isOutlined: {
      required: false,
      type: Boolean,
    },
    isSecondary: {
      required: false,
      type: Boolean,
    },
    text: {
      default: 'button',
      required: true,
      type: String,
    },
  },
  computed: {
    computeClass: function () {
      let css = this.isSecondary ? 'secondary' : 'primary';
      if (this.isOutlined) {
        css += '-outlined';
      }

      if (this.isLarge) {
        css += ' large';
      }

      return css;
    },
  },
  methods: {
    onClick() {
      if (typeof this.click === 'function') {
        this.click();
      }
    },
  },
};
</script>

<style scoped lang="css">
@import '../assets/styles/Button.css';
</style>
