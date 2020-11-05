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
		name: 'Home',
		component: Home
	},
	{
		path: '/about',
		name: 'About',
		component: About
	},
	{
		path: '/contacts',
		name: 'Contacts',
		component: Contacts
	},
	{
		path: '/posts',
		name: 'Posts',
		component: Posts
	},
	{
		path: '/terms',
		name: 'Terms',
		component: Terms
	}
];

const router = new VueRouter({
	routes
});

export default router;
