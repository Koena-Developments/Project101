<template>
  <div :class="['min-h-screen', dark ? 'bg-gray-900 text-white' : 'bg-gray-50']">
    <!-- Sidebar -->
    <Sidebar />

    <!-- Main Content -->
    <div class="ml-64 p-6">
      <!-- Navbar -->
      <Navbar />

      <!-- Dashboard Grid -->
      <div class="grid grid-cols-1 lg:grid-cols-4 gap-6 mt-6">
        <!-- Stat Cards -->
        <StatCard title="Applications" value="201" change="+8.2%" subtitle="since last month" icon="fas fa-file-alt" :dark="dark" />
        <StatCard title="Approved" value="36" change="+3.4%" subtitle="since last month" icon="fas fa-check-circle" :dark="dark" />
        <StatCard title="Students" value="4,890" change="+12%" subtitle="since last month" icon="fas fa-users" :dark="dark" />
        <StatCard title="Internships" value="1,201" change="+5%" subtitle="since last month" icon="fas fa-briefcase" :dark="dark" />

        <!-- Month Total & Revenue -->
        <div :class="['col-span-1 lg:col-span-2 p-4 rounded-lg shadow', dark ? 'bg-gray-800' : 'bg-white']">
          <div class="flex justify-between items-center mb-4">
            <h3 class="text-sm">Month Total</h3>
            <span class="text-xs opacity-70">$25,410</span>
          </div>
          <div class="text-2xl font-bold">$25,410</div>
          <div class="text-xs opacity-70">+0.2% since last month</div>
        </div>

        <div :class="['col-span-1 lg:col-span-2 p-4 rounded-lg shadow', dark ? 'bg-gray-800' : 'bg-white']">
          <div class="flex justify-between items-center mb-4">
            <h3 class="text-sm">Revenue</h3>
            <span class="text-xs opacity-70">$1,352</span>
          </div>
          <div class="text-2xl font-bold">$1,352</div>
          <div class="text-xs opacity-70">+3.2% since last month</div>
        </div>

        <!-- Charts -->
        <BarChart :dark="dark" />
        <LineChart :dark="dark" />

        <!-- Finance Cards -->
        <FinanceCard 
          title="Paid Invoices" 
          amount="30256.23" 
          subtitle="Current Fiscal Year" 
          change="+15%" 
          icon="fas fa-receipt" 
          :dark="dark" 
        />
        <FinanceCard 
          title="Funds Received" 
          amount="150256.23" 
          subtitle="Current Fiscal Year" 
          change="+25%" 
          icon="fas fa-money-bill-wave" 
          :dark="dark" 
        />

        <!-- Student Applications Table -->
        <CustomerOrderTable 
          :applications="[
            { student: 'Press', field: 'London', date: '22.08.2022', status: 'Delivered' },
            { student: 'Martha', field: 'Man city', date: '24.08.2022', status: 'Processed' },
            { student: 'Alex', field: 'Unknown', date: '18.08.2022', status: 'Cancelled' },
            { student: 'Robert', field: 'New York', date: '03.08.2022', status: 'Delivered' }
          ]"
          :dark="dark"
        />
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { usePreferredDark } from '@vueuse/core'
import Sidebar from '~/components/AdminDashboard/sidebar.vue'
import Navbar from '~/components/AdminDashboard/NavBar.vue'
import StatCard from '~/components/AdminDashboard/statsCard.vue'
import BarChart from '../../components/AdminDashboard/BarChart.vue'
import LineChart from '~/components/AdminDashboard/LineChart.vue'
import FinanceCard from '~/components/AdminDashboard/FinanceCard.vue'
import CustomerOrderTable from '~/components/AdminDashboard/CustomerOrderTable.vue'

const dark = usePreferredDark()

// You can fetch real stats here using API
onMounted(() => {
  // fetchDashboardStats() would go here
})
</script>