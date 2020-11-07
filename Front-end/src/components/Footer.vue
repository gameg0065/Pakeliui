<template>
  <div class="footer">
    <p>©2020 KA Dream Team</p>
    <ul>
      <li><router-link :to="{ name: 'about' }">apie mus</router-link></li>
      <li><router-link :to="{ name: 'contacts' }">kontaktai</router-link></li>
      <li><router-link :to="{ name: 'terms' }">sąlygos</router-link></li>
    </ul>
  </div>
</template>

<style lang="scss">
@import '../assets/styles/footer.css';
</style>