<template>
  <div class="admin-dashboard" :class="{ dark: isDark }">
    <!-- Sidebar -->
    <aside class="sidebar">
      <div class="logo-section">
        <div class="logo-icon">F</div>
        <span class="logo-text">FoodBev Admin</span>
      </div>
      <nav class="nav-menu">
        <a href="#" class="nav-link active">
          <i class="icon">📊</i> Analytics
        </a>
        <a href="#" class="nav-link">
          <i class="icon">👥</i> Candidates
        </a>
        <a href="#" class="nav-link">
          <i class="icon">💼</i> Internships
        </a>
        <a href="#" class="nav-link">
          <i class="icon">⚙️</i> Settings
        </a>
      </nav>
      <div class="support-card">
        <div class="avatar-placeholder"></div>
        <p class="support-text">Need help? Feel free to contact us.</p>
        <button class="support-btn">Get Support</button>
      </div>
    </aside>

    <!-- Main Content -->
    <div class="main-content">
      <!-- Top Navbar -->
      <header class="topbar">
        <div class="page-title">Dashboard</div>
        <div class="user-actions">
          <button @click="toggleTheme" class="theme-toggle">
            <span v-if="isDark">☀️</span>
            <span v-else>🌙</span>
          </button>
          <div class="user-avatar">AU</div>
          <span class="user-name">Admin User</span>
        </div>
      </header>

      <!-- Dashboard Grid -->
      <main class="dashboard-grid">
        <!-- Stat Cards -->
        <div class="stat-card">
          <div class="stat-header">
            <h3 class="stat-title">Applications</h3>
            <span class="stat-icon">📄</span>
          </div>
          <div class="stat-value">201</div>
          <div class="stat-change positive">+8.2%</div>
          <div class="stat-subtitle">since last month</div>
        </div>

        <div class="stat-card">
          <div class="stat-header">
            <h3 class="stat-title">Recruited</h3>
            <span class="stat-icon">✅</span>
          </div>
          <div class="stat-value">36</div>
          <div class="stat-change positive">+3.4%</div>
          <div class="stat-subtitle">since last month</div>
        </div>

        <div class="stat-card">
          <div class="stat-header">
            <h3 class="stat-title">Candidates</h3>
            <span class="stat-icon">👥</span>
          </div>
          <div class="stat-value">4,890</div>
          <div class="stat-change positive">+12%</div>
          <div class="stat-subtitle">since last month</div>
        </div>

        <div class="stat-card">
          <div class="stat-header">
            <h3 class="stat-title">Internships</h3>
            <span class="stat-icon">💼</span>
          </div>
          <div class="stat-value">1,201</div>
          <div class="stat-change positive">+5%</div>
          <div class="stat-subtitle">since last month</div>
        </div>

        <!-- Month Total -->
        <div class="finance-summary">
          <div class="summary-header">
            <h3>Month Total</h3>
            <span class="summary-amount">R25,410</span>
          </div>
          <div class="summary-value">R25,410</div>
          <div class="summary-change">+0.2% since last month</div>
        </div>

        <!-- Revenue -->
        <div class="finance-summary">
          <div class="summary-header">
            <h3>Revenue</h3>
            <span class="summary-amount">R1,352</span>
          </div>
          <div class="summary-value">R1,352</div>
          <div class="summary-change">+3.2% since last month</div>
        </div>

        <!-- Charts (placeholders) -->
        <div class="chart-card">
          <h3 class="chart-title">Sales Dynamics</h3>
          <div class="chart-placeholder">
            <div class="bar" style="height: 40%; background: var(--chart-blue);"></div>
            <div class="bar" style="height: 60%; background: var(--chart-blue);"></div>
            <div class="bar" style="height: 30%; background: var(--chart-blue);"></div>
            <div class="bar" style="height: 70%; background: var(--chart-blue);"></div>
            <div class="bar" style="height: 50%; background: var(--chart-blue);"></div>
            <div class="bar" style="height: 80%; background: var(--chart-blue);"></div>
          </div>
        </div>

        <div class="chart-card">
          <h3 class="chart-title">Overall User Activity</h3>
          <div class="line-placeholder">
            <!-- Simplified line visualization -->
            <svg viewBox="0 0 200 60" class="line-graph">
              <polyline
                fill="none"
                stroke="var(--chart-pink)"
                stroke-width="2"
                points="0,50 30,40 60,45 90,30 120,35 150,20 180,25"
              />
            </svg>
          </div>
        </div>

        <!-- Finance Cards -->
        <div class="finance-card">
          <div class="finance-icon">🧾</div>
          <div class="finance-info">
            <div class="finance-title">Paid Invoices</div>
            <div class="finance-amount">R30,256.23</div>
            <div class="finance-period">Current Fiscal Year</div>
          </div>
          <div class="finance-trend positive">+15%</div>
        </div>

        <div class="finance-card">
          <div class="finance-icon">💰</div>
          <div class="finance-info">
            <div class="finance-title">Funds Received</div>
            <div class="finance-amount">R150,256.23</div>
            <div class="finance-period">Current Fiscal Year</div>
          </div>
          <div class="finance-trend positive">+25%</div>
        </div>

        <!-- Student Applications Table -->
        <div class="table-card">
          <div class="table-header">
            <h3>Student Applications</h3>
            <button class="search-btn">🔍</button>
          </div>
          <table class="applications-table">
            <thead>
              <tr>
                <th>Name</th>
                <th>Field</th>
                <th>Applied</th>
                <th>Status</th>
                <th>Action</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>Thandi</td>
                <td>Food Technology</td>
                <td>15.11.2025</td>
                <td><span class="status approved">Approved</span></td>
                <td><button class="view-btn">View</button></td>
              </tr>
              <tr>
                <td>Kagiso</td>
                <td>Beverage Science</td>
                <td>10.11.2025</td>
                <td><span class="status pending">Pending</span></td>
                <td><button class="view-btn">View</button></td>
              </tr>
              <tr>
                <td>Lerato</td>
                <td>Dairy Processing</td>
                <td>05.11.2025</td>
                <td><span class="status rejected">Rejected</span></td>
                <td><button class="view-btn">View</button></td>
              </tr>
            </tbody>
          </table>
        </div>
      </main>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { usePreferredDark } from '@vueuse/core'

const isDark = usePreferredDark()
const toggleTheme = () => {
  document.documentElement.classList.toggle('dark')
}
</script>

<style scoped>


.admin-dashboard {
  display: flex;
  min-height: 100vh;
  background-color: #f9fafb;
  color: #111827;
  font-family: 'Segoe UI', system-ui, sans-serif;
}

/* Dark Theme */
.admin-dashboard.dark {
  background-color: #111827;
  color: #f9fafb;
}

/* --- Sidebar --- */
.sidebar {
  width: 16rem;
  background: #ffffff;
  border-right: 1px solid #e5e7eb;
  padding: 1rem;
  display: flex;
  flex-direction: column;
  position: fixed;
  height: 100vh;
  box-sizing: border-box;
}

.admin-dashboard.dark .sidebar {
  background: #1f2937;
  border-right-color: #374151;
}

.logo-section {
  display: flex;
  align-items: center;
  margin-bottom: 2rem;
}

.logo-icon {
  width: 2rem;
  height: 2rem;
  background: #8B5CF6;
  color: white;
  border-radius: 0.375rem;
  display: flex;
  align-items: center;
  justify-content: center;
  font-weight: bold;
  margin-right: 0.5rem;
}

.logo-text {
  font-weight: 600;
  font-size: 1.125rem;
}

.nav-menu {
  flex: 1;
}

.nav-link {
  display: flex;
  align-items: center;
  padding: 0.75rem;
  border-radius: 0.5rem;
  text-decoration: none;
  color: #4b5563;
  margin-bottom: 0.25rem;
}

.nav-link:hover,
.nav-link.active {
  background: #f3f4f6;
  color: #8B5CF6;
}

.admin-dashboard.dark .nav-link:hover,
.admin-dashboard.dark .nav-link.active {
  background: #374151;
  color: #c084fc;
}

.icon {
  margin-right: 0.75rem;
  font-size: 1.125rem;
}

.support-card {
  margin-top: auto;
  padding: 1rem;
  background: #eff6ff;
  border-radius: 0.75rem;
  text-align: center;
}

.admin-dashboard.dark .support-card {
  background: #1e293b;
}

.avatar-placeholder {
  width: 3rem;
  height: 3rem;
  background: #dbeafe;
  border-radius: 50%;
  margin: 0 auto 0.5rem;
}

.admin-dashboard.dark .avatar-placeholder {
  background: #334155;
}

.support-text {
  font-size: 0.75rem;
  color: #374151;
  margin: 0.25rem 0;
}

.admin-dashboard.dark .support-text {
  color: #9ca3af;
}

.support-btn {
  background: #2563eb;
  color: white;
  border: none;
  padding: 0.25rem 0.5rem;
  border-radius: 0.25rem;
  font-size: 0.75rem;
  cursor: pointer;
  width: 100%;
}

/* --- Main Content --- */
.main-content {
  flex: 1;
  margin-left: 16rem;
}

.topbar {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 1.25rem 1.5rem;
  border-bottom: 1px solid #e5e7eb;
  background: white;
}

.admin-dashboard.dark .topbar {
  background: #1f2937;
  border-bottom-color: #374151;
}

.page-title {
  font-size: 1.5rem;
  font-weight: 600;
}

.user-actions {
  display: flex;
  align-items: center;
  gap: 1rem;
}

.theme-toggle {
  background: none;
  border: none;
  font-size: 1.25rem;
  cursor: pointer;
  width: 2.5rem;
  height: 2.5rem;
  border-radius: 0.5rem;
  display: flex;
  align-items: center;
  justify-content: center;
}

.theme-toggle:hover {
  background: #f3f4f6;
}

.admin-dashboard.dark .theme-toggle:hover {
  background: #374151;
}

.user-avatar {
  width: 2.5rem;
  height: 2.5rem;
  background: #8B5CF6;
  color: white;
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
  font-weight: bold;
}

.user-name {
  font-weight: 500;
}

/* --- Dashboard Grid --- */
.dashboard-grid {
  padding: 1.5rem;
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(280px, 1fr));
  gap: 1.5rem;
}

@media (min-width: 1024px) {
  .dashboard-grid {
    grid-template-columns: repeat(4, 1fr);
  }

  .dashboard-grid > .finance-summary:nth-child(5),
  .dashboard-grid > .finance-summary:nth-child(6) {
    grid-column: span 2;
  }

  .dashboard-grid > .chart-card,
  .dashboard-grid > .finance-card,
  .dashboard-grid > .table-card {
    grid-column: span 2;
  }
}

/* Stat Cards */
.stat-card {
  background: white;
  border-radius: 0.75rem;
  padding: 1.25rem;
  box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1), 0 2px 4px -1px rgba(0, 0, 0, 0.06);
}

.admin-dashboard.dark .stat-card {
  background: #1f2937;
}

.stat-header {
  display: flex;
  justify-content: space-between;
  margin-bottom: 0.75rem;
}

.stat-title {
  font-size: 0.875rem;
  color: #6b7280;
}

.admin-dashboard.dark .stat-title {
  color: #9ca3af;
}

.stat-icon {
  font-size: 1.25rem;
}

.stat-value {
  font-size: 1.875rem;
  font-weight: 700;
  margin-bottom: 0.25rem;
}

.admin-dashboard.dark .stat-value {
  color: white;
}

.stat-change {
  font-size: 0.75rem;
  font-weight: 600;
  margin-bottom: 0.25rem;
}

.stat-change.positive {
  color: #10B981;
}

.stat-subtitle {
  font-size: 0.75rem;
  color: #9ca3af;
}

/* Finance Summary */
.finance-summary {
  background: white;
  border-radius: 0.75rem;
  padding: 1.25rem;
  box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1), 0 2px 4px -1px rgba(0, 0, 0, 0.06);
}

.admin-dashboard.dark .finance-summary {
  background: #1f2937;
}

.summary-header {
  display: flex;
  justify-content: space-between;
  margin-bottom: 0.75rem;
}

.summary-header h3 {
  font-size: 0.875rem;
  color: #6b7280;
}

.admin-dashboard.dark .summary-header h3 {
  color: #9ca3af;
}

.summary-amount {
  font-size: 0.875rem;
  color: #6b7280;
}

.summary-value {
  font-size: 1.875rem;
  font-weight: 700;
  margin-bottom: 0.25rem;
}

.admin-dashboard.dark .summary-value {
  color: white;
}

.summary-change {
  font-size: 0.75rem;
  color: #9ca3af;
}

/* Charts */
.chart-card {
  background: white;
  border-radius: 0.75rem;
  padding: 1.25rem;
  box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1), 0 2px 4px -1px rgba(0, 0, 0, 0.06);
}

.admin-dashboard.dark .chart-card {
  background: #1f2937;
}

.chart-title {
  font-size: 0.875rem;
  color: #6b7280;
  margin-bottom: 1rem;
}

.admin-dashboard.dark .chart-title {
  color: #9ca3af;
}

.chart-placeholder {
  display: flex;
  align-items: flex-end;
  height: 5rem;
  gap: 0.5rem;
  padding: 0 0.5rem;
}

.bar {
  flex: 1;
  border-radius: 0.25rem 0.25rem 0 0;
  transition: height 0.3s ease;
}

.line-placeholder {
  height: 5rem;
  display: flex;
  align-items: flex-end;
}

.line-graph {
  width: 100%;
  height: 100%;
}

/* Finance Cards */
.finance-card {
  background: white;
  border-radius: 0.75rem;
  padding: 1.25rem;
  display: flex;
  align-items: center;
  box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1), 0 2px 4px -1px rgba(0, 0, 0, 0.06);
}

.admin-dashboard.dark .finance-card {
  background: #1f2937;
}

.finance-icon {
  font-size: 1.5rem;
  margin-right: 1rem;
}

.finance-info {
  flex: 1;
}

.finance-title {
  font-size: 0.875rem;
  color: #6b7280;
  margin-bottom: 0.25rem;
}

.admin-dashboard.dark .finance-title {
  color: #9ca3af;
}

.finance-amount {
  font-size: 1.25rem;
  font-weight: 700;
  margin-bottom: 0.25rem;
}

.admin-dashboard.dark .finance-amount {
  color: white;
}

.finance-period {
  font-size: 0.75rem;
  color: #9ca3af;
}

.finance-trend {
  font-size: 0.75rem;
  font-weight: 600;
  padding: 0.25rem 0.5rem;
  border-radius: 9999px;
}

.finance-trend.positive {
  background: #ecfdf5;
  color: #047857;
}

.admin-dashboard.dark .finance-trend.positive {
  background: #064e3b;
  color: #6ee7b7;
}

/* Table Card */
.table-card {
  background: white;
  border-radius: 0.75rem;
  padding: 1.25rem;
  box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1), 0 2px 4px -1px rgba(0, 0, 0, 0.06);
  grid-column: span 4 !important;
}

.admin-dashboard.dark .table-card {
  background: #1f2937;
}

.table-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 1rem;
}

.table-header h3 {
  font-size: 0.875rem;
  color: #6b7280;
}

.admin-dashboard.dark .table-header h3 {
  color: #9ca3af;
}

.search-btn {
  background: none;
  border: none;
  font-size: 1rem;
  cursor: pointer;
  color: #6b7280;
}

.admin-dashboard.dark .search-btn {
  color: #9ca3af;
}

.applications-table {
  width: 100%;
  border-collapse: collapse;
  font-size: 0.875rem;
}

.applications-table th {
  text-align: left;
  padding: 0.75rem 0.5rem;
  color: #6b7280;
  border-bottom: 1px solid #e5e7eb;
}

.admin-dashboard.dark .applications-table th {
  color: #9ca3af;
  border-bottom-color: #374151;
}

.applications-table td {
  padding: 0.75rem 0.5rem;
  border-bottom: 1px solid #e5e7eb;
}

.admin-dashboard.dark .applications-table td {
  border-bottom-color: #374151;
}

.status {
  padding: 0.25rem 0.5rem;
  border-radius: 9999px;
  font-size: 0.75rem;
  font-weight: 600;
}

.status.approved {
  background: #ecfdf5;
  color: #047857;
}

.status.pending {
  background: #fffbeb;
  color: #92400e;
}

.status.rejected {
  background: #fef2f2;
  color: #b91c1c;
}

.admin-dashboard.dark .status.approved {
  background: #064e3b;
  color: #6ee7b7;
}

.admin-dashboard.dark .status.pending {
  background: #431407;
  color: #fbbf24;
}

.admin-dashboard.dark .status.rejected {
  background: #450a0a;
  color: #fecaca;
}

.view-btn {
  background: none;
  border: none;
  color: #8B5CF6;
  font-size: 0.875rem;
  cursor: pointer;
  text-decoration: underline;
}

.admin-dashboard.dark .view-btn {
  color: #c084fc;
}
</style>