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
  <div class="weather-app">
    <h1>
      Pokemon Card Binders
      <button v-if="!loading" @click="loadBinders" class="refresh-button">Refresh</button>
    </h1>

    <div v-if="loading" class="loading">Loading...</div>
    <div v-else-if="error" class="error">Error: {{ error }}</div>
    <div v-else class="forecast-container">
      <RouterLink
        v-for="binder in binders"
        :key="binder.binderId"
        :to="{ name: 'binder-details', params: { binderId: binder.binderId } }"
        class="forecast-card"
      >
        <div class="temperature">{{ binder.name }}</div>
        <div class="summary">{{ binder.cardCount }}</div>
        <PokemonCard
          v-for="card in binder.pokemonCard"
          :key="card.pokemonCardId"
          :card="card"/>
      </RouterLink>
      <!-- <RouterLink
        :to="{ name: 'pokemon-card-edit', params: { pokemonCardId: card.pokemonCardId } }"
        ><button class="refresh-button">edit</button>
      </RouterLink> -->
    </div>
  </div>
</template>

<style scoped>
.weather-app {
  max-width: 1200px;
  margin: 0 auto;
  padding: 2rem;
}

h1 {
  text-align: center;
  margin-bottom: 2rem;
  color: #333;
  font-size: 2.5rem;
}

.loading, .error {
  text-align: center;
  padding: 2rem;
  font-size: 1.2rem;
}

.error {
  color: #e74c3c;
}

.forecast-container {
  display: flex;
  gap: 1rem;
  /* overflow-x: auto; */
  padding: 1rem 0;
}

.forecast-card {
  flex: 0 0 180px;
  background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
  border-radius: 12px;
  padding: 1.5rem;
  color: white;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
  transition: transform 0.3s ease, box-shadow 0.3s ease;
  cursor: pointer;
  text-align: center;
}

.forecast-card:hover {
  transform: translateY(-5px);
  box-shadow: 0 8px 12px rgba(0, 0, 0, 0.2);
}

.date {
  font-size: 0.9rem;
  font-weight: 600;
  margin-bottom: 1rem;
  opacity: 0.9;
}

.temperature {
  font-size: 2.5rem;
  font-weight: bold;
  margin-bottom: 0.5rem;
}

.summary {
  font-size: 1rem;
  margin-bottom: 0.5rem;
  font-weight: 500;
}

.temp-range {
  font-size: 0.85rem;
  opacity: 0.8;
}

.refresh-button {
  margin-left: 1rem;
  padding: 0.5rem 1.25rem;
  font-size: 1rem;
  font-weight: 600;
  color: white;
  background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
  border: none;
  border-radius: 8px;
  cursor: pointer;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  transition: all 0.3s ease;
}

.refresh-button:hover {
  transform: translateY(-2px);
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
}

.refresh-button:active {
  transform: translateY(0);
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}
</style>
