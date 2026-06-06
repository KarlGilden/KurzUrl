<script setup lang="ts">
import UrlGeneratorForm from "@/components/UrlGeneratorForm.vue";
</script>

<template>
	<div class="h-full flex flex-col items-center">
		<div class="w-full max-w-[600px] flex flex-col gap-10">
			<div class="flex flex-col gap-2">
				<h1 class="text-6xl font-semibold">KurzUrl</h1>
				<p>Generate and manage short urls</p>
				<small
					>Already have a link?
					<a href="" class="text-blue-500 font-semibold"
						>Click here to search for it!</a
					></small
				>
			</div>
			<div class="w-full">
				<UrlGeneratorForm />
			</div>
		</div>
	</div>
</template>
