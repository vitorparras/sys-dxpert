# Estágio 1 - Construir a aplicação
FROM node:lts-alpine as build

WORKDIR /app

COPY package*.json ./

RUN npm install -f

COPY . .

RUN npm run build -- --output-path=./dist/out

# Estágio 2 - Servir a aplicação com um servidor web
FROM nginx:alpine

COPY --from=build /app/dist/out /usr/share/nginx/html

EXPOSE 3000

CMD ["nginx", "-g", "daemon off;"]
