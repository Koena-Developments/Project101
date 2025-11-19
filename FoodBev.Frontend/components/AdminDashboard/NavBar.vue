<template>
  <div class="flex justify-between items-center p-4 bg-white border-b">
    <div class="flex items-center space-x-2">
      <div class="w-8 h-8 bg-purple-600 rounded flex items-center justify-center text-white font-bold">F</div>
      <span class="font-semibold">FoodBev Admin</span>
    </div>
    <div class="flex items-center space-x-4">
      <button @click="toggleTheme" class="p-2 rounded-full bg-gray-100 hover:bg-gray-200">
        <i v-if="isDark" class="fas fa-sun text-yellow-500"></i>
        <i v-else class="fas fa-moon text-gray-700"></i>
      </button>
      <div class="flex items-center space-x-2">
        <img src="https://via.placeholder.com/32" class="rounded-full" />
        <span>Admin User</span>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { usePreferredDark } from '@vueuse/core'

const isDark = usePreferredDark()
const toggleTheme = () => {
  document.documentElement.classList.toggle('dark')

  console.log("here is the: " + toggleTheme)
}
</script>