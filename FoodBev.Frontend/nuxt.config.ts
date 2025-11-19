// nuxt.config.ts
export default defineNuxtConfig({
  devtools: { enabled: true },
  typescript: { strict: true },
  router: {
    middleware: ['auth']
  }
})

