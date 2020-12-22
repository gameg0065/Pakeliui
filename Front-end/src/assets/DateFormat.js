export default {
	getAge(date) {
		date = date instanceof Date ? date : new Date(date);

		const dateDiffInMilliseconds = Date.now() - date.getTime();
		const dateDiff = new Date(dateDiffInMilliseconds);
		return dateDiff.getUTCFullYear() - 1970;
	},
	getHoursMinutes(string) {
		return string || 'HH:MM';
	},
	getYearMonthDate(string) {
		if (!string) {
			return 'YY-MM-DD';
		}
		const date = new Date(string).toISOString();
		return date.split('T')[0];
	},
	toDateString(date) {
		if (!date) {
			return '';
		}

		date = date instanceof Date ? date : new Date(date);
		return date.toISOString();
	},
    toHHMMSS(string) {
		const secNum = parseInt(string, 10); // don't forget the second param
		let hours = Math.floor(secNum / 3600);
		let minutes = Math.floor((secNum - hours * 3600) / 60);
		let seconds = secNum - hours * 3600 - minutes * 60;
  
		if (hours < 10) {
		  hours = '0' + hours;
		}
		if (minutes < 10) {
		  minutes = '0' + minutes;
		}
		if (seconds < 10) {
		  seconds = '0' + seconds;
		}
		return hours + ':' + minutes + ':' + seconds;
	  },
};
