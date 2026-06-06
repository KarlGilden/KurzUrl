import { createApp } from "vue";
import "./assets/base.css";
import App from "./App.vue";
import { router } from "./Routes.ts";

createApp(App).use(router).mount("#app");
