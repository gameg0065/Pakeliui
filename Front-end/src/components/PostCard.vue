<template>
  <div class="card shadow flex">
    <div class="flex direction-column align-center mr-20">
      <Avatar :path="post.user.picturePath" />
      <!-- <div class="flex align-center pt-10">
        <img src="../assets/icons/star.svg" alt="star" class="mr-10"/>
        <small>{{ driver.driver.rating }} / 5</small>
      </div> -->
    </div>
    <div class="flex direction-column grow">
      <router-link :to="{ name: 'post', params: { id: post.id } }">
        <h4 class="text-color-primary mb-10">
          {{ post.travelFrom + ' - ' + post.travelTo }}
        </h4>
      </router-link>
      <p>
        {{
          (post.date || 'kelionės data') +
          ', ' +
          (post.time || 'kelionės laikas')
        }}
      </p>
      <small>{{ post.user.name }}</small>
      <p>Laisvų vietų: {{ post.seetCount - post.passengers.length }}</p>
    </div>

    <div>
      <p v-if="hasExpired()" class="text-color-secondary">NEBEGALIOJANTIS</p>

      <div v-if="isPending" class="flex direction-column align-end">
        <p class="text-color-primary">LAUKIAMA PATVIRTINIMO</p>
        <Button
          text="Atšaukti rezervaciją"
          :click="cancelReservation"
          :isSecondary="true"
          :isOutlined="true"
        />
      </div>
    </div>
  </div>
</template>

<script>
import Avatar from '@/components/Avatar.vue';
import Button from '@/components/Button.vue';

export default {
  name: 'PostCard',
  props: {
    isPending: Boolean,
    post: Object,
  },
  components: {
    Avatar,
    Button,
  },
  methods: {
    cancelReservation() {
      const modal = this.$modal;
      modal.show('modal-messaging', {
        title: 'Rezervacijos atšaukimas',
        text:
          'Ar tikrai norite atšaukti rezervaciją? Mes apie tai informuosime vairuotoją. Žemiau esančiame laukelyje palikite žinutę vairuotojui.',
        button: {
          title: 'atšaukti rezervaciją',
          action(data) {
            alert('TODO');
            modal.hide('modal-messaging');
          },
        },
      });
    },
    hasExpired() {
      const now = new Date();
      const postDate = new Date(this.post.date);

      return now.getTime() >= postDate.getTime();
    },
  },
};
</script>
