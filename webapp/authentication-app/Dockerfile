# Stage 1: Build
FROM node:20 AS builder
WORKDIR /app
COPY ../shared-components ./shared-components
COPY . .
RUN npm install
RUN npm run --workspace=authentication-app build

# Stage 2: Serve with Nginx
FROM nginx:alpine
COPY nginx.conf /etc/nginx/conf.d/default.conf
COPY --from=builder /app/authentication-app/dist /usr/share/nginx/html/auth/
EXPOSE 84
CMD ["nginx", "-g", "daemon off;"]