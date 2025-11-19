<template>
  <div class="w-64 h-screen bg-white border-r p-4 fixed left-0 top-0">
    <div class="flex items-center space-x-2 mb-8">
      <div class="w-8 h-8 bg-purple-600 rounded flex items-center justify-center text-white font-bold">F</div>
      <span class="font-semibold">FoodBev Admin</span>
    </div>
    <nav class="space-y-2">
      <router-link to="/admin/dashboard" active-class="bg-purple-100 text-purple-700" class="flex items-center p-3 rounded cursor-pointer hover:bg-gray-100">
        <i class="fas fa-chart-line mr-3"></i> Analytics
      </router-link>
      <router-link to="/admin/students" active-class="bg-purple-100 text-purple-700" class="flex items-center p-3 rounded cursor-pointer hover:bg-gray-100">
        <i class="fas fa-users mr-3"></i> Students
      </router-link>
      <router-link to="/admin/internships" active-class="bg-purple-100 text-purple-700" class="flex items-center p-3 rounded cursor-pointer hover:bg-gray-100">
        <i class="fas fa-briefcase mr-3"></i> Internships
      </router-link>
      <router-link to="/admin/settings" active-class="bg-purple-100 text-purple-700" class="flex items-center p-3 rounded cursor-pointer hover:bg-gray-100">
        <i class="fas fa-cog mr-3"></i> Settings
      </router-link>
    </nav>
    <div class="mt-10 p-4 bg-blue-50 rounded">
      <img src="https://via.placeholder.com/60" class="mx-auto rounded-full mb-2" />
      <p class="text-xs text-center">Need help? Feel free to contact us.</p>
      <button class="mt-2 w-full bg-blue-600 text-white py-1 rounded text-xs">Get Support</button>
    </div>
  </div>
</template>