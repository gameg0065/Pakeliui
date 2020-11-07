// Faking a call to a server here
import db from './db.json';

export default {
	getPost(id) {
		return db.posts.find(post => post.id === id);
	},
	getPosts() {
		return db.posts;
	}
};
