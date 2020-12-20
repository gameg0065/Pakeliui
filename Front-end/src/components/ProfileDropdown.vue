<template>
  <div class="profile-dropdown shadow">
    <router-link
      @click.native="emitClick"
      :to="{ name: 'user', params: { id: user.userId } }"
    >
      <div class="dropbutton">
        <img src="../assets/icons/user.svg" />
        <p>Mano profilis</p>
      </div>
    </router-link>

    <router-link
      @click.native="emitClick"
      :to="{ name: 'user-edit', params: { id: user.userId } }"
    >
      <div class="dropbutton">
        <img src="../assets/icons/settings.svg" />
        <p>Redaguoti profilį</p>
      </div>
    </router-link>

    <router-link
      @click.native="emitClick"
      :to="{ name: 'user-history', params: { id: user.userId } }"
    >
      <div class="dropbutton">
        <img src="../assets/icons/archive.svg" />
        <p>Rezervacijų istorija</p>
      </div>
    </router-link>

    <div v-if="user.isDriver">
      <router-link @click.native="emitClick" :to="{ name: 'post-create' }">
        <div class="dropbutton">
          <img src="../assets/icons/pen-tool.svg" />
          <p>Įkelti skelbimą</p>
        </div>
      </router-link>

      <router-link
        @click.native="emitClick"
        :to="{ name: 'driver-history', params: { id: user.userId } }"
      >
        <div class="dropbutton">
          <img src="../assets/icons/archive.svg" />
          <p>Skelbimų istorija</p>
        </div>
      </router-link>

      <router-link
        @click.native="emitClick"
        :to="{ name: 'driver-requests', params: { id: user.userId } }"
      >
        <div class="dropbutton">
          <img src="../assets/icons/inbox.svg" />
          <p>Gautos rezervacijos</p>
        </div>
      </router-link>
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
export default {
  name: 'ProfileDropdown',
  computed: {
    user() {
      return this.$store.getters.getUser;
    },
  },
  methods: {
    emitClick() {
      this.$emit('on-profile-button-click');
    },
    logout() {
      this.$store.dispatch('logout');
      this.emitClick();
    },
  },
};
</script>

<style lang="scss">
@import '../assets/styles/profile-dropdown.scss';
</style>