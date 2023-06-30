FROM node:16-alpine as build-stage
RUN npm install -g --force yarn
WORKDIR /app

RUN apk update
RUN apk add python3
RUN apk add --update alpine-sdk

COPY package.json ./
RUN yarn install

COPY . .
RUN yarn run build --source-map=false

FROM nginx:stable-alpine as production-stage
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]

COPY --from=build-stage /app/dist/nosso-zap /usr/share/nginx/html