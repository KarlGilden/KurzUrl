<script setup lang="ts">
import { useFetch } from "@/api/useFetch";
import type { Url } from "@/api/types";
import { onMounted, ref } from "vue";
import { useRoute } from "vue-router";

const route = useRoute();

const slug = route.params.slug;

const error = ref("");

onMounted(async () => {
	const fetch = useFetch();

	const res = await fetch<Url>({ path: "/Url/" + slug, method: "GET" });

	if (res?.isSuccess) {
		window.location.replace(res.data?.destinationUrl ?? "/");
	} else {
		error.value = res?.errorMessage ?? "Something went wrong";
	}
});
</script>
<template>
	<div class="h-screen flex justify-center items-center"></div>
	<h1 v-if="!error">Redirecting you to your destination</h1>
	<h1 v-if="error">{{ error }}</h1>
</template>
