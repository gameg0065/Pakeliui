import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex);

export default new Vuex.Store({
	state: {
		user: {
			id: 100,
			isLoggedIn: false
		}
	},
	getters: {
		isLoggedIn: state => {
			return state.user.isLoggedIn;
		},
		userID: state => {
			return state.user.id;
		}
	},
	mutations: {
		SET_LOGGED_IN(state, value) {
			state.user.isLoggedIn = value;
		},
		SET_USER_ID(state, id) {
			state.user.id = id;
		}
	},
	actions: {},
	modules: {}
});
