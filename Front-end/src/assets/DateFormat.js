export default {
	getHoursMinutes(string) {
		return string || 'HH:MM';
	},
	getYearMonthDate(string) {
		if (!string) {
			return 'YY-MM-DD';
		}
		const date = new Date(string).toISOString()
		return date.split('T')[0];
	},
	toDateString(date) {
		if (!date) {
			return '';
		}
		
		date = date instanceof Date ? date : new Date(date);
		return date.toISOString();
	},
};
