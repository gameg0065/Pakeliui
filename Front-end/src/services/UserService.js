// Faking a call to a server here
import db from './db.json';

export default {
	getUser(id) {
		return db.users.find(user => user.id === id);
	},
	getUseers() {
		return db.users;
	}
};
