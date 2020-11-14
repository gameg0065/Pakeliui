<template>
  <div class="pageNotFound">
    <h1>404</h1>
    <p>Ups, pataikei kur nereikia - toks puslapis neegzistuoja</p>
    <div>
      <router-link :to="{ name: 'home' }">
        <Button
          class="button"
          text="grįžti į pagrindinį"
          :isSecondary="false"
          :isLarge="true"
          :isOutlined="true"
        />
      </router-link>
    </div>
    <img src="../assets/images/404-image.png" />
  </div>
</template>

<script>
import Button from '@/components/Button.vue';
export default {
  components: {
    Button,
  },
};
</script>

<style>
.pageNotFound {
  margin: 0 auto;
  text-align: center;
}

.pageNotFound h1 {
  color: var(--color-secondary);
  font-size: 100px;
}
.pageNotFound .button {
  margin: 20px;
}
</style>