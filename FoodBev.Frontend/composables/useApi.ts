// composables/useApi.ts
import Cookies from 'js-cookie'

export const useApi = () => {
  const baseUrl = 'http://localhost:5000/api' 

    const token = Cookies.get('token')
    const headers = token ? { Authorization: `Bearer ${token}` } : {}


  const get = async (url: string) => {
    const res = await fetch(`${baseUrl}${url}`)
    if (!res.ok) throw new Error(await res.text())
    return res.json()
  }

  const put = async (url: string, body: any) => {
    const res = await fetch(`${baseUrl}${url}`, {
      method: 'PUT',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(body)
    })
    if (!res.ok) throw new Error(await res.text())
  }

  const post = async (url: string, body?: any) => {
    const options: RequestInit = { method: 'POST' }
    if (body) {
      options.headers = { 'Content-Type': 'application/json' }
      options.body = JSON.stringify(body)
    }
    const res = await fetch(`${baseUrl}${url}`, options)
    if (!res.ok) throw new Error(await res.text())
  }

  return { get, put, post }
}