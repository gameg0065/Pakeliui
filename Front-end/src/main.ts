import Vue from 'vue';
import App from './App.vue';
import router from './router';
import store from './store';
import VModal from 'vue-js-modal';

Vue.use(VModal);

Vue.config.productionTip = false;

new Vue({
	router,
	store,
	render: h => h(App),
	created() {
		const userString = localStorage.getItem('user');
		if (userString) {
			const user = JSON.parse(userString);
			this.$store.commit('SET_USER', user);
		}
	}
}).$mount('#app');
