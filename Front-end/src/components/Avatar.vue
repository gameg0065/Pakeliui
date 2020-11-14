<template>
  <img :src="getImage()" class="avatar" :class="size" />
</template>

<script>
export default {
  props: {
    path: {
      type: String,
    },
    size: {
      type: String,
      default: 'regular',
    },
  },
  methods: {
    getImage(path) {
      // TODO: Perfomr image fetching here, and fallback
      // to default avatar if image does not exist

      return this.path
        ? this.path
        : require('../assets/images/user-undefined.png');
    },
  },
};
</script>

<style scoped>
.avatar {
  border-radius: 50%;
}

.big {
  height: 144px;
  width: 144px;
}

.regular {
  height: 80px;
  width: 80px;
}

.small {
  height: 48px;
  width: 48px;
}
</style>