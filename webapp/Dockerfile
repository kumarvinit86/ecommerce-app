# # ---------------------------
# # Stage 1: Builder
# # ---------------------------
# FROM node:20 AS builder

# # Set working directory
# WORKDIR /app

# # Copy root package files for npm workspaces
# COPY package*.json ./

# # Copy workspace project folders
# COPY authentication-app ./authentication-app
# COPY shared-components ./shared-components
# COPY ecommerce-main ./ecommerce-main

# # Install all dependencies (uses npm workspaces)
# RUN npm install

# # Build authentication-app
# RUN npm run --workspace=authentication-app build

# # Build ecommerce-main
# RUN npm run --workspace=ecommerce-main build

# # ---------------------------
# # Stage 2: Production (Nginx)
# # ---------------------------
# FROM nginx:alpine

# # Optional: add your custom nginx config
# # COPY nginx.conf /etc/nginx/nginx.conf
# COPY nginx.conf /etc/nginx/conf.d/default.conf
# # Copy built outputs from builder stage
# COPY --from=builder /app/authentication-app/dist /usr/share/nginx/html/auth
# COPY --from=builder /app/ecommerce-main/dist /usr/share/nginx/html/main

# # Expose HTTP port
# EXPOSE 84
# # Start nginx server
# CMD ["nginx", "-g", "daemon off;"]