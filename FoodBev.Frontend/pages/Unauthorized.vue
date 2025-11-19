<template>
  <div class="p-6">
    <h1>⛔ Unauthorized</h1>
    <p>You don't have access to this page.</p>
    <button @click="logout" class="text-blue-600">Logout</button>
  </div>
</template>

<script setup lang="ts">
const { logout } = useAuth()
</script>