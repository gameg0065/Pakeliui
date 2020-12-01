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
                v-model.trim="credentials.email.text"
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
                v-model="credentials.password.text"
              />
            </div>
          </div>

          <div class="flex justify-between">
            <label class="checkbox"
              ><input type="checkbox" v-model="credentials.rememberMe" />
              Prisiminkite mane
            </label>
            <small>
              <a href="#" @click.prevent="remindPassword">
                Pamiršote slaptažodį?
              </a>
            </small>
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
import UserService from '@/services/UserService.js';
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
      if (!email.text) {
        email.error = 'prašom įvesti elektroninį paštą';
      } else if (!Utils.validateEmail(email.text)) {
        email.error = 'neteisinga forma';
      } else {
        email.error = '';
      }

      const password = this.credentials.password;
      if (!password.text) {
        password.error = 'prašom įvesti slaptažodį';
      } else {
        password.error = '';
      }

      if (!email.error && !password.error) {
        const id = parseInt(email.text);
        const user = UserService.getUser(id);
        if (!user) {
          this.generalError = 'toks vartotojas neegzistuoja';
        } else {
          this.$store.dispatch('login', user).then(() => {
            this.hide();
          });
        }
      }
    },
    resetToDefaults() {
      return {
        email: {
          text: '110@some.email',
          error: '',
        },
        password: {
          text: '',
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