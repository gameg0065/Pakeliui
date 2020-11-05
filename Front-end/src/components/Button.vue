<template>
  <a v-bind:href="url" class="button" v-bind:class="computeClass">
    {{ text }}
  </a>
</template>

<script>
export default {
  name: 'Button',
  props: {
    isLarge: {
      required: false,
      type: Boolean
    },
    isOutlined: {
      required: false,
      type: Boolean
    },
    isSecondary: {
      required: false,
      type: Boolean
    },
    text: {
      default: 'button',
      required: true,
      type: String
    },
    url: {
      default: '#',
      required: true,
      type: String
    }
  },
  computed: {
    computeClass: function() {
      let css = this.isSecondary ? 'secondary' : 'primary';
      if (this.isOutlined) {
        css += '-outlined';
      }

      if (this.isLarge) {
        css += ' large';
      }

      return css;
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="css">
@import '../assets/styles/_typography.css';
@import '../assets/styles/_variables.css';
@import '../assets/styles/Button.css';
</style>
