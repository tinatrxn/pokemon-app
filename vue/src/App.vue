<script setup lang="ts">
import { RouterView, RouterLink } from 'vue-router'

</script>

<template>
  <h1>hello</h1>
    <RouterLink :to="{ name: 'binder-list' }">
      <button class="refresh-button">home</button>
    </RouterLink>
  <RouterView />
</template>

<style scoped>

</style>
