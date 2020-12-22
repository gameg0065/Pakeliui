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
@import '../assets/styles/banner.scss';
</style>
