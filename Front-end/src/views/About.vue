<template>
  <div class="about">
    <div class="body">
      <h2>Apie mus</h2>
      <p>
        Lorem ipsum dolor sit amet consectetur adipisicing elit. Facere est
        quisquam, illo doloribus tempore numquam blanditiis, velit eligendi
        accusantium doloremque aspernatur! Nulla veniam molestias pariatur,
        explicabo doloremque hic veli consequatur.
      </p>
      <div class="profiles">
        <div class="profile">
          <Avatar size="big" path="https://images.unsplash.com/photo-1476493279419-b785d41e38d8?ixlib=rb-0.3.5&q=80&fm=jpg&crop=faces&fit=crop&h=200&w=200&s=61eaea85f1aa3d065400179c78163f15"/>
          <p>Aistė Stončiūtė</p>
        </div>

        <div class="profile">
          <Avatar size="big" path="https://uifaces.co/our-content/donated/FJkauyEa.jpg"/>
          <p>Ignas Pangonis</p>
        </div>

        <div class="profile">
          <Avatar size="big" path="https://uifaces.co/our-content/donated/vIqzOHXj.jpg"/>
          <p>Benjaminas Račas</p>
        </div>

        <div class="profile">
          <Avatar size="big" path="https://uifaces.co/our-content/donated/1H_7AxP0.jpg"/>
          <p>Vadimas Kožemiakinas</p>
        </div>

        <div class="profile">
          <Avatar size="big" path="https://uifaces.co/our-content/donated/Square__small_.jpg"/>
          <p>Tomas Kvedravičius</p>
        </div>

        <div class="profile">
          <Avatar size="big" path="https://uifaces.co/our-content/donated/Xp0NB-TL.jpg"/>
          <p>Tomas Šinkūnas</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
export default {
  components: {
    Avatar
  }
};
</script>
<style lang="scss">
@import '../assets/styles/about-us.css';
</style>
