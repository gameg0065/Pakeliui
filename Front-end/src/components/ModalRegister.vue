<template>
  <div>
    <a href="/#register" @click.prevent="show"> REGISTRUOTIS </a>

    <modal
      name="modal-register"
      @opened="onOpen"
      :adaptive="true"
      :height="270"
      :width="400"
      :styles="{ 'border-radius': '10px' }"
      :focusTrap="true"
    >
      <div class="container">
        <h3>Užsiregistruok</h3>
        <small>
          Jau turi paskyrą?
          <a href="#" @click.prevent="showLogin">
            Prisijunk
          </a>
        </small>

        <form>
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
              ><input type="checkbox" name="remember" /> Sutinku su Vartojimo
              Sąlygom
            </label>
          </div>
          <div class="form-group">
            <button @click.prevent="submit">
              Sukurti paskyrą
            </button>
          </div>
        </form>
      </div>
    </modal>
  </div>
</template>

<script>
export default {
  name: 'ModalRegister',
  methods: {
    hide() {
      this.$modal.hide('modal-register');
    },
    onOpen() {
      this.$refs.email.focus();
    },
    show() {
      this.$modal.show('modal-register');
    },
    showLogin() {
      this.hide();
      this.$modal.show('modal-login');
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

.vm--modal {
  background-color: red;
  border-radius: 100px;
}
</style>