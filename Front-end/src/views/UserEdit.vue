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
        <div class="flex align-end" :class="{ error: wipUser.name.error }">
          <label for="user-name"> Vardas, pavardė* </label>
          <div class="flex direction-column grow">
            <span>{{ wipUser.name.error }}</span>
            <input
              type="text"
              id="user-name"
              v-model.trim="wipUser.name.value"
            />
          </div>
        </div>

        <div class="flex align-end" :class="{ error: wipUser.birthDate.error }">
          <label for="user-birthdate"> Gimimo metai* </label>
          <div class="flex direction-column grow">
            <span>{{ wipUser.birthDate.error }}</span>
            <Datepicker
              id="user-birthdate"
              v-model="wipUser.birthDate.value"
              format="yyyy-MM-dd"
              :monday-first="true"
            />
          </div>
        </div>

        <div class="flex align-baseline">
          <label for="contacts-city">Miestas</label>
          <input type="text" id="city" v-model.trim="user.city" />
        </div>

        <div
          class="flex align-end"
          :class="{ error: wipUser.phoneNumber.error }"
        >
          <label for="contacts-phone"> Telefonas </label>
          <div class="flex direction-column grow">
            <span>{{ wipUser.phoneNumber.error }}</span>
            <input
              type="text"
              id="contacts-phone"
              v-model.trim="wipUser.phoneNumber.value"
            />
          </div>
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

        <div
          class="flex align-end"
          :class="{ error: wipUser.facebookLink.error }"
        >
          <label for="contacts-facebook"> Facebook paskyra </label>
          <div class="flex direction-column grow">
            <span>{{ wipUser.facebookLink.error }}</span>
            <input
              type="text"
              id="contacts-facebook"
              v-model.trim="wipUser.facebookLink.value"
            />
          </div>
        </div>

        <div class="flex align-baseline">
          <label for="user-contact">Susisiekite su manimi*</label>
          <select id="user-contact" v-model="user.contactMethod">
            <option
              v-for="(option, index) in contactOptions"
              :key="index"
              :value="option.value"
            >
              {{ option.text }}
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
          <div class="flex align-end" :class="{ error: wipCar.model.error }">
            <label for="car-model"> Transporto priemonė* </label>
            <div class="flex direction-column grow">
              <span>{{ wipCar.model.error }}</span>
              <input
                type="text"
                id="car-model"
                v-model.trim="wipCar.model.value"
              />
            </div>
          </div>

          <div class="flex align-end" :class="{ error: wipCar.date.error }">
            <label for="car-date"> Pagaminimo metai* </label>
            <div class="flex direction-column grow">
              <span>{{ wipCar.date.error }}</span>
              <Datepicker
                id="car-date"
                v-model="wipCar.date.value"
                format="yyyy-MM-dd"
                :monday-first="true"
              />
            </div>
          </div>

          <div class="flex align-baseline">
            <label for="driver-contact">Susisiekite su manimi*</label>
            <select id="driver-contact" v-model="user.driverContactMethod">
              <option
                v-for="(option, index) in contactOptions"
                :key="index"
                :value="option.value"
              >
                {{ option.text }}
              </option>
            </select>
          </div>

          <div class="flex align-baseline">
            <label for="driver-about">Vairavimo įgūdžiai</label>
            <textarea id="driver-about" v-model.trim="user.aboutDriver" />
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
import DateFormat from '@/assets/DateFormat.js';
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
      newUserPhoto: null,
      newCarPhoto: null,
      wipCar: this.resetWipCar(),
      wipUser: this.resetWipUser(),
      contactOptions: [
        {
          text: 'Elektroniniu paštu',
          value: 'email',
        },
        {
          text: 'Facebook nuoroda',
          value: 'facebookLink',
        },
        {
          text: 'Telefonu',
          value: 'phoneNumber',
        },
      ],
    };
  },
  created() {
    const user = this.user;
    const wipUser = this.wipUser;

    user.contactMethod = user.contactMethod || 'email';
    user.driverContactMethod = user.driverContactMethod || 'email';

    wipUser.name.value = user.name || '';
    wipUser.birthDate.value = user.birthDate || '';
    wipUser.phoneNumber.value = user.phoneNumber || '';
    wipUser.facebookLink.value = user.facebookLink || '';

    const wipCar = this.wipCar;
    wipCar.model.value = user.car.model || '';
    wipCar.date.value = user.car.date || '';
  },
  methods: {
    changeCarPhoto(event) {
      const newCarPhoto = event.target.files[0];
      if (newCarPhoto) {
        this.newCarPhoto = newCarPhoto;
      }
    },
    changeUserPhoto(event) {
      const newUserPhoto = event.target.files[0];
      if (newUserPhoto) {
        this.newUserPhoto = newUserPhoto;
      }
    },
    checkboxChanged() {
      const user = this.user;
      const car = this.user.car || {};

      if (user.isDriver) {
        car.manufacturer = car.manufacturer || '';
        car.model = car.model || '';
        car.picturePath = car.picturePath || '';
        car.date = car.date || '';
      }
    },
    deleteProfile() {
      const user = this.user;
      this.$modal.show('modal-notification', {
        title: 'Patvirtinimas',
        text: 'Ar tikrai norite ištrinti profilį? Kelio atgal nėra.',
        button: {
          title: 'ištrinti',
          action() {
            Service.deleteUser({ userId: user.userId })
              .then((response) => {
                this.$modal.hide('modal-notification');

                this.$router
                  .push({
                    name: 'home',
                  })
                  .then(() => {
                    this.$store.dispatch('logout');
                  });
              })
              .catch((error) => {
                console.log('Could not delete user', error);
              });
          },
        },
      });
    },
    getUserPhotoPath() {
      let photo = this.user.picturePath;
      if (this.newUserPhoto) {
        photo = URL.createObjectURL(this.newUserPhoto);
      }
      return photo;
    },
    getCarPhotoPath() {
      let photo = this.user.car.picturePath;
      if (this.newCarPhoto) {
        photo = URL.createObjectURL(this.newCarPhoto);
      }
      return photo;
    },
    validateContacts(contactMethod, user) {
      if (contactMethod === 'phoneNumber') {
        user.facebookLink.error = '';
        user.phoneNumber.error = !user.phoneNumber.value
          ? 'Įveskite telefono numerį'
          : '';
      } else if (contactMethod === 'facebookLink') {
        user.phoneNumber.error = '';
        user.facebookLink.error = !user.facebookLink.value
          ? "Įveskite Facebook'o nuorodą"
          : '';
      }
    },
    async saveProfile() {
      const user = this.user;
      const wipCar = this.wipCar;
      const wipUser = this.wipUser;

      wipUser.name.error = !wipUser.name.value
        ? 'Įveskite vardą ir pavardę'
        : '';

      let birthDateError = '';
      if (!wipUser.birthDate.value) {
        birthDateError = 'Įveskite gimimo datą';
      } else {
        const userAge = DateFormat.getAge(wipUser.birthDate.value);
        const minUserAge = 18;
        if (userAge < 0) {
          birthDateError = 'Vartotojai iš ateities yra draudžiami';
        } else if (userAge < minUserAge) {
          birthDateError =
            'Tai kad tu dar snarglys. Palauk kol tau bus ' +
            minUserAge +
            ' metų';
        }
      }

      wipUser.birthDate.error = birthDateError;

      this.validateContacts(user.contactMethod, wipUser);

      if (user.isDriver) {
        wipCar.model.error = !wipCar.model.value
          ? 'Įveskite automobilio modelį'
          : '';

        let carDateError = '';
        if (!wipCar.date.value) {
          carDateError = 'Įveskite automobilio pagaminimo datą';
        } else {
          const carAge = DateFormat.getAge(wipCar.date.value);
          const minCarAge = 10;
          if (carAge < 0) {
            carDateError = 'Automobiliai iš ateities yra draudžiami';
          } else if (carAge > minCarAge) {
            carDateError = 'Metalo laužas. Max ' + minCarAge + ' metų';
          }
        }
        wipCar.date.error = carDateError;

        this.validateContacts(user.driverContactMethod, wipUser);
      }

      const userFormHasErrors = Object.keys(wipUser).some((key) => {
        return wipUser[key].error !== '';
      });

      const carFormHasErrors = Object.keys(wipCar).some((key) => {
        return wipCar[key].error !== '';
      });

      if (userFormHasErrors || carFormHasErrors) {
        return;
      }

      user.name = wipUser.name.value;
      user.birthDate = DateFormat.toDateString(wipUser.birthDate.value);
      user.phoneNumber = wipUser.phoneNumber.value;
      user.facebookLink = wipUser.facebookLink.value;
      if (user.isDriver) {
        user.car.model = wipCar.model.value;
        user.car.date = DateFormat.toDateString(wipCar.date.value);
      }

      if (this.newUserPhoto) {
        await this.uploadPhoto(this.newUserPhoto, user);
      }

      if (this.newCarPhoto) {
        await this.uploadPhoto(this.newCarPhoto, this.user.car);
      }

      Service.putUser(this.user)
        .then((response) => {
          this.$store.dispatch('updateUser', this.user);
        })
        .then(() => {
          this.$router.push({
            name: 'user',
            params: { id: this.user.userId },
          });
        })
        .catch((error) => {
          console.log('Could not edit user', error);
        });
    },

    uploadPhoto(photo, target) {
      return Service.uploadPhoto(photo)
        .then((response) => {
          target.picturePath = response.data.secure_url;
        })
        .catch((error) => {
          console.log('Could not upload photo', error);
        });
    },
    resetWipCar() {
      return {
        model: {
          value: '',
          error: '',
        },
        date: {
          value: '',
          error: '',
        },
      };
    },
    resetWipUser() {
      return {
        name: {
          value: '',
          error: '',
        },
        birthDate: {
          value: '',
          error: '',
        },
        phoneNumber: {
          value: '',
          error: '',
        },
        facebookLink: {
          value: '',
          error: '',
        },
      };
    },
  },
};
</script>

<style lang="scss">
@import '../assets/styles/user-edit.scss';
</style>