import { createApp } from 'vue'
import App from './App.vue'
import { install } from './utils/dialog'

createApp(App).use(install).mount('#app')
