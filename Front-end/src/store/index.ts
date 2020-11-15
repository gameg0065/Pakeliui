import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex);

export default new Vuex.Store({
	state: {
		user: {
			id: 110,
			isDriver: false,
			isLoggedIn: false
		},
		user2: null
	},
	getters: {
		loggedIn(state) {
			return !!state.user2;
		},
		isDriver: state => {
			return state.user.isDriver;
		},
		isLoggedIn: state => {
			return state.user.isLoggedIn;
		},
		userID: state => {
			return state.user.id;
		},

		/////

		getUser: state => {
			return state.user2;
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
		},

		/////

		CLEAR_USER_DATA(state) {
			state.user2 = null;
		},
		SET_USER(state, user) {
			state.user2 = user;
		}
	},
	actions: {
		login({ commit }, user) {
			commit('SET_USER', user);
		},
		logout({ commit }) {
			commit('CLEAR_USER_DATA');
		}
	},
	modules: {}
});
