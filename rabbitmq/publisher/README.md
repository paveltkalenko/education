
Создания docker-образа
docker build -t tkalenko/rabbitmq-publisher:v1 .


Запуска контейнера
docker run -d --network queue-bridge tkalenko/rabbitmq-publisher:v1 I love you

----

docker network create -d bridge queue-bridge

docker pull rabbitmq

docker run --network bridge -p 15672:15672 --name rabbit -d --hostname first-rabbit rabbitmq:3-management

docker run -it --name nettest --network queue-bridge alpine