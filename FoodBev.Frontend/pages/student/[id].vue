<template>
  <div class="p-6 max-w-4xl mx-auto">
    <h1 class="text-2xl font-bold mb-4">Student Dashboard</h1>

    <div v-if="student && !student.profileComplete" class="bg-yellow-100 p-4 rounded mb-6">
      <p>Please complete your profile to see internship opportunities.</p>
    </div>

    <form v-if="student" @submit.prevent="saveProfile" class="space-y-4 mb-8">
      <input v-model="form.firstName" placeholder="First Name" class="border p-2 w-full" />
      <input v-model="form.lastName" placeholder="Last Name" class="border p-4 w-full" />
      <input v-model="form.fieldOfStudy" placeholder="Field of Study (e.g., Food Technology)" class="border p-2 w-full" />
      <textarea v-model="form.qualifications" placeholder="Qualifications" class="border p-2 w-full"></textarea>
      <textarea v-model="form.employmentHistory" placeholder="Employment History" class="border p-2 w-full"></textarea>
      <button type="submit" class="bg-blue-600 text-white px-4 py-2 rounded">Save Profile</button>
    </form>

    <!-- Internships -->
    <div v-if="internships.length" class="mb-8">
      <h2 class="text-xl font-semibold mb-2">Available Internships</h2>
      <div v-for="job in internships" :key="job.id" class="border p-4 mb-3 rounded">
        <h3 class="font-bold">{{ job.title }} @ {{ job.companyName }}</h3>
        <p>{{ job.description }}</p>
        <button 
          @click="apply(job.id)" 
          class="mt-2 bg-green-600 text-white px-3 py-1 rounded text-sm"
        >
          Apply
        </button>
      </div>
    </div>

    <!-- Analytics -->
    <div>
      <h3 class="font-semibold">Profile Views ({{ views.length }})</h3>
      <ul class="mt-2">
        <li v-for="(view, i) in views" :key="i">
          {{ view.companyName }} — {{ new Date(view.viewedAt).toLocaleDateString() }}
        </li>
      </ul>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { useRoute } from 'vue-router'
import { useApi } from '../../composables/useApi'

interface Student {
  id: string
  firstName: string
  lastName: string
  email: string
  fieldOfStudy: string
  qualifications: string
  employmentHistory: string
  profileComplete: boolean
}

interface Internship {
  id: string
  title: string
  companyName: string
  description: string
  requiredField: string
  postedDate: string
}

interface ProfileView {
  companyName: string
  viewedAt: string
}

const route = useRoute()
const studentId = route.params.id as string
const api = useApi()

const student = ref<Student | null>(null)
const internships = ref<Internship[]>([])
const views = ref<ProfileView[]>([])

const form = ref({
  id: studentId,
  firstName: '',
  lastName: '',
  email: '',
  fieldOfStudy: '',
  qualifications: '',
  employmentHistory: ''
})

const loadStudent = async () => {
  try {
    const data = await api.get(`/students/${studentId}`)
    student.value = data
    form.value = { ...data }

    if (data.profileComplete) {
      internships.value = await api.get(`/students/${studentId}/internships`)
      views.value = await api.get(`/students/${studentId}/views`)
    }
  } catch (e) {
    console.error(e)
    alert('Failed to load student data')
  }
}

const saveProfile = async () => {
  try {
    await api.put(`/students/${studentId}/profile`, form.value)
    await loadStudent()
    alert('Profile saved!')
  } catch (e) {
    alert('Failed to save profile')
  }
}

const apply = async (internshipId: string) => {
  try {
    await api.post(`/students/${studentId}/apply/${internshipId}`)
    alert('Application submitted!')
  } catch (e) {
    alert('Application failed')
  }
}

onMounted(() => {
  loadStudent()
})
</script>