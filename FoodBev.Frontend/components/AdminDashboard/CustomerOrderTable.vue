<template>
  <div :class="['p-4 rounded-lg shadow', dark ? 'bg-gray-800' : 'bg-white']">
    <div class="flex justify-between items-center mb-4">
      <h3 class="text-sm">Student Applications</h3>
      <i class="fas fa-search text-sm opacity-70"></i>
    </div>
    <table class="w-full text-xs">
      <thead>
        <tr class="border-b" :class="dark ? 'border-gray-700' : 'border-gray-200'">
          <th class="py-2 text-left">Name</th>
          <th class="py-2 text-left">Field</th>
          <th class="py-2 text-left">Applied</th>
          <th class="py-2 text-left">Status</th>
          <th class="py-2 text-left">Action</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(app, i) in applications" :key="i" class="border-b" :class="dark ? 'border-gray-700' : 'border-gray-200'">
          <td class="py-2">{{ app.student }}</td>
          <td class="py-2">{{ app.field }}</td>
          <td class="py-2">{{ app.date }}</td>
          <td class="py-2">
            <span :class="[
              'px-2 py-1 rounded-full text-xs',
              app.status === 'Approved' ? 'bg-green-100 text-green-700' :
              app.status === 'Pending' ? 'bg-yellow-100 text-yellow-700' :
              'bg-red-100 text-red-700'
            ]">
              {{ app.status }}
            </span>
          </td>
          <td class="py-2">
            <button class="text-blue-600 text-xs">View</button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script setup lang="ts">
defineProps({
  applications: Array,
  dark: Boolean
})
</script>