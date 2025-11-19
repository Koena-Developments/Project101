<template>
  <div :class="['p-4 rounded-lg shadow', dark ? 'bg-gray-800' : 'bg-white']">
    <h3 class="text-sm mb-2">Overall User Activity</h3>
    <div class="h-32">
      <canvas ref="chartCanvas"></canvas>
    </div>
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue'
import Line from 'chart.js/auto'

const props = defineProps({
  dark: Boolean
})

const chartCanvas = ref<HTMLCanvasElement | null>(null)

onMounted(() => {
  if (!chartCanvas.value) return

  const ctx = chartCanvas.value.getContext('2d')
  if (!ctx) return

  new Line(ctx, {
    data: {
      labels: ['JAN', 'FEB', 'MAR', 'APR', 'MAY', 'JUN', 'JUL', 'AUG', 'SEP', 'OCT', 'NOV', 'DEC'],
      datasets: [{
        type: 'line',
        label: 'Active Students',
        data: [10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65],
        borderColor: props.dark ? '#ec4899' : '#db2777',
        tension: 0.4,
        fill: false
      }]
    },
    options: {
      scales: {
        y: {
          beginAtZero: true,
          grid: {
            color: props.dark ? 'rgba(255,255,255,0.1)' : 'rgba(0,0,0,0.1)'
          },
          ticks: { color: props.dark ? 'white' : 'black' }
        },
        x: {
          grid: { display: false },
          ticks: { color: props.dark ? 'white' : 'black' }
        }
      },
      plugins: {
        legend: { display: false }
      }
    }
  })
})
</script>