<template>
  <div class="post-filter shadow">
    <div>
      <label for="date">Kelionės data</label>
      <Datepicker
        id="date"
        v-model="date"
        format="yyyy-MM-dd"
        :monday-first="true"
      />
    </div>

    <div>
      <label for="route-from">Iš miesto</label>
      <input type="text" id="route-from" v-model.trim="route.from" />
    </div>

    <div>
      <label for="route-to">Į miestą</label>
      <input type="text" id="route-to" v-model.trim="route.to" />
    </div>

    <Button text="ieškoti" :click="applyFilter" class="button" />
    <small>
      <a href="#" @click.prevent="resetFilter"> Išvalyti filtrą </a>
    </small>
  </div>
</template>

<script>
import Button from '@/components/Button.vue';
import Datepicker from 'vuejs-datepicker';

export default {
  name: 'PostFilter',
  components: {
    Button,
    Datepicker,
  },
  data() {
    return {
      date: '',
      route: {
        from: '',
        to: '',
      },
    };
  },
  methods: {
    applyFilter() {
      this.$emit('on-post-filter-changed', this.route, this.date);
    },
    resetFilter() {
      this.date = '';
      this.route = {
        from: '',
        to: '',
      };

      this.applyFilter();
    },
  },
};
</script>

<style lang="scss">
@import '../assets/styles/post-filter.scss';
</style>