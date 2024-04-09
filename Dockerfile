FROM node:latest

WORKDIR /

COPY package.json package-lock.json* ./

RUN npm install

COPY . .
