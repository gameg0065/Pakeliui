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
          <a href="#" @click.prevent="showModalLogin"> Prisijunk </a>
        </small>

        <form>
          <div>
            <label for="name"> Vardas, pavardė </label>
            <input type="text" id="name" v-model.trim="credentials.name" />
          </div>
          <div>
            <label for="email"> Elektroninis paštas </label>
            <input
              type="email"
              id="email"
              ref="email"
              v-model.trim="credentials.email"
            />
          </div>
          <div>
            <label for="password"> Slaptažodis </label>
            <input
              type="password"
              id="password"
              v-model.trim="credentials.password"
            />
          </div>
          <div>
            <label
              ><input type="checkbox" v-model="credentials.TOCEnabled" />
              Sutinku su 
              <span @click="hide">
                <router-link :to="{ name: 'terms' }">
                  Sąlygomis
                </router-link> 
              </span>
            </label>
          </div>
          <div>
            <Button :click="submit" text="Sukurti paskyrą" :isOutlined="true" />
            <!-- <button @click.prevent="submit">
              Sukurti paskyrą
            </button> -->
          </div>
        </form>
      </div>
    </modal>
  </div>
</template>

<script>
import Button from '@/components/Button.vue';

export default {
  name: 'ModalRegister',
  components: {
    Button,
  },
  data() {
    return {
      credentials: {
        email: null,
        name: null,
        password: null,
        TOCEnabled: null,
      },
    };
  },
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
</style>