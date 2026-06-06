import { createRouter, createWebHistory } from "vue-router";

import Home from "./pages/Home.vue";
import Redirect from "./pages/Redirect.vue";
import NotFound from "./pages/NotFound.vue";
import About from "./pages/About.vue";

const routes = [
	{ path: "/", name: "home", component: Home, meta: { requiresNav: true } },
	{ path: "/about", name: "about", component: About },
	{
		path: "/:slug",
		name: "redirect",
		component: Redirect,
		meta: { requiresNav: false },
	},
	{
		path: "/:pathMatch(.*)*",
		name: "not-found",
		component: NotFound,
		meta: { requiresNav: true },
	},
];

export const router = createRouter({
	history: createWebHistory(),
	routes,
});
