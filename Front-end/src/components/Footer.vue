<template>
  <div class="footer">
    <p>©2020 KA Dream Team</p>
    <ul>
      <li><router-link :to="{ name: 'about' }">Apie mus</router-link></li>
      <li><router-link :to="{ name: 'terms' }">Sąlygos</router-link></li>
    </ul>
  </div>
</template>

<script>
export default {
  name: 'Footer',
};
</script>

<style lang="scss">
@import '../assets/styles/footer.scss';
</style>