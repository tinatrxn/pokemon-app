<script setup lang="ts">
import { reactive, watch } from 'vue'
import type { pokemonCardItemAdd } from '../../services/PokemonCardService';
import { Form } from '@primevue/forms';


const props = defineProps<{
  card: pokemonCardItemAdd
}>()

const emit = defineEmits<{
  (e: 'save', card: pokemonCardItemAdd): void
}>()

const form = reactive({ ...props.card })

watch(
  () => props.card,
  (newCard) => Object.assign(form, newCard)
)
</script>

<template>
  <form @submit.prevent="console.log('Submitting form', form); emit('save', form)">
    <input v-model="form.name" placeholder="Name" />
    <input v-model="form.set" placeholder="Set" />
    <input v-model="form.number" placeholder="Number" />
    <input v-model="form.imageUrl" placeholder="ImageURL" />
    <button type="submit">Save</button>
  </form>
</template>
