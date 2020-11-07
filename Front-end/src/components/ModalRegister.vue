<template>
  <div>
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
          <a href="#" @click.prevent="showModalLogin">
            Prisijunk
          </a>
        </small>

        <form>
          <div>
            <label for="email"> Elektroninis paštas </label>
            <input type="email" id="email" ref="email" />
          </div>
          <div>
            <label for="password"> Slaptažodis </label>
            <input type="password" id="password" />
          </div>
          <div>
            <label
              ><input type="checkbox" /> Sutinku su Vartojimo Sąlygom
            </label>
          </div>
          <div>
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
    showModalLogin() {
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
</style>