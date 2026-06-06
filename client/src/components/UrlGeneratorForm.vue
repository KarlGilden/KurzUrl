<script setup lang="ts">
import type { Url, UrlInput } from "@/api/types";
import { useFetch } from "@/api/useFetch";
import { ref } from "vue";

const destinationUrl = ref("");
const shortUrl = ref("");
const shortUrlError = ref("");
const isLoading = ref(false);

const onGenerate = async () => {
	const fetch = useFetch();
	try {
		shortUrlError.value = "";
		isLoading.value = true;
		const res = await fetch<Url, UrlInput>({
			path: "/Url",
			method: "POST",
			body: { destinationUrl: destinationUrl.value },
		});

		isLoading.value = false;

		if (res?.isSuccess) {
			shortUrl.value = `${import.meta.env.VITE_BASE_CLIENT_URL}/${res.data?.slug}`;
		} else {
			shortUrlError.value =
				res?.errorMessage ?? "Something went wrong. Please try again.";
			isLoading.value = false;
		}
	} catch (e) {
		shortUrlError.value = "Something went wrong. Please try again.";
		isLoading.value = false;
	}
};
</script>

<template>
	<h3 class="font-semibold">Generate a url</h3>
	<form @submit.prevent="onGenerate" class="flex gap-2 w-full">
		<input
			name="destination-input"
			v-model="destinationUrl"
			class="px-2 border-2 border-gray-300 rounded-md w-full"
			type="text"
			placeholder="Enter a url..."
		/>
		<button type="submit" class="px-5 py-2 bg-blue-500 text-white rounded-md">
			Generate
		</button>
	</form>
	<div class="w-full flex justify-center p-5">
		<a
			v-if="shortUrl"
			class="text-blue-500 font-semibold"
			target="_blank"
			:href="shortUrl"
			>{{ shortUrl }}</a
		>
		<p v-if="shortUrlError">{{ shortUrlError }}</p>
		<p v-if="isLoading">Loading...</p>
	</div>
</template>
