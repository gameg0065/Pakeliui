<template>
  <div class="banner" v-if="!accepted">
    <p>
      Ši sistema - studentų komandos projektinis darbas, sukurtas mokymosi
      tikslais. Dabartinė sistemos versija nėra galutinė ir užbaigta, todėl ne
      visos funkcijos yra tinkamai įgyvendintos, jos gali turėti klaidų ar
      netikslumų. Įspėjame, kad Pakeliui komanda už vartotojų duomenų saugumą
      neatsako.
    </p>
    <Button
      text="supratau"
      :isSecondary="true"
      :isOutlined="true"
      @click.native.prevent="set(true)"
    />
  </div>
</template>

<script>
import Button from '@/components/Button.vue';

export default {
  name: 'InProgressBanner',
  components: {
    Button,
  },
  data() {
    return {
      accepted: false,
      keyName: 'GDPR:accepted',
    };
  },
  created() {
    this.accepted = this.get();
  },
  methods: {
    get() {
      return localStorage.getItem(this.keyName);
    },
    set(value) {
      localStorage.setItem(this.keyName, value);
      this.accepted = value;
    },
  },
};
</script>

<style lang="scss">
.banner {
  align-items: center;
  background-color: var(--color-secondary-dark-1);
  display: flex;
  padding: 20px;

  p {
    color: white;
    font-size: 14px;
    line-height: unset;
  }
}
</style>
