<template>
  <div class="user-edit">
    <h2 class="page-title">Profilio redagavimas</h2>
    <div class="flex pb-50">
      <div class="flex direction-column align-center">
        <Avatar :path="user.photo" size="big" />
        <Button
          text="įkelti nuotrauką"
          :click="changeUserPhoto"
          :isOutlined="true"
          class="mt-20"
        />
      </div>

      <div class="flex direction-column grow">
        <div class="flex align-end" :class="{ error: userTest.name.error }">
          <label for="user-name">Vardas, pavardė*</label>
          <div class="flex direction-column grow">
            <span>{{ userTest.name.error }}</span>
            <input
              type="text"
              id="user-name"
              v-model.trim="userTest.name.value"
            />
          </div>
        </div>

        <div
          class="flex align-end"
          :class="{ error: userTest.birthDate.error }"
        >
          <label for="user-birthdate">Gimino metai*</label>
          <div class="flex direction-column grow">
            <span>{{ userTest.birthDate.error }}</span>
            <Datepicker
              id="user-birthdate"
              v-model="userTest.birthDate.value"
              format="yyyy-MM-dd"
              :monday-first="true"
            />
          </div>
        </div>

        <div class="flex align-baseline">
          <label for="contacts-city">Miestas</label>
          <input
            type="text"
            id="city"
            v-model.trim="userTest.contacts.city.value"
          />
        </div>

        <div
          class="flex align-end"
          :class="{ error: userTest.contacts.phone.error }"
        >
          <label for="contacts-phone">Telefonas</label>
          <div class="flex direction-column grow">
            <span>{{ userTest.contacts.phone.error }}</span>
            <input
              type="text"
              id="contacts-phone"
              v-model.trim="userTest.contacts.phone.value"
            />
          </div>
        </div>

        <div
          class="flex align-end"
          :class="{ error: userTest.contacts.email.error }"
        >
          <label for="contacts-email">Elektroninis paštas</label>
          <div class="flex direction-column grow">
            <span>{{ userTest.contacts.email.error }}</span>
            <input
              type="text"
              id="contacts-email"
              v-model.trim="userTest.contacts.email.value"
            />
          </div>
        </div>

        <div
          class="flex align-end"
          :class="{ error: userTest.contacts.facebook.error }"
        >
          <label for="contacts-facebook">Facebook paskyra</label>
          <div class="flex direction-column grow">
            <span>{{ userTest.contacts.facebook.error }}</span>
            <input
              type="text"
              id="contacts-facebook"
              v-model.trim="userTest.contacts.facebook.value"
            />
          </div>
        </div>

        <div class="flex align-baseline">
          <label for="user-contact">Susisiekite su manimi</label>
          <select id="user-contact" v-model="userTest.contactMethod.value">
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
          <textarea id="user-about" v-model.trim="user.about" />
        </div>

        <label>
          <input
            type="checkbox"
            v-model="userTest.isDriver.value"
            v-on:change="checkboxChanged"
          />
          Esu vairuotojas
        </label>

        <div
          v-if="!userTest.isDriver.value"
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

    <div v-if="userTest.isDriver.value">
      <h3 class="section-title">Vairuotojo profilis</h3>
      <div class="flex pb-50">
        <div class="flex direction-column align-center">
          <Avatar :path="user.driver.car.photo" size="big" />
          <Button
            :click="changeCarPhoto"
            text="įkelti nuotrauką"
            :isOutlined="true"
            class="mt-20"
          />
        </div>

        <div class="flex direction-column grow">
          <div
            class="flex align-end"
            :class="{ error: userTest.driver.car.model.error }"
          >
            <label for="car-model">Transporto priemonė*</label>
            <div class="flex direction-column grow">
              <span>{{ userTest.driver.car.model.error }}</span>
              <input
                type="text"
                id="car-model"
                v-model.trim="userTest.driver.car.model.value"
              />
            </div>
          </div>

          <div
            class="flex align-end"
            :class="{ error: userTest.driver.car.date.error }"
          >
            <label for="car-date">Pagaminimo metai*</label>
            <div class="flex direction-column grow">
              <span>{{ userTest.driver.car.date.error }}</span>
              <Datepicker
                id="car-date"
                v-model="userTest.driver.car.date.value"
                format="yyyy-MM-dd"
                :monday-first="true"
              />
            </div>
          </div>

          <div class="flex align-baseline">
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

          <div class="flex align-baseline">
            <label for="driver-about">Vairavimo įgūdžiai</label>
            <textarea id="driver-about" v-model.trim="userTest.driver.about.value" />
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

import Datepicker from 'vuejs-datepicker';
import UserService from '@/services/UserService.js';
import Utils from '@/assets/Utils.js';

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
      userTest: {
        name: {
          value: '',
          error: '',
        },
        birthDate: {
          value: '',
          error: '',
        },
        contacts: {
          city: {
            value: '',
            error: '',
          },
          phone: {
            value: '',
            error: '',
          },
          email: {
            value: '',
            error: '',
          },
          facebook: {
            value: '',
            error: '',
          },
        },
        contactMethod: {
          value: '',
          error: '',
        },
        isDriver: {
          value: false,
          error: '',
        },
        driver: {
          about: {
            value: '',
            error: '',
          },
          car: {
            date: {
              value: '',
              error: '',
            },
            model: {
              value: '',
              error: '',
            },
          },
          contactMethod: {
            value: '',
            error: '',
          },
        },
      },
    };
  },
  created() {
    this.userTest.name.value = this.user.name;
    this.userTest.birthDate.value = this.user.birthDate;
    this.userTest.contacts.city.value = this.user.contacts.city;
    this.userTest.contacts.phone.value = this.user.contacts.phone;
    this.userTest.contacts.email.value = this.user.contacts.email;
    this.userTest.contacts.facebook.value = this.user.contacts.facebook;
    this.userTest.contactMethod.value = this.user.contactMethod;

    this.userTest.isDriver.value = this.user.isDriver;
    this.userTest.driver.about.value = this.user.driver.about;
    this.userTest.driver.car.date.value = this.user.driver.car.date;
    this.userTest.driver.car.model.value = this.user.driver.car.model;
    this.userTest.driver.contactMethod.value = this.user.driver.contactMethod;
  },
  methods: {
    changeCarPhoto() {
      alert('TODO');
    },
    changeUserPhoto() {
      alert('TODO');
    },
    checkboxChanged() {
      const userTest = this.userTest;
      let driver = userTest.driver;

      if (userTest.isDriver.value) {
        driver = driver || {};
        driver.car = driver.car || {};
        driver.contactMethod.value = driver.contactMethod.value || '';
        driver.about.value = driver.about.value || '';
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
      const cannotBeEmpty = 'laukas negali būti tuščias';

      const name = this.userTest.name;
      name.error = name.value ? '' : cannotBeEmpty;

      const birthDate = this.userTest.birthDate;
      if (!birthDate.value) {
        birthDate.error = cannotBeEmpty;
      } else {
        const age = Utils.calculateAge(birthDate.value);
        const minAge = 18;

        birthDate.error = age >= minAge ? '' : 'tai kad tu dar vaikas!!!';
      }

      const contactMethod = this.userTest.contactMethod;
      let contacts = this.userTest.contacts[contactMethod.value];
      if (contacts) {
        if (!contacts.value) {
          contacts.error = cannotBeEmpty;
        } else {
          if (contactMethod.value.toLowerCase() === 'email') {
            const isValidEmail = Utils.validateEmail(contacts.value);
            contacts.error = isValidEmail ? '' : 'neteisinga forma';
          } else {
            contacts.error = '';
          }
        }
      }

      const isDriver = this.userTest.isDriver;
      if (isDriver.value) {
        const carDate = this.userTest.driver.car.date;
        if (!carDate.value) {
          carDate.error = cannotBeEmpty;
        } else {
          const maxCarYear = 10;
          const carYear = Utils.calculateAge(carDate.value);
          carDate.error = carYear <= maxCarYear ? '' : 'metalo laužas';
        }
        const carModel = this.userTest.driver.car.model;
        carModel.error = carModel.value ? '' : cannotBeEmpty;

        const driverContactMethod = this.userTest.driver.contactMethod;
        contacts = this.userTest.contacts[driverContactMethod.value];
        if (contacts) {
          if (!contacts.value) {
            contacts.error = cannotBeEmpty;
          } else {
            if (driverContactMethod.value.toLowerCase() === 'email') {
              const isValidEmail = Utils.validateEmail(contacts.value);
              contacts.error = isValidEmail ? '' : 'neteisinga forma';
            } else {
              contacts.error = '';
            }
          }
        }
      }

      // copy data from userTest into User
      // TODO
    },
  },
};
</script>

<style lang="scss">
@import '../assets/styles/user-edit.scss';
</style>