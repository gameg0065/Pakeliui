<template>
  <div class="pageNotFound">
    <h1>404</h1>
    <p>Ups, pataikei kur nereikia - toks puslapis neegzistuoja!</p>
    <div>
      <router-link :to="{ name: 'home' }">
        <Button
          text="grįžti į pagrindinį"
          :isSecondary="false"
          :isLarge="true"
          :isOutlined="true"
          class="mt-20"
        />
      </router-link>
    </div>
    <img src="../assets/images/404-image.png" />
  </div>
</template>

<script>
import Button from '@/components/Button.vue';
export default {
  name: 'PageNotFound',
  components: {
    Button,
  },
};
</script>

<style>
.pageNotFound h1 {
  color: var(--color-secondary);
  font-size: 100px;
}
</style>