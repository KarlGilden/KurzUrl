<script setup lang="ts">
import { RouterView, useRoute } from "vue-router";
import { RouterLink } from "vue-router";

const route = useRoute();
</script>

<template>
	<div class="h-screen w-full flex flex-col">
		<div
			v-if="route.meta.requiresNav"
			class="flex gap-2 items-center w-full px-16"
		>
			<RouterLink class="py-5" to="/">Home</RouterLink>
			<RouterLink class="py-5" to="/about">About</RouterLink>
		</div>

		<div class="px-16 py-5 flex-1">
			<RouterView />
		</div>
	</div>
</template>
