<template>
  <div>
    <p>{{ label }}</p>
    <input
      :value="value"
      @input="handleInput"
      :class="{ error: hasErrors() }"
    />
    <p class="error">{{ error }}</p>
  </div>
</template>

<script>
export default {
  name: 'InputText',
  props: {
    label: String,
    error: String,
    value: String
  },
  methods: {
    hasErrors() {
      return this.error !== '';
    },

    handleInput(event) {
      this.$emit('input', event.target.value);
    }
  }
};
</script>

<style scoped>
.error {
  color: red;
  border-color: red;
}
</style>



<!-- USE CASE

<template>
  <div class="home">
    <InputText
      v-for="(element, index) in elements"
      :key="index"
      :label="element.label"
      v-model="element.text"
      :error="element.error"
    />

    <form ref="form" @submit.prevent="onSubmit">
      <input type="submit" />
    </form>
    <img alt="Vue logo" src="../assets/logo.png" />
    <HelloWorld msg="Welcome to Your Vue.js + TypeScript App" />
  </div>
</template>

<script >
import Vue from 'vue';
import HelloWorld from '@/components/HelloWorld.vue'; // @ is an alias to /src
import InputText from '@/components/InputText.vue';

export default Vue.extend({
  name: 'Home',
  components: {
    HelloWorld,
    InputText
  },
  data() {
    return {
      elements: [
        {
          label: 'vardas, pavardė',
          text: 'vienas',
          error: ''
        },
        {
          label: 'slaptažodis',
          text: 'du',
          error: ''
        }
      ],
    };
  },
  methods: {
    onSubmit() {
      this.elements.forEach(function(element) {
        if (element.text === '') {
          element.error = 'cannot be empty';
        }
      });
    }
  }
});
</script>

-->