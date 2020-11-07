<template>
  <div class="card shadow">
    <img v-if="comment.author.photo" :src="comment.author.photo"/>
    <p>{{ comment.author.name }}</p>
    <small>{{ comment.date }}</small>
    <p>{{ comment.text }}</p>
  </div>
</template>

<script>
export default {
  props: {
    comment: {
      type: Object
    }
  }
};
</script>

<style>
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
</style>