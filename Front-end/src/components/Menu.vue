<template>
	<!-- <nav class="about">
		<div class="menu">HELLOOooooo {{ text }}</div>
	</nav> -->
	<nav>
		<ul class="left-links">
			<li><img src="../assets/images/logo-pakeliui.svg"></li>
			<li><Button text="skelbimai" :isSecondary="true" url=""></Button></li>
			<li><Button text="įkelk skelbimą" :isSecondary="true" url=""></Button></li>
		</ul>
		<ul class="right-links">
			<li><a href="">prisijungti</a></li>
			<li><a href="">registruotis</a></li>
			<li><a href="">profilis</a></li>
		</ul>
	</nav>
</template>
<style lang="scss">
@import '../assets/styles/_variables.css';
@import '../assets/styles/_typography.css';
@import '../assets/styles/menu.scss';
@import '../assets/styles/Button.css';

img {
	height: 30px;
}
</style>

<script lang="ts">
import Vue from 'vue';
import Button from '@/components/Button.vue';

export default {
	components: {
		Button
	}
};
</script>
