<template>
  <div class="modal">
    <modal
      name="modal-register"
      @opened="onOpen"
      :adaptive="true"
      :height="400"
      :width="600"
      :styles="{ 'border-radius': '10px' }"
      :focusTrap="true"
    >
      <div class="container">
        <div class="line">
          <h3>Registracija</h3>
          <small>
            Jau turite paskyrą?
            <a href="#" @click.prevent="showModalLogin"> Prisijunkite </a>
          </small>
        </div>

        <form>
          <div class="line">
            <label for="name" class="width130"> Vardas, pavardė </label>
            <input
              type="text"
              id="name"
              ref="name"
              v-model.trim="credentials.name"
            />
          </div>
          <div class="line">
            <label for="email" class="width130"> Elektroninis paštas </label>
            <input type="email" id="email" v-model.trim="credentials.email" />
          </div>
          <div class="line">
            <label for="password" class="width130"> Slaptažodis </label>
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
                <router-link :to="{ name: 'terms' }"> Sąlygomis </router-link>
              </span>
            </label>
          </div>
          <div>
            <Button :click="submit" text="Registruotis" :isOutlined="true" />
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
      // validate here
      this.hide();
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