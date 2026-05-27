<script setup>
defineProps({
  card: {
    type: Object,
    required: true
  }
})

</script>

<template>
  <div class="pokemon-card grid grid-cols-4 gap-1 place-items-center ">
    <div class="col-span-3 justify-items-end">
    <RouterLink
        :to="{ name: 'pokemon-card-details', params: { pokemonCardId: card.pokemonCardId , binderId: card.binderId } }"
        >
          <img :src="card.imageUrl" class="card-image"/>
    </RouterLink>
    </div>
      <div class="card-text grid grid-flow-col grid-rows-3">
        <p class="intro">{{ card.name }}</p>
        <p class="intro">{{ card.set }}</p>
        <p class="intro">{{ card.number }}</p>
        </div>
    </div>
</template>
