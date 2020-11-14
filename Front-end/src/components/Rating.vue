<template>
  <div>
    <img
      v-for="index in Math.round(rating)"
      :key="index"
      src="../assets/icons/star.svg"
    />
  </div>
</template>

<script>
export default {
  props: {
    rating: {
      type: [Number, String],
      default: 5,
    },
  },
};
</script>