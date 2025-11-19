<template>
  <div :class="['p-4 rounded-lg shadow', dark ? 'bg-gray-800' : 'bg-white']">
    <h3 class="text-sm mb-2">Sales Dynamics</h3>
    <div class="h-32">
      <canvas ref="chartCanvas"></canvas>
    </div>
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue'
import Bar from 'chart.js/auto'

const props = defineProps({
  dark: Boolean
})

const chartCanvas = ref<HTMLCanvasElement | null>(null)

onMounted(() => {
  if (!chartCanvas.value) return

  const ctx = chartCanvas.value.getContext('2d')
  if (!ctx) return

  new Bar(ctx, {
    data: {
      labels: ['JAN', 'FEB', 'MAR', 'APR', 'MAY', 'JUN', 'JUL', 'AUG', 'SEP', 'OCT', 'NOV', 'DEC'],
      datasets: [{
        type: 'bar',
        label: 'Applications',
        data: [12, 19, 3, 5, 2, 3, 15, 20, 18, 25, 30, 35],
        backgroundColor: props.dark ? '#3b82f6' : '#2563eb',
        borderColor: props.dark ? '#60a5fa' : '#3b82f6',
        borderWidth: 1
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