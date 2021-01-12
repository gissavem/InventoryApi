FROM node:latest as compile-image

WORKDIR /app
COPY package*.json ./

RUN npm install

ENV PATH="./node_modules/.bin:$PATH" 
COPY . .

RUN ng build --prod

FROM nginx:latest

COPY --from=compile-image /app/dist/frontend /usr/share/nginx/html