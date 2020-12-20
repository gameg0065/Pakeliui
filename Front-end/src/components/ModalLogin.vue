<template>
  <div class="modal">
    <modal
      name="modal-login"
      @opened="onOpen"
      :adaptive="true"
      height="auto"
      :width="600"
      :styles="{ 'border-radius': '10px' }"
      :focusTrap="true"
    >
      <div class="container">
        <div class="flex align-baseline justify-between">
          <h3>Prisijungimas</h3>
          <small>
            Neturite paskyros?
            <a href="#" @click.prevent="showModalRegister">Registruokitės</a>
          </small>
        </div>

        <form>
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
                ref="email"
                v-model.trim="credentials.email.value"
                @keydown="onEmailChange"
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
                id="password"
                v-model="credentials.password.value"
                @keydown="onPasswordChange"
              />
            </div>
          </div>

          <div
            class="flex direction-column mt-50"
            :class="{ error: generalError }"
          >
            <span class="align-self-center"> {{ generalError }}</span>
            <Button
              text="prisijungti"
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
  name: 'ModalLogin',
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
    onEmailChange() {
      this.resetEmailError();
      this.resetGeneralError();
    },
    onPasswordChange() {
      this.resetPasswordError();
      this.resetGeneralError();
    },
    resetEmailError() {
      this.credentials.email.error = '';
    },
    resetPasswordError() {
      this.credentials.password.error = '';
    },
    resetGeneralError() {
      this.generalError = '';
    },
    hide() {
      this.$modal.hide('modal-login');
    },
    onOpen() {
      this.$refs.email.focus();
    },
    remindPassword() {
      alert('Tai ne kažką, ne kažką.');
    },
    show() {
      this.$modal.show('modal-login');
    },
    showModalRegister() {
      this.hide();
      this.$modal.show('modal-register');
    },
    submit() {
      const email = this.credentials.email;
      if (!email.value) {
        email.error = 'prašom įvesti elektroninį paštą';
      } else if (!Utils.validateEmail(email.value)) {
        email.error = 'neteisinga forma';
      } else {
        this.resetEmailError();
      }

      const password = this.credentials.password;
      password.error = !password.value ? 'prašom įvesti slaptažodį' : '';

      if (!email.error && !password.error) {
        Service.getUserByEmailAndPass(email.value, password.value)
          .then((response) => {
            if (response.status === 200) {
              const user = response.data;
              this.$store.dispatch('login', user).then(() => {
                this.hide();
              });
            } else {
              this.generalError = 'toks vartotojas neegzistuoja';
            }
          })
          .catch((error) => {
            console.log('Could not get user by email and password', error);
          });
      }
    },
    resetToDefaults() {
      return {
        email: {
          value: '',
          error: '',
        },
        password: {
          value: '',
          error: '',
        },
        rememberMe: null,
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