<template>
  <div :class="['p-4 rounded-lg shadow', dark ? 'bg-gray-800 text-white' : 'bg-white']">
    <div class="flex justify-between items-start">
      <div>
        <h3 class="text-sm opacity-70">{{ title }}</h3>
        <div class="flex items-center">
          <span class="text-2xl font-bold">{{ value }}</span>
          <span v-if="change" :class="['ml-2 text-xs', change.startsWith('+') ? 'text-green-500' : 'text-red-500']">
            {{ change }}
          </span>
        </div>
      </div>
      <div v-if="icon" class="text-2xl">
        <i :class="icon"></i>
      </div>
    </div>
    <div v-if="subtitle" class="mt-2 text-xs opacity-70">{{ subtitle }}</div>
  </div>
</template>

<script setup lang="ts">
defineProps({
  title: String,
  value: String,
  change: String,
  subtitle: String,
  icon: String,
  dark: Boolean
})
</script>