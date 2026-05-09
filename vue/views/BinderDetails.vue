<script setup lang="ts">
import { onMounted, ref, watch } from 'vue'
import { getBinderById, type BinderItem , type PaginationMetadata} from '../services/BinderService'
import PokemonCard from '../src/components/PokemonCard.vue'


const props = defineProps<{
  binderId: string,
  currentPage: string
}>()

const binder = ref<BinderItem>();
const pagination = ref<PaginationMetadata>();
const error = ref<string>();
const loading = ref(false);


onMounted(loadBinderDetails)
watch(() => props.currentPage, loadBinderDetails)

async function loadBinderDetails() {
  console.log('loading page:', props.currentPage, 'binderId:', props.binderId)
  loading.value = true
  error.value = undefined

  try {
    const { binder: binderData, pagination: paginationData }  = await getBinderById(Number(props.binderId), Number(props.currentPage))
    binder.value = binderData
    pagination.value = paginationData
  } catch (err) {
    error.value = err instanceof Error ? err.message : 'Something went wrong'
  } finally {
    loading.value = false
  }
}

//calculate pagenumber for last page

</script>

<template>
  <div class="view">
    <Button v-if="!loading" @click="loadBinderDetails" class="home-button">Refresh</button>

    <div v-if="loading" class="loading">Loading...</div>
    <div v-else-if="error" class="error">Error: {{ error }}</div>
    <div v-else-if="binder">
      <h1>{{ binder.name }} - {{ binder.cardCount }}</h1>
      <div class="columns-3 gap-10">
        <PokemonCard
          v-for="card in binder.pokemonCard"
          :key="card.pokemonCardId"
          :card="card"/>
      </div>
      <RouterLink
        :to="{ name: 'pokemon-card-add', params: { binderId: binderId } }"
        >
        <Button label="Add a card"/>
      </RouterLink>
      <RouterLink
        :to="{ name: 'binder-details', params: { binderId: props.binderId, currentPage: Number(props.currentPage) + 1 } }"
      >
      next page
      </RouterLink>
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
