<template>
  <div class="modal">
    <modal
      name="modal-register"
      @opened="onOpen"
      :adaptive="true"
      height="auto"
      :width="600"
      :styles="{ 'border-radius': '10px' }"
      :focusTrap="true"
    >
      <div class="container">
        <div class="flex align-baseline justify-between">
          <h3>Registracija</h3>
          <small>
            Jau turite paskyrą?
            <a href="#" @click.prevent="showModalLogin"> Prisijunkite </a>
          </small>
        </div>

        <form>
          <div
            class="flex align-end"
            :class="{ error: credentials.name.error }"
          >
            <label for="name"> Vardas, pavardė* </label>
            <div class="flex direction-column grow">
              <span>{{ credentials.name.error }}</span>
              <input
                type="text"
                id="name"
                ref="name"
                v-model.trim="credentials.name.value"
              />
            </div>
          </div>

          <div
            class="flex align-end"
            :class="{ error: credentials.email.error }"
          >
            <label for="email"> Elektroninis paštas* </label>
            <div class="flex direction-column grow">
              <span>{{ credentials.email.error }}</span>
              <input
                type="email"
                id="email"
                v-model.trim="credentials.email.value"
              />
            </div>
          </div>

          <div
            class="flex align-end"
            :class="{ error: credentials.password.error }"
          >
            <label for="password"> Slaptažodis* </label>
            <div class="flex direction-column grow">
              <span>{{ credentials.password.error }}</span>
              <input
                type="password"
                id="nampassworde"
                v-model.trim="credentials.password.value"
              />
            </div>
          </div>

          <label
            ><input type="checkbox" v-model="credentials.TOCEnabled.value" />
            Sutinku su
            <span @click="hide">
              <router-link :to="{ name: 'terms' }"> Sąlygomis </router-link>
            </span>
          </label>

          <div
            class="flex direction-column mt-50"
            :class="{ error: generalError }"
          >
            <span class="align-self-center"> {{ generalError }}</span>
            <Button
              text="Registruotis"
              @click.native.prevent="submit"
              :isOutlined="true"
            />
          </div>
        </form>
      </div>
    </modal>
  </div>
</template>

<script>
import Button from '@/components/Button.vue';

import Service from '@/services/Service';
import Utils from '@/assets/Utils.js';

export default {
  name: 'ModalRegister',
  components: {
    Button,
  },
  data() {
    return {
      credentials: this.resetToDefaults(),
      generalError: '',
    };
  },
  methods: {
    hide() {
      this.$modal.hide('modal-register');
    },
    onOpen() {
      this.$refs.name.focus();
    },
    show() {
      this.$modal.show('modal-register');
    },
    showModalLogin() {
      this.hide();
      this.$modal.show('modal-login');
    },
    submit() {
      const name = this.credentials.name;
      name.error = !name.value ? 'prašom įvesti vardą ir pavardę' : '';

      const email = this.credentials.email;
      if (!email.value) {
        email.error = 'prašom įvesti elektroninį paštą';
      } else if (!Utils.validateEmail(email.value)) {
        email.error = 'neteisinga forma';
      } else {
        email.error = '';
      }

      const password = this.credentials.password;
      password.error = !password.value ? 'prašom įvesti slaptažodį' : '';

      const TOCEnabled = this.credentials.TOCEnabled;
      TOCEnabled.error = this.generalError = !TOCEnabled.value
        ? 'nesutinkate su sąlygom?'
        : '';

      if (!TOCEnabled.error && !name.error && !email.error && !password.error) {
        const user = {
          name: name.value,
          email: email.value,
          password: password.value,
          registrationDate: new Date().toISOString().split('.')[0],
        };

        Service.postUser(user)
          .then((response) => {
            console.log('User created', response);

            this.hide();
          })
          .catch((error) => {
            console.log('Could not create new user', error);
          });
      }
    },
    resetToDefaults() {
      return {
        email: {
          value: '',
          error: '',
        },
        name: {
          value: '',
          error: '',
        },
        password: {
          value: '',
          error: '',
        },
        TOCEnabled: {
          value: false,
          error: '',
        },
      };
    },
  },
  mount() {
    this.show();
  },
};
</script>

<style lang="scss">
@import '../assets/styles/modal.scss';
</style>