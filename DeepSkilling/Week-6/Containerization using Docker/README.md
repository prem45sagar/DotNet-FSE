# Docker Demo

## Objective

Demonstrate containerization using Docker.

## Technologies

- Docker
- Docker Compose
- HTML
- CSS
- JavaScript
- Nginx

## Files

- Dockerfile
- docker-compose.yml

## Build Docker Image

```bash
docker build -t docker-demo .
```

## Run Container

```bash
docker run -d -p 8080:80 docker-demo
```

## Using Docker Compose

```bash
docker-compose up --build
```

## Open Browser

```
http://localhost:8080
```

## Docker Commands Used

```bash
docker images

docker ps

docker stop <container_id>

docker rm <container_id>

docker rmi docker-demo

docker network ls

docker volume ls
```
