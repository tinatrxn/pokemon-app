<script setup lang="ts">
import { reactive, watch } from 'vue'
import type { pokemonCardItem } from '../../services/PokemonCardService';

const props = defineProps<{
  card: {
    pokemonCardId: number
    name: string
    set: string
    number: string
  }
}>()

const emit = defineEmits<{
  (e: 'save', card: pokemonCardItem): void
}>()

const form = reactive({ ...props.card })

watch(
  () => props.card,
  (newCard) => Object.assign(form, newCard)
)
</script>

<template>
  <h1>form</h1>
  <form @submit.prevent="emit('save', form)">
    <input v-model="form.name" placeholder="Name" />
    <input v-model="form.set" placeholder="Set" />
    <input v-model="form.number" placeholder="Number" />

    <button type="submit">Save</button>
  </form>
</template>
