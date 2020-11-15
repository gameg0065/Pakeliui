import Vue from 'vue';
import VueRouter, { RouteConfig } from 'vue-router';

import Home from '../views/Home.vue';
import About from '../views/About.vue';
import Contacts from '../views/Contacts.vue';
import DriverHistory from '../views/DriverHistory.vue';
import DriverRequests from '../views/DriverRequests.vue';
import PageNotFound from '../views/PageNotFound.vue';
import Post from '../views/Post.vue';
import PostCreate from '../views/PostCreate.vue';
import Posts from '../views/Posts.vue';
import Terms from '../views/Terms.vue';
import User from '../views/User.vue';
import UserEdit from '../views/UserEdit.vue';
import UserHistory from '../views/UserHistory.vue';

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
		path: '/user/:id/driver/history',
		name: 'driver-history',
		component: DriverHistory,
		props: true
	},
	{
		path: '/user/:id/driver/requests',
		name: 'driver-requests',
		component: DriverRequests,
		props: true
	},
	{
		path: '/post/:id',
		name: 'post',
		component: Post,
		props: true
	},
	{
		path: '/postcreate',
		name: 'post-create',
		component: PostCreate
	},
	{
		path: '/post/:id/edit',
		name: 'post-edit',
		component: PostCreate,
		props: true
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
	},
	{
		path: '/user/:id',
		name: 'user',
		component: User,
		props: true
	},
	{
		path: '/user/:id/edit',
		name: 'user-edit',
		component: UserEdit,
		props: true
	},
	{
		path: '/user/:id/history',
		name: 'user-history',
		component: UserHistory,
		props: true
	},
	{
		path: '*',
		name: '404',
		component: PageNotFound
	}
];

const router = new VueRouter({
	mode: 'history',
	routes
});

export default router;
