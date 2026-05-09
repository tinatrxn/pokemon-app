<script setup lang="ts">
import { RouterView, RouterLink } from 'vue-router'

</script>

<template>
  <h1>tina's pokemon binders!</h1>
    <RouterLink :to="{ name: 'binder-list' }">
        <Button icon="pi pi-home" class="home-button" style="background-color: #595758; border-color: #595758;"/>
    </RouterLink>
  <RouterView />
</template>

<style scoped>

</style>
