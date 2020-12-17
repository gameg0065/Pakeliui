import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex);

export default new Vuex.Store({
	state: {
		user: null
	},
	getters: {
		getUser: state => {
			return state.user;
		}
	},
	mutations: {
		CLEAR_USER_DATA(state) {
			localStorage.removeItem('user');
			state.user = null;
		},
		SET_USER(state, user) {
			localStorage.setItem('user', JSON.stringify(user));
			state.user = user;
		}
	},
	actions: {
		login({ commit }, user) {
			commit('SET_USER', user);
		},
		logout({ commit }) {
			commit('CLEAR_USER_DATA');
		},
		updateUser({ commit }, user) {
			commit('SET_USER', user);
		}
	},
	modules: {}
});
