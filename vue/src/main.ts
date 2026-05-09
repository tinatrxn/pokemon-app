import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import router from './router'
import PrimeVue from 'primevue/config'
import { definePreset } from '@primeuix/themes';
import Aura from '@primeuix/themes/aura'
import Button from "primevue/button"
import 'primeicons/primeicons.css'

const myPreset = definePreset(Aura, {
    semantic: {
        primary: {
            50: '{pink.50}',
            100: '{pink.100}',
            200: '{pink.200}',
            300: '{pink.300}',
            400: '{pink.400}',
            500: '{pink.500}',
            600: '{pink.600}',
            700: '{pink.700}',
            800: '{pink.800}',
            900: '{pink.900}',
            950: '{pink.950}'
        }
    }
});

createApp(App)
    .use(router)
    .use(PrimeVue, {
        theme: {
            preset: myPreset,
        options: {
            darkModeSelector: false || 'none'
         }
        }
    }
    )
    .component('Button', Button)
    .mount('#app')
