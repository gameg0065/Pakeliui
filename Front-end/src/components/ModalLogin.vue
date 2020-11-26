<template>
  <div class="modal">
    <modal
      name="modal-login"
      @opened="onOpen"
      :adaptive="true"
      :height="360"
      :width="600"
      :styles="{ 'border-radius': '10px' }"
      :focusTrap="true"
    >
      <div class="container">
        <div class="line">
          <h3>Prisijungimas</h3>
          <small>
            Neturite paskyros?
            <a href="#" @click.prevent="showModalRegister">Registruokitės</a>
          </small>
        </div>

        <form>
          <div class="line">
            <label for="email" class="width130"> Elektroninis paštas </label>
            <input
              type="email"
              id="email"
              ref="email"
              v-model="credentials.id"
            />
          </div>
          <div class="line">
            <label for="password" class="width130"> Slaptažodis </label>
            <input
              type="password"
              id="password"
              v-model="credentials.password"
            />
          </div>

          <div class="line">
            <label
              ><input type="checkbox" v-model="credentials.rememberMe" />
              Prisiminkite mane
            </label>
            <small>
              <a href="#" @click.prevent="remindPassword">
                Pamiršote slaptažodį?
              </a>
            </small>
          </div>

          <div>
            <Button
              class="button"
              :click="submit"
              text="prisijungti"
              :isOutlined="true"
            />
          </div>

          <div class="line">
            <p class="red">users: 100, 101</p>
            <p class="red">drivers: 110, 111</p>
          </div>
        </form>
      </div>
    </modal>
  </div>
</template>

<script>
import Button from '@/components/Button.vue';
import UserService from '@/services/UserService.js';

export default {
  name: 'ModalLogin',
  components: {
    Button,
  },
  data() {
    return {
      credentials: {
        id: 110,
        password: null,
        rememberMe: null,
      },
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
      // validate here
      const id = parseInt(this.credentials.id);
      const user = UserService.getUser(id);
      if (!user) {
        return alert('Toks vartotojas neegzistuoja');
      }

      this.$store.dispatch('login', user).then(() => {
        this.hide();
      });
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