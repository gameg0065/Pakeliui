<template>
  <div class="user-edit">
    <h2 class="page-title">Profilio redagavimas</h2>
    <div class="flex pb-50">
      <div class="flex direction-column align-center">
        <Avatar :path="getUserPhotoPath()" size="big" />
        <input
          style="display: none"
          type="file"
          accept="image/x-png,image/jpeg"
          @change="changeUserPhoto"
          ref="userPhotoInput"
        />
        <Button
          text="įkelti nuotrauką"
          :isOutlined="true"
          @click.native="$refs.userPhotoInput.click"
          class="mt-20"
        />
      </div>

      <div class="flex direction-column grow">
        <div class="flex align-baseline">
          <label for="user-name">Vardas, pavardė*</label>
          <input type="text" id="user-name" v-model.trim="user.name" />
        </div>

        <div class="flex align-baseline">
          <label for="user-birthdate">Gimimo metai*</label>
          <Datepicker
            id="user-birthdate"
            v-model="user.birthDate"
            format="yyyy-MM-dd"
            :monday-first="true"
          />
        </div>

        <div class="flex align-baseline">
          <label for="contacts-city">Miestas</label>
          <input type="text" id="city" v-model.trim="user.city" />
        </div>

        <div class="flex align-baseline">
          <label for="contacts-phone">Telefonas</label>
          <input
            type="text"
            id="contacts-phone"
            v-model.trim="user.phoneNumber"
          />
        </div>

        <div class="flex align-baseline">
          <label for="contacts-email">Elektroninis paštas</label>
          <input
            type="text"
            id="contacts-email"
            v-model.trim="user.email"
            disabled
          />
        </div>

        <div class="flex align-baseline">
          <label for="contacts-facebook">Facebook paskyra</label>
          <input
            type="text"
            id="contacts-facebook"
            v-model.trim="user.facebookLink"
          />
        </div>

        <div class="flex align-baseline">
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

        <div class="flex align-baseline">
          <label for="user-about">Apie mane</label>
          <textarea id="user-about" v-model.trim="user.userInfo" />
        </div>

        <label>
          <input
            type="checkbox"
            v-model="user.isDriver"
            v-on:change="checkboxChanged"
          />
          Esu vairuotojas
        </label>

        <div
          v-if="!user.isDriver"
          class="flex align-baseline justify-end mt-50"
        >
          <Button
            text="panaikinti profilį"
            :isOutlined="true"
            :isSecondary="true"
            :click="deleteProfile"
            class="mr-20"
          />
          <Button text="išsaugoti" :isOutlined="true" :click="saveProfile" />
        </div>
      </div>
    </div>

    <div v-if="user.isDriver">
      <h3 class="section-title">Vairuotojo profilis</h3>
      <div class="flex pb-50">
        <div class="flex direction-column align-center">
          <Avatar :path="getCarPhotoPath()" size="big" />
          <input
            style="display: none"
            type="file"
            accept="image/x-png,image/jpeg"
            @change="changeCarPhoto"
            ref="carPhotoInput"
          />
          <Button
            text="įkelti nuotrauką"
            :isOutlined="true"
            @click.native="$refs.carPhotoInput.click"
            class="mt-20"
          />
        </div>

        <div class="flex direction-column grow">
          <div class="flex align-baseline">
            <label for="car-model">Transporto priemonė*</label>
            <input type="text" id="car-model" v-model.trim="user.car.model" />
          </div>

          <div class="flex align-baseline">
            <label for="car-date">Pagaminimo metai*</label>
            <Datepicker
              id="car-date"
              v-model="user.car.year"
              format="yyyy-MM-dd"
              :monday-first="true"
            />
          </div>

          <div class="flex align-baseline">
            <label for="driver-contact">Susisiekite su manimi*</label>
            <select id="driver-contact" v-model="user.driverContactMethod">
              <option
                v-for="(option, index) in contactOptions"
                :key="index"
                :value="option"
              >
                {{ option }}
              </option>
            </select>
          </div>

          <div class="flex align-baseline">
            <label for="driver-about">Vairavimo įgūdžiai</label>
            <textarea
              id="driver-about"
              rows="3"
              v-model.trim="user.aboutDriver"
            />
          </div>

          <div class="flex align-baseline justify-end mt-50">
            <Button
              text="panaikinti profilį"
              :isOutlined="true"
              :isSecondary="true"
              :click="deleteProfile"
              class="mr-20"
            />
            <Button text="išsaugoti" :isOutlined="true" :click="saveProfile" />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
import Button from '@/components/Button.vue';

import axios from 'axios';
import Datepicker from 'vuejs-datepicker';
import Service from '@/services/Service';

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
      contactOptions: ['email', 'facebookLink', 'phoneNumber'],
      userPhoto: null,
      carPhoto: null,
    };
  },
  methods: {
    changeCarPhoto(event) {
      const carPhoto = event.target.files[0];
      if (carPhoto) {
        this.carPhoto = carPhoto;
      }
    },
    changeUserPhoto(event) {
      const userPhoto = event.target.files[0];
      if (userPhoto) {
        this.userPhoto = userPhoto;
      }
    },
    checkboxChanged() {
      const user = this.user;
      const car = this.user.car || {};

      if (user.isDriver) {
        car.manufacturer = car.manufacturer || '';
        car.model = car.model || '';
        car.picturePath = car.picturePath || '';
        car.year = car.year || '2000';
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
    getUserPhotoPath() {
      let photo = this.user.picturePath;
      if (this.userPhoto) {
        photo = URL.createObjectURL(this.userPhoto);
      }
      return photo;
    },
    getCarPhotoPath() {
      let photo = this.user.car.picturePath;
      if (this.carPhoto) {
        photo = URL.createObjectURL(this.carPhoto);
      }
      return photo;
    },
    async saveProfile() {
      if (this.userPhoto) {
        await this.uploadPhoto(this.userPhoto, this.user);
      }

      if (this.carPhoto) {
        await this.uploadPhoto(this.carPhoto, this.user.car);
      }

      Service.putUser(this.user)
        .then(() => {
          this.$store.dispatch('login', this.user);
        })
        .then(() => {
          console.log('saved user');
        })
        .catch((error) => {
          console.log('Could not edit user', error);
        });
    },

    uploadPhoto(photo, target) {
      return Service.uploadPhoto(photo)
        .then((response) => {
          target.picturePath = response.data.secure_url;
          console.log('uploaded photo', response);
        })
        .catch((error) => {
          console.log('Could not upload photo', error);
        });
    },
  },
};
</script>

<style lang="scss">
@import '../assets/styles/user-edit.scss';
</style>