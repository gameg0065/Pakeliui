import axios from 'axios';
import Utils from '@/assets/Utils.js';

const apiClient = axios.create({
	baseURL: `https://localhost:5001`,
	withCredentials: false,
	headers: {
		Accept: 'application/json',
		'Content-Type': 'application/json'
	},
	timeout: 10000
});

export default {
	getAllUsers() {
		return apiClient.get('/api/User/AllUsers/');
	},
	postUser(user) {
		const defaults = {
			name: '', // required
			email: '', // required
			password: '', // required
			// phoneNumber: '',
			// birthDate: '2000-12-31',
			// registrationDate: '2000-12-31',
			// city: '',
			// contactMethod: '',
			// userInfo: '',
			// driverInfo: '',
			// facebookLink: '',
			// picturePath: '',
			// isDriver: Boolean,
			// boutDriver: '',
			// driverContactMethod: '',
			car: {
				//   model: '',
				//   manufacturer: '',
				//   year: Number,
				//   color: '',
				//   picturePath: '',
			}
		};
		const userData = Utils.mergeDeep({}, defaults, user);
		return apiClient.post('/api/User/', userData);
	}
};
