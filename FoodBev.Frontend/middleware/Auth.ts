import { useAuth } from "~/composables/useAuth"

// middleware/auth.ts
export default defineNuxtRouteMiddleware((to, from) => {
  const { getRole } = useAuth()
  const role = getRole()

  // Public routes
  if (to.path === '/login') return

  // Protected routes
  if (!role) {
    return navigateTo('/login')
  }

  // Role-based route protection (optional)
  if (to.path.startsWith('/student') && role !== 'Student') {
    return navigateTo('/unauthorized')
  }
  if (to.path.startsWith('/company') && role !== 'Company') {
    return navigateTo('/unauthorized')
  }
  if (to.path.startsWith('/admin') && role !== 'Admin') {
    return navigateTo('/unauthorized')
  }
})