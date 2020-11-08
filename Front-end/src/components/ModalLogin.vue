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
            <input type="email" id="email" ref="email" v-model="id" />
          </div>
          <div>
            <label for="password"> Slaptažodis </label>
            <input type="password" id="password" />
          </div>
          <div>
            <label><input type="checkbox" /> Prisimink mane </label>
          </div>
          <small>
            <a href="#" @click.prevent="remindPassword">
              Pamiršai slaptažodį?
            </a>
          </small>
          <div>
            <Button :click="submit" text="prisijungti" :isOutlined="true" />
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
    Button
  },
  data() {
    return {
      id: this.$store.getters.userID
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
      const id = parseInt(this.id);
      const user = UserService.getUser(id);
      if (!user) {
        return alert('Toks vartotojas neegzistuoja');
      }

      this.$store.commit('SET_USER_ID', id);
      this.$store.commit('SET_LOGGED_IN', true);
      this.hide();
    }
  },
  mount() {
    this.show();
  }
};
</script>

<style scoped>
.container {
  padding: 20px;
}
</style>