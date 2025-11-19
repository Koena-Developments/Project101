<template>
  <div class="max-w-md mx-auto p-6">
    <h1 class="text-2xl mb-4">FoodBev Skills Platform</h1>
    <form @submit.prevent="handleLogin" class="space-y-4">
      <input v-model="email" placeholder="Email" class="border p-2 w-full" />
      <input v-model="password" type="password" placeholder="Password" class="border p-2 w-full" />
      <button type="submit" class="bg-blue-600 text-white px-4 py-2 w-full">Login</button>
    </form>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { useAuth } from '~/composables/useAuth'

const email = ref('')
const password = ref('')
const { login } = useAuth()

const handleLogin = async () => {
  try {
    await login(email.value, password.value)
    // Redirect based on role
    const role = useAuth().getRole()
    if (role === 'Student') return navigateTo('/student/dashboard')
    if (role === 'Company') return navigateTo('/company/dashboard')
    if (role === 'Admin') return navigateTo('/admin/dashboard')
  } catch (e) {
    alert('Invalid credentials')
  }
}
</script>



<!-- WE CAN USE POLYGLOTPERSISTENCE FOR BOTH REAL-TIME DATA TRACKING WE WILL USE NOSQL, STORAGE IS DONE IN THE SQL DATABASE -->

