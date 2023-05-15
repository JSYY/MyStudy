import { createApp } from "vue";
import App from "./App.vue";
import UI from '../node_modules/my-component';

let app = createApp(App);
app.use(UI).mount("#app");
console.log(app);



