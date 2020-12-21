<template>
  <div class="banner" v-if="isOpen">
    <div class="banner_content">
      <slot name="message">
        {{ message }}
      </slot>
    </div>
    <div class="banner_button accept" @click="accept">
      {{ buttonTextAccept }}
    </div>
  </div>
</template>

<script>
export default {
  name: 'InProgressBanner',
  props: {
    buttonTextAccept: {
      type: String,
      default: 'Supratau',
    },
    message: {
      type: String,
      default:
        'Ši sistema - studentų komandos projektinis darbas, sukurtas mokymosi tikslais. Dabartinė sistemos versija nėra galutinė ir užbaigta, todėl ne visos funkcijos yra tinkamai įgyvendintos, jos gali turėti klaidų ar netikslumų. Įspėjame, kad Pakeliui komanda už vartotojų duomenų saugumą neatsako.',
    },
  },
  data() {
    return {
      isOpen: false,
    };
  },
  created() {
    if (!this.getGDPR() == true) {
      this.isOpen = true;
    }
  },
  methods: {
    getGDPR() {
      return localStorage.getItem('GDPR:accepted', true);
    },
    accept() {
      this.isOpen = false;
      localStorage.setItem('GDPR:accepted', true);
    },
  },
};
</script>

<style>
.banner {
  position: fixed;
  display: grid;
  grid-template-columns: 1fr 1fr 1fr 1fr 1fr 1fr;
  grid-gap: 12px;
  padding: 10px;
  background: #f2f2f2;
}

.banner_content {
  grid-column: auto/ span 5;
  padding: 5px;
  text-align: center;
}

.banner_button {
  margin: 15px 0;
  grid-column: auto / span 1;
  text-align: center;
}
.banner_button.accept {
  padding: 5px 0;
  background: #42b983;
  color: #ffffff;
  cursor: pointer;
}
.banner_button.accept:hover {
  background: #42b955;
}
</style>
