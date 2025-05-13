# -------------------------------------------------
# 🔧 Base build for shared-components
# -------------------------------------------------
FROM node:20-alpine AS shared-build
WORKDIR /webapp/shared-components
COPY ./shared-components/package*.json ./
RUN npm install
COPY ./shared-components .
RUN npm run build

# -------------------------------------------------
# 🔧 Build for authentication-app
# -------------------------------------------------
FROM node:20-alpine AS auth-build
WORKDIR /webapp/authentication-app
COPY ./authentication-app/package*.json ./
RUN npm install

# Copy built shared-components and src
COPY --from=shared-build /webapp/shared-components/dist ../shared-components/dist
COPY --from=shared-build /webapp/shared-components/src ../shared-components/src

COPY ./authentication-app .

RUN npm run build

# -------------------------------------------------
# 🔧 Build for ecommerce-main (shell)
# -------------------------------------------------
FROM node:20-alpine AS shell-build
WORKDIR /webapp/ecommerce-main
COPY ./ecommerce-main/package*.json ./
RUN npm install

# Copy built shared-components and src
COPY --from=shared-build /webapp/shared-components/dist ../shared-components/dist
COPY --from=shared-build /webapp/shared-components/src ../shared-components/src

COPY ./ecommerce-main .

RUN npm run build

# -------------------------------------------------
# 🚀 Serve both apps using NGINX
# -------------------------------------------------
FROM nginx:alpine
#COPY ./nginx.conf /etc/nginx/nginx.conf

# Copy build outputs to nginx www
COPY --from=auth-build /webapp/authentication-app/dist /usr/share/nginx/html/auth
COPY --from=shell-build /webapp/ecommerce-main/dist /usr/share/nginx/html/shell

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
