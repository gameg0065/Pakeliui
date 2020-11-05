<template>
  <div class="about">
    <div class="body">
      <div id="menu">Menu-work in progress</div>
      <h2>Apie mus</h2>
      <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Facere est quisquam, illo doloribus tempore numquam blanditiis, velit eligendi accusantium doloremque aspernatur! Nulla veniam molestias pariatur, explicabo doloremque hic velit consequatur.</p>
      <div class="profiles">
          <div class="profile">
              <img src="../assets/images/user-undefined.png" alt="img">
              <p>Aiste Stonciute</p>
          </div>

          <div class="profile">
              <img src="../assets/images/user-undefined.png" alt="img">
              <p>Ignas Pangonis</p>
          </div>

          <div class="profile">
              <img src="../assets/images/user-undefined.png" alt="img">
              <p>Benjaminas Racas</p>
          </div>

          <div class="profile">
              <img src="../assets/images/user-undefined.png" alt="img">
              <p>Vadimas Kozemiakinas</p>
          </div>

          <div class="profile">
              <img src="../assets/images/user-undefined.png" alt="img">
              <p>Tomas Kvedravicius</p>
          </div>

          <div class="profile">
              <img src="../assets/images/user-undefined.png" alt="img">
              <p>Tomas Sinkunas</p>
          </div>
      </div>

      
      <Footer id="footer">
        <Footer/>
      </Footer>
    </div>
    
    
  </div>



    
  
</template>





<script lang="ts">
import Vue from "vue";
import Footer from "@/components/Footer.vue";

export default Vue.extend({
  name: "About",
  components: {
    Footer
  }
});
</script>
<style lang="scss">
@import "../assets/styles/about-us.css";
</style>
