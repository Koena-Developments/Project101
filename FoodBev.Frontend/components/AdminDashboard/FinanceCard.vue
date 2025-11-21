<template>
  <div :class="['p-4 rounded-lg shadow flex items-center', dark ? 'bg-gray-800' : 'bg-white']">
    <div class="mr-4">
      <i :class="icon" class="text-xl"></i>
    </div>
    <div>
      <h3 class="text-sm opacity-70">{{ title }}</h3>
      <div class="text-xl font-bold">${{ amount }}</div>
      <div class="text-xs opacity-70">{{ subtitle }}</div>
    </div>
    <div class="ml-auto text-xs px-2 py-1 rounded-full" :class="changeClass">
      {{ change }}
    </div>
  </div>
</template>

<script setup lang="ts">
const props = defineProps({
  title: String,
  amount: String,
  subtitle: String,
  change: String,
  icon: String,
  dark: Boolean,
  // change: string
})

const changeClass = computed(() => {
  if (props.change?.startsWith('+')) return 'bg-green-100 text-green-700'
  if (props.change?.startsWith('-')) return 'bg-red-100 text-red-700'
  return 'bg-gray-100 text-gray-700'
})
</script>