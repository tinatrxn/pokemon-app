<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { getBinders, type BinderItem } from '../services/BinderService'
import { RouterLink } from 'vue-router'
import PokemonCard from '../src/components/PokemonCard.vue'

const binders = ref<BinderItem[]>();
const error = ref<string>();
const loading = ref(false);

onMounted(loadBinders)

async function loadBinders() {
  loading.value = true
  error.value = undefined

  try {
    binders.value = await getBinders()
  } catch (err) {
    error.value = err instanceof Error ? err.message : 'Something went wrong'
  } finally {
    loading.value = false
  }
}

</script>

<template>
  <div class="view">
    <Button v-if="!loading" @click="loadBinders" class="home-button">Refresh</button>

    <div v-if="loading" class="loading">Loading...</div>
    <div v-else-if="error" class="error">Error: {{ error }}</div>
    <div v-else class="columns-2 gap-10">
      <RouterLink
        v-for="binder in binders"
        :key="binder.binderId"
        :to="{ name: 'binder-details', params: { binderId: binder.binderId, currentPage: 1 } }"
      >
      <div class="binder-card relative">
        <div class="title absolute inset-x-0 top-5 h-12">{{ binder.name }}</div>
        <div class="summary absolute inset-x-0 top-22 h-12">Number of cards: {{ binder.cardCount }}</div>
        <div  class="intro absolute inset-x-0 bottom-0 h-16">
          Click to go to the first page
          </div>
        </div>
      </RouterLink>
    </div>
  </div>
</template>
