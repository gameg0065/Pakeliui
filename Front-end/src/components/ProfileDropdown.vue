<template>
  <div class="dropdown shadow">
    <router-link
      @click.native="emitClick"
      :to="{ name: 'user', params: { id: userID } }"
    >
      <div class="dropbutton">
        <img src="../assets/icons/user.svg" />
        <p>Mano profilis</p>
      </div>
    </router-link>

    <router-link
      @click.native="emitClick"
      :to="{ name: 'user-edit' }"
    >
      <div class="dropbutton">
        <img src="../assets/icons/settings.svg" />
        <p>Redaguoti profilį</p>
      </div>
    </router-link>

    <router-link @click.native="emitClick" :to="{ name: 'user-history' }">
      <div class="dropbutton">
        <img src="../assets/icons/archive.svg" />
        <p>Rezervacijų istorija</p>
      </div>
    </router-link>

    <div v-if="isDriver">
      <router-link @click.native="emitClick" :to="{ name: 'post-create' }">
        <div class="dropbutton">
          <img src="../assets/icons/pen-tool.svg" />
          <p>Sukurti skelbimą</p>
        </div>
      </router-link>


      <router-link @click.native="emitClick" :to="{ name: 'driver-history' }">
        <div class="dropbutton">
          <img src="../assets/icons/archive.svg" />
          <p>Skelbimų istorija</p>
        </div>
      </router-link>

      <div class="dropbutton">
        <img src="../assets/icons/inbox.svg" />
        <p>Gautos rezervacijos</p>
      </div>
    </div>
    <router-link @click.native="logout" :to="{ name: 'home' }">
      <div class="dropbutton">
        <img src="../assets/icons/power.svg" />
        <p>Atsijungti</p>
      </div>
    </router-link>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
  computed: {
    ...mapGetters(['isLoggedIn', 'isDriver', 'userID']),
  },
  methods: {
    emitClick() {
      this.$emit('on-profile-button-click');
    },
    logout() {
      this.$store.commit('SET_LOGGED_IN', false);
      this.emitClick();
    },
  },
};
</script>

<style>
.dropdown {
  background-color: white;
  position: absolute;
  right: 0px;
  top: 100px;
  width: 250px;
}

.dropbutton {
  cursor: pointer;
  height: 40px;
}

.dropbutton p {
  color: var(--color-black);
  padding-top: 5px;
}

.dropbutton img {
  float: left;
  padding: 8px;
}

.dropbutton:hover {
  background-color: var(--color-primary-light-1);
}

.dropbutton:active {
  background-color: var(--color-primary-dark-1);
}

.dropbutton:hover p {
  color: white;
}

.shadow {
  -webkit-box-shadow: 0px 4px 10px 0px rgba(0, 0, 0, 0.25); /* Safari 3-4, iOS 4.0.2 - 4.2, Android 2.3+ */
  -moz-box-shadow: 0px 4px 10px 0px rgba(0, 0, 0, 0.25); /* Firefox 3.5 - 3.6 */
  box-shadow: 0px 4px 10px 0px rgba(0, 0, 0, 0.25); /* Opera 10.5, IE 9, Firefox 4+, Chrome 6+, iOS 5 */
}
</style>