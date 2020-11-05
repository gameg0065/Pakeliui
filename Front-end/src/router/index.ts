import Vue from 'vue';
import VueRouter, { RouteConfig } from 'vue-router';

import Home from '../views/Home.vue';
import About from '../views/About.vue';
import Contacts from '../views/Contacts.vue';
import Posts from '../views/Posts.vue';
import Terms from '../views/Terms.vue';

Vue.use(VueRouter);

const routes: Array<RouteConfig> = [
	{
		path: '/',
		name: 'home',
		component: Home
	},
	{
		path: '/about',
		name: 'about',
		component: About
	},
	{
		path: '/contacts',
		name: 'contacts',
		component: Contacts
	},
	{
		path: '/posts',
		name: 'posts',
		component: Posts
	},
	{
		path: '/terms',
		name: 'terms',
		component: Terms
	}
];

const router = new VueRouter({
	routes
});

export default router;
