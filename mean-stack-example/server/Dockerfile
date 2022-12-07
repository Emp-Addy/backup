FROM node:17-slim
WORKDIR /usr/app

# Install dependencies and build the project.
COPY package.json package-lock.json ./
RUN npm install
COPY . .
RUN npm run build

# Run the web service on container startup.
EXPOSE 5200
CMD ["node", "dist/server.js"]
#ctr + shift +p