# 🛍️ Ecommerce Web (Shell App)

This is the **shell application** (host app) for our modular **E-Commerce Platform** built using **Micro Frontend Architecture** with **Webpack 5 Module Federation**. The goal is to create a scalable, maintainable, and independently deployable e-commerce system.

---

## 🚀 Project Vision

We're building a **Micro Frontend-based E-Commerce Platform** where each business domain is developed as an independent app (remote), and integrated into the shell app dynamically at runtime.

Key features include:
- Decoupled feature modules (auth, product catalog, cart, etc.)
- Shared state and API utilities
- Seamless UI integration
- Scalable team development

---

## 🧱 Micro Frontends (Remotes)

| App               | Port  | Purpose                         |
|------------------|-------|---------------------------------|
| `ecommerce-web`  | 3000  | Shell app / main container      |
| `authentication` | 3001  | Login, Signup, Auth handling    |
| `products`       | TBD   | Product listing, details, etc.  |
| `cart`           | TBD   | Cart management                 |
| `checkout`       | TBD   | Address, payment, confirmation  |
| `shared-utils`   | N/A   | Shared API clients, Zustand, etc.|

---

## 🛠️ Tech Stack

- **React 18 + TypeScript**
- **Webpack 5 + Module Federation**
- **Zustand** for state management
- **Axios** for API communication
- **Tailwind CSS** or CSS Modules for styling
- **React Router** for navigation (shell)
- **SignalR** (future) for real-time notifications
- **Azure / Kubernetes** (deployment plan)

---


---

## 🔄 Shared Functionality

We plan to share the following across apps via `shared-utils`:
- ✅ `apiClient.ts`: Centralized Axios config with token handling
- ✅ `zustandStore.ts`: Shared global state (e.g., user info)
- ✅ `AuthContext` or `useAuth` hook
- 🔄 `ErrorBoundary`, `LoadingSpinner`, and UI components

---

## 🧪 Future Enhancements

- [ ] Implement Role-Based Access Control (RBAC)
- [ ] Add toast and error handlers globally
- [ ] Integrate logging and monitoring
- [ ] Setup CI/CD pipelines (GitHub Actions + Azure)
- [ ] Add unit tests with `Jest` and `React Testing Library`

---

## 💡 Why Micro Frontends?

- Independent team deployment & testing
- Parallel development on isolated features
- Tech stack flexibility (if needed in future)
- Better maintainability as app grows

---

## 👨‍💻 Local Development

Each micro frontend is run on its own port:

```bash
# Run Shell App
cd ecommerce-web
npm install
npm run start

# Run Authentication App
cd ../authentication-app
npm install
npm run start
