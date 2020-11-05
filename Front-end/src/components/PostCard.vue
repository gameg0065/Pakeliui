<template>
  <router-link :to="{ name: 'post', params: { id: '1' } }">
    <div class="card shadow">
      <h4>{{ event.title }}</h4>
      <p>{{ event.date + ', ' + event.dayName + ' ' + event.time }}</p>
      <small> {{ event.driverName }}</small>
      <p>Laisvų vietų: {{ event.availableSpace }}</p>
    </div>
  </router-link>
</template>

<script>
export default {
  data() {
    return {
      event: {
        title: 'Vilnius - Klaipėda',
        date: '2020-10-15',
        dayName: 'šeštadienis',
        time: '18:00',
        driverName: 'Vairuotojo vardas, pavardė',
        availableSpace: 3
      }
    };
  }
};
</script>

<style scoped>
.card {
  transition: all 0.2s linear;
  margin: 20px;
  padding: 20px;
}

.card:hover {
  transform: scale(1.01);
}

.shadow {
  -webkit-box-shadow: 0px 4px 10px 0px rgba(0, 0, 0, 0.25); /* Safari 3-4, iOS 4.0.2 - 4.2, Android 2.3+ */
  -moz-box-shadow: 0px 4px 10px 0px rgba(0, 0, 0, 0.25); /* Firefox 3.5 - 3.6 */
  box-shadow: 0px 4px 10px 0px rgba(0, 0, 0, 0.25); /* Opera 10.5, IE 9, Firefox 4+, Chrome 6+, iOS 5 */
}

h4 {
  color: var(--color-primary);
}

a {
  text-decoration: none;
}
</style>