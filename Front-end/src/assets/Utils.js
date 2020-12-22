export default {
	isCarFull(post) {
		if (!post.passengers || post.passengers.length === 0) {
			return false;
		}

		const takenPassengers = post.passengers.filter(passenger => {
			return passenger.status === 'TAKEN';
		});

		return takenPassengers.length >= post.seetCount;
	},
	isObject(item) {
		return item && typeof item === 'object' && !Array.isArray(item);
	},
	mergeDeep(target, ...sources) {
		if (!sources.length) return target;
		const source = sources.shift();

		if (this.isObject(target) && this.isObject(source)) {
			for (const key in source) {
				if (this.isObject(source[key])) {
					if (!target[key]) Object.assign(target, { [key]: {} });
					this.mergeDeep(target[key], source[key]);
				} else {
					Object.assign(target, { [key]: source[key] });
				}
			}
		}

		return this.mergeDeep(target, ...sources);
	},
	sortPostsByDateAndTime(post1, post2) {
		if (post1.date && post2.date) {
			const post1Date = new Date(post1.date);
			const post2Date = new Date(post2.date);
			const timeSeparator = ':';

			if (post1.time) {
				post1Date.setHours(...post1.time.split(timeSeparator));
			}
			if (post2.time) {
				post2Date.setHours(...post2.time.split(timeSeparator));
			}
			return post1Date - post2Date;
		}
	},
	stringsAreEqual(string1, string2) {
		string1 = string1 ? string1 : '';
		string2 = string2 ? string2 : '';

		return string1.toLowerCase() === string2.toLowerCase();
	},
	validateEmail(email) {
		//eslint-disable-next-line
		const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
		return re.test(String(email).toLowerCase());
	}
};
