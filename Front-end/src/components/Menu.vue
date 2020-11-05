<template>
	<!-- <nav class="about">
		<div class="menu">HELLOOooooo {{ text }}</div>
	</nav> -->
	<nav>
		<ul class="left-links">
			<li><img src="../assets/images/logo-pakeliui.svg" alt="logo" /></li>
			<li><Button text="skelbimai" :isSecondary="true"></Button></li>
			<li><Button text="įkelk skelbimą" :isSecondary="true"></Button></li>
		</ul>
		<ul class="right-links">
			<li><Button text="Prisijungti"></Button></li>
			<li><Button text="Registruotis"></Button></li>
			<li><Button text="Mano profilis"></Button></li>
		</ul>
	</nav>
</template>
<style lang="scss">
@import '../assets/styles/_variables.css';
@import '../assets/styles/_typography.css';
@import '../assets/styles/menu.scss';
@import '../assets/styles/Button.css';
</style>

<script lang="ts">
import Vue from 'vue';
import Button from '@/components/Button.vue';

export default Vue.extend({
	name: 'Menu',
	props: {
		text: String
	},
	components: {
		Button
	}
});
</script>
