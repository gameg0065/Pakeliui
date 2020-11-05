<template>
  <router-link :to="{ name: 'post', params: { id: post.id } }">
    <div class="card shadow">
      <h4>{{ post.title }}</h4>
      <p>{{ post.date + ', ' + post.dayName + ' ' + post.time }}</p>
      <small> {{ post.driverName }}</small>
      <p>Laisvų vietų: {{ post.seetCount - post.passengers.length }}</p>
    </div>
  </router-link>
</template>

<script>
export default {
  props: {
    post: Object
  }
};
</script>

<style scoped>
.card {
  transition: all 0.2s linear;
  margin: 20px;
  padding: 20px;
}

.card:hover {
  transform: scale(1.01);
}

.shadow {
  -webkit-box-shadow: 0px 4px 10px 0px rgba(0, 0, 0, 0.25); /* Safari 3-4, iOS 4.0.2 - 4.2, Android 2.3+ */
  -moz-box-shadow: 0px 4px 10px 0px rgba(0, 0, 0, 0.25); /* Firefox 3.5 - 3.6 */
  box-shadow: 0px 4px 10px 0px rgba(0, 0, 0, 0.25); /* Opera 10.5, IE 9, Firefox 4+, Chrome 6+, iOS 5 */
}

h4 {
  color: var(--color-primary);
}

a {
  text-decoration: none;
}
</style>