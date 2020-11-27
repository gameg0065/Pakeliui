<template>
  <div>
    <div>
      <h2>Profilio redagavimas</h2>

      <div>
        <Avatar :path="user.photo" size="big" />
        <input
          style="display: none"
          type="file"
          @change="changeUserPhoto"
          ref="fileInput"
        />
        <Button
          text="įkelti nuotrauką"
          :isOutlined="true"
          @click.native="$refs.fileInput.click()"
        />
      </div>

      <div>
        <label for="user-name">Vardas, pavardė*</label>
        <input type="text" id="user-name" v-model.trim="user.name" />
      </div>

      <div>
        <label for="user-birthdate">Gimino metai*</label>
        <Datepicker
          id="user-birthdate"
          v-model="user.birthDate"
          format="yyyy-MM-dd"
          :monday-first="true"
        />
      </div>

      <div>
        <label for="contacts-city">Miestas</label>
        <input type="text" id="city" v-model.trim="user.contacts.city" />
      </div>

      <div>
        <label for="contacts-phone">Telefonas</label>
        <input
          type="text"
          id="contacts-phone"
          v-model.trim="user.contacts.phone"
        />
      </div>

      <div>
        <label for="contacts-email">Elektroninis paštas</label>
        <input
          type="text"
          id="contacts-email"
          v-model.trim="user.contacts.email"
        />
      </div>

      <div>
        <label for="contacts-facebook">Facebook paskyra</label>
        <input
          type="text"
          id="contacts-facebook"
          v-model.trim="user.contacts.facebook"
        />
      </div>

      <div>
        <label for="user-contact">Susisiekite su manimi*</label>
        <select id="user-contact" v-model="user.contactMethod">
          <option
            v-for="(option, index) in contactOptions"
            :key="index"
            :value="option"
          >
            {{ option }}
          </option>
        </select>
      </div>

      <div>
        <label for="user-about">Apie mane</label>
        <textarea id="user-about" rows="3" v-model.trim="user.about" />
      </div>

      <label
        ><input
          type="checkbox"
          v-model="user.isDriver"
          v-on:change="checkboxChanged"
        />
        Esu vairuotojas
      </label>

      <div v-if="!user.isDriver">
        <Button
          text="panaikinti profilį"
          :isOutlined="true"
          :isSecondary="true"
          :click="deleteProfile"
        />
        <Button text="išsaugoti" :isOutlined="true" :click="saveProfile" />
      </div>
    </div>

    <div v-if="user.isDriver">
      <h3>Vairuotojo profilis</h3>

      <div>
        <Avatar :path="user.driver.car.photo" size="big" />
        <Button
          :click="changeCarPhoto"
          text="įkelti nuotrauką"
          :isOutlined="true"
        />
      </div>

      <div>
        <label for="car-model">Transporto priemonė*</label>
        <input
          type="text"
          id="car-model"
          v-model.trim="user.driver.car.model"
        />
      </div>

      <div>
        <label for="car-date">Pagaminimo metai*</label>
        <Datepicker
          id="car-date"
          v-model="user.driver.car.date"
          format="yyyy-MM-dd"
          :monday-first="true"
        />
      </div>

      <div>
        <label for="driver-contact">Susisiekite su manimi*</label>
        <select id="driver-contact" v-model="user.driver.contactMethod">
          <option
            v-for="(option, index) in contactOptions"
            :key="index"
            :value="option"
          >
            {{ option }}
          </option>
        </select>
      </div>

      <div>
        <label for="driver-about">Vairavimo įgūdžiai</label>
        <textarea id="driver-about" rows="3" v-model.trim="user.driver.about" />
      </div>

      <div>
        <Button
          text="panaikinti profilį"
          :isOutlined="true"
          :isSecondary="true"
          :click="deleteProfile"
        />
        <Button text="išsaugoti" :isOutlined="true" :click="saveProfile" />
      </div>
    </div>
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
import Button from '@/components/Button.vue';

import Datepicker from 'vuejs-datepicker';
import UserService from '@/services/UserService.js';

export default {
  name: 'UserEdit',
  components: {
    Avatar,
    Button,
    Datepicker,
  },
  computed: {
    user() {
      return this.$store.getters.getUser;
    },
  },
  data() {
    return {
      contactOptions: ['email', 'facebook', 'phone'],
    };
  },
  methods: {
    changeCarPhoto() {
      alert('TODO');
    },
    changeUserPhoto() {
      alert('TODO');
      console.log(event);
      this.selectedFile = event.target.files[0];
    },
    checkboxChanged() {
      const user = this.user;
      let driver = user.driver;

      if (user.isDriver) {
        driver = driver || {};
        driver.car = driver.car || {};
        driver.contact = driver.contact || '';
        driver.about = driver.about || '';
      }
    },
    deleteProfile() {
      this.$modal.show('modal-notification', {
        title: 'Patvirtinimas',
        text: 'Ar tikrai norite ištrinti profilį? Kelio atgal nėra.',
        button: {
          title: 'ištrinti',
          action() {
            alert('TODO');
            this.$modal.hide('modal-notification');
          },
        },
      });
    },
    saveProfile() {
      alert('TODO');
    },
  },
};
</script>