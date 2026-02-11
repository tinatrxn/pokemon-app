<script setup lang="ts">
import { reactive, watch } from 'vue'
import type { pokemonCardItemAdd } from '../../services/PokemonCardService';

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
  <h1>form</h1>
  <form @submit.prevent="console.log('Submitting form', form); emit('save', form)">
    <input v-model="form.name" placeholder="Name" />
    <input v-model="form.set" placeholder="Set" />
    <input v-model="form.number" placeholder="Number" />

    <button type="submit">Save</button>
  </form>
</template>
