<template>
  <div>
    <a href="/#login" @click.prevent="show"> PRISIJUNGTI </a>

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
        <h3>Prisijunk</h3>
        <small>
          Neturi paskyros?
          <a href="#" @click.prevent="showModalRegister">Užsiregistruok</a>
        </small>
        <form action="#">
          <div class="form-group">
            <label for="email"> Elektroninis paštas </label>
            <input type="email" id="email" name="email" ref="email" />
          </div>
          <div class="form-group">
            <label for="password"> Slaptažodis </label>
            <input type="password" id="password" name="password" />
          </div>
          <div class="form-group">
            <label
              ><input type="checkbox" name="remember" /> Prisimink mane
            </label>
          </div>
          <small>
            <a href="#" @click.prevent="remindPassword">
              Pamiršai slaptažodį?
            </a>
          </small>
          <div class="form-group">
            <button @click.prevent="submit">Prisijunk</button>
          </div>
        </form>
      </div>
    </modal>
  </div>
</template>

<script>
export default {
  name: 'ModalLogin',
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