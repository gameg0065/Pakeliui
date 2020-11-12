import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex);

export default new Vuex.Store({
	state: {
		user: {
			id: 110,
			isDriver: false,
			isLoggedIn: false
		}
	},
	getters: {
		isDriver: state => {
			return state.user.isDriver;
		},
		isLoggedIn: state => {
			return state.user.isLoggedIn;
		},
		userID: state => {
			return state.user.id;
		}
	},
	mutations: {
		SET_IS_DRIVER(state, value) {
			state.user.isDriver = value;
		},
		SET_LOGGED_IN(state, value) {
			state.user.isLoggedIn = value;
			if (!value) {
				state.user.id = 0;
				state.user.isDriver = false;
				state.user.isLoggedIn = false;
			}
		},
		SET_USER_ID(state, id) {
			state.user.id = id;
		}
	},
	actions: {},
	modules: {}
});
