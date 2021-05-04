FROM node:10-alpine
COPY ReactJS/ReactJS-UnitTesting/ .
CMD PORT=30005 npm run start
