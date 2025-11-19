// composables/useAuth.ts
import { ref } from 'vue'
import Cookies from 'js-cookie'

interface User {
  id: string
  email: string
  role: 'Student' | 'Company' | 'Admin'
}

const user = ref<User | null>(null)
const token = ref<string | null>(Cookies.get('token') || null)

export const useAuth = () => {
  const login = async (email: string, password: string) => {
    const res = await fetch('http://localhost:5000/api/auth/login', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ email, password })
    })

    if (!res.ok) throw new Error('Login failed')
    const data = await res.json()

    token.value = data.token
    user.value = {
      id: '', // we’ll get this from /me later if needed
      email,
      role: data.role
    }

    Cookies.set('token', token.value, { expires: 1 })
    Cookies.set('role', data.role, { expires: 1 })
  }

  const logout = () => {
    token.value = null
    user.value = null
    Cookies.remove('token')
    Cookies.remove('role')
  }

  const initAuth = () => {
    const savedToken = Cookies.get('token')
    const savedRole = Cookies.get('role') as 'Student' | 'Company' | 'Admin' | undefined
    if (savedToken && savedRole) {
      token.value = savedToken
      user.value = { id: '', email: '', role: savedRole }
    }
  }

  const getRole = () => user.value?.role || Cookies.get('role')

  return { user, token, login, logout, initAuth, getRole }
}