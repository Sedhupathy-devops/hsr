FROM node:10-alpine
COPY . .
CMD PORT=30005 npm run start
