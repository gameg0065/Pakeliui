export default {
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
	toDateString(date) {
		if (!date) {
			return '';
		}
		
		date = date instanceof Date ? date : new Date(date);
		return date.toISOString();
	},
	validateEmail(email) {
		//eslint-disable-next-line
		const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
		return re.test(String(email).toLowerCase());
	}
};
