import Vue from 'vue';
import VueRouter, { RouteConfig } from 'vue-router';

import Home from '../views/Home.vue';
import About from '../views/About.vue';
import Contacts from '../views/Contacts.vue';
import PageNotFound from '../views/PageNotFound.vue';
import Post from '../views/Post.vue';
import PostCreate from '../views/PostCreate.vue';
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
		path: '/post/:id',
		name: 'post',
		component: Post,
		props: true
	},
	{
		path: '/post/create',
		name: 'post-create',
		component: PostCreate
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
