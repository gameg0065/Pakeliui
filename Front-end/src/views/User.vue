<template>
  <div>
    <h1>this is USER # {{ id }} page</h1>
  </div>
</template>

<script>
export default {
  props: ['id'],
  created() {
    // fetch user data from DB here
  }
};
</script>