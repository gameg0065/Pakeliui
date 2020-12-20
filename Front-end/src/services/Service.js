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

const defaults = {
	email: '', // required
	name: '', // required
	password: '', // required
	// aboutDriver: '',
	// birthDate: '2000-12-31',
	// city: '',
	// contactMethod: '',
	// driverContactMethod: '',
	// driverInfo: '',
	// facebookLink: '',
	// isDriver: Boolean,
	// phoneNumber: '',
	// picturePath: '',
	// registrationDate: '2000-12-31',
	// userInfo: '',
	car: {
		//   model: '',
		//   manufacturer: '',
		//   year: Number,
		//   color: '',
		//   picturePath: '',
	}
};

export default {
	deleteUser(user) {
		return apiClient.delete('/api/User/', { data: { userId: user.userId } });
	},
	deletePost(post) {
		return apiClient.delete('/api/Post/', { data: { id: post.id } });
	},
	deleteReservation(reservation) {
		return apiClient.delete('/api/Reservation/', { data: { id: reservation.id } });
	},
	getAllComments() {
		return apiClient.get('api/Comment/AllComments');
	},
	getAllFeedbacks() {
		return apiClient.get('api/Feedback/AllFeedbacks');
	},
	getAllPosts() {
		return apiClient.get('/api/Post/AllPosts/');
	},
	getAllReservations() {
		return apiClient.get('api/Reservation/AllReservations');
	},
	getAllUsers() {
		return apiClient.get('/api/User/AllUsers/');
	},
	getPostById(id) {
		return apiClient.get('api/post/?id=' + id);
	},
	getPostsByPassengerId(id) {
		return apiClient.get('/api/Post/GetPostsByPassengerId/?id=' + id);
	},
	getUrl(url) {
		return axios.get(url);
	},
	getUserByEmailAndPass(email, password) {
		return apiClient.get('/api/user/GetUserByEmailAndPass?email=' + email + '&password=' + password);
	},
	getUserById(id) {
		return apiClient.get('api/User/UserById?id=' + id);
	},
	postComment(comment) {
		return apiClient.post('/api/Comment/', comment);
	},
	postFeedback(feedback) {
		return apiClient.post('/api/Feedback/', feedback);
	},
	postPost(post) {
		return apiClient.post('/api/Post/', post);
	},
	postReservation(reservation) {
		return apiClient.post('/api/Reservation/', reservation);
	},
	postUser(user) {
		const userData = Utils.mergeDeep({}, defaults, user);
		return apiClient.post('/api/User/', userData);
	},
	putPost(post) {
		return apiClient.put('/api/Post/', post);
	},
	putReservation(reservation) {
		return apiClient.put('/api/Reservation/', reservation);
	},
	putUser(user) {
		const userData = Utils.mergeDeep({}, defaults, user);
		return apiClient.put('/api/User/', userData);
	},
	uploadPhoto(photo) {
		const formData = new FormData();
		formData.append('upload_preset', 'vue-upload');
		formData.append('file', photo);

		return apiClient.post('https://api.cloudinary.com/v1_1/ignaspan/upload', formData, {
			onUploadProgress: uploadEvent => {
				console.log('Upload progress: ' + Math.round((uploadEvent.loaded / uploadEvent.total) * 100));
			}
		});
	}
};
