<template>
  <div>
    <modal
      name="modal-login"
      @opened="onOpen"
      :adaptive="true"
      :height="270"
      :width="400"
      :styles="{ 'border-radius': '10px' }"
      :focusTrap="true"
    >
      <div class="container">
        <div>
          <h3>Prisijunk</h3>
          <small>
            Neturi paskyros?
            <a href="#" @click.prevent="showModalRegister">Užsiregistruok</a>
          </small>
        </div>

        <form>
          <div>
            <label for="email"> Elektroninis paštas </label>
            <input type="email" id="email" ref="email" v-model="credentials.id" />
          </div>
          <div>
            <label for="password"> Slaptažodis </label>
            <input type="password" id="password" v-model="credentials.password"/>
          </div>
          <div>
            <label><input type="checkbox" v-model="credentials.rememberMe" /> Prisimink mane </label>
          </div>
          <small>
            <a href="#" @click.prevent="remindPassword">
              Pamiršai slaptažodį?
            </a>
          </small>
          <div>
            <Button :click="submit" text="prisijungti" :isOutlined="true" />
          </div>

          <div>
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
      credentials:{
        id: 110,
        password: null,
        rememberMe: null,
      }
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

<style scoped>
.container {
  padding: 20px;
}

.red {
  color: red;
}
</style>