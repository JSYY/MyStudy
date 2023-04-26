import { createApp } from "vue";
import App from "./App.vue";
import { install } from '../node_modules/my-component';

let app = createApp(App);
install(app).mount("#app");
console.log(app);



