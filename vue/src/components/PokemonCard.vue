<script setup>
defineProps({
  card: {
    type: Object,
    required: true
  }
})

</script>

<template>
    <RouterLink
        :to="{ name: 'pokemon-card-details', params: { pokemonCardId: card.pokemonCardId , binderId: card.binderId } }"
        class="">
        <div class="pokemon-card">
          <p class="intro">{{ card.name }}</p>
          <p class="intro">{{ card.set }}</p>
          <p class="intro">{{ card.number }}</p>
        </div>
    </RouterLink>
</template>

<style>
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
}</style>
