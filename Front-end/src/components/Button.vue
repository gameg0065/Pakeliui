<template>
  <button v-bind:class="computeCss()">{{ text }}</button>
</template>

<script>
export default {
  name: "Button",
  props: {
    isLarge: Boolean,
    isOutlined: Boolean,
    isSecondary: Boolean,
    text: String
  },
  methods: {
    computeCss: function() {
      let css = this.isSecondary ? "secondary" : "primary";
      if (this.isOutlined) {
        css += "-outlined";
      }

      if (this.isLarge) {
        css += " large";
      }

      return css;
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="css">
@import "../assets/styles/_typography.css";
@import "../assets/styles/_variables.css";
@import "../assets/styles/Button.css";
</style>
