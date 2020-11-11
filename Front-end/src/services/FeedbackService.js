// Faking a call to a server here
import db from './db.json';

export default {
	getFeedback(id) {
		return db.feedbacks.find(user => user.id === id);
	},
	getFeedbacks() {
		return db.feedbacks;
	}
};
