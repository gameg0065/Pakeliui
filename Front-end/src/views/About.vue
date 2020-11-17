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
          <Avatar
            size="big"
            :path="require('../assets/images/team/aiste-stonciute.png')"
          />
          <p>Aistė Stončiūtė</p>
        </div>

        <div class="profile">
          <Avatar
            size="big"
            :path="require('../assets/images/team/benjaminas-racas.png')"
          />
          <p>Benjaminas Račas</p>
        </div>

        <div class="profile">
          <Avatar
            size="big"
            :path="require('../assets/images/team/ignas-pangonis.png')"
          />
          <p>Ignas Pangonis</p>
        </div>

        <div class="profile">
          <Avatar
            size="big"
            :path="require('../assets/images/team/tomas-kvedaravicius.png')"
          />
          <p>Tomas Kvedravičius</p>
        </div>

        <div class="profile">
          <Avatar
            size="big"
            :path="require('../assets/images/team/tomas-sinkunas.png')"
          />
          <p>Tomas Šinkūnas</p>
        </div>

        <div class="profile">
          <Avatar
            size="big"
            :path="require('../assets/images/team/vadimas-kozemiakinas.png')"
          />
          <p>Vadimas Kožemiakinas</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
export default {
  name: 'About',
  components: {
    Avatar,
  },
};
</script>
<style lang="scss">
@import '../assets/styles/about-us.css';
</style>
