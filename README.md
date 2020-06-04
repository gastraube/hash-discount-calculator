# Hash Discount Simulator
This application uses two microservices to calculate products discounts and show them in a web page.

## Architecture: 
![Solution Architecture](https://github.com/gastraube/hash-discount-calculator/blob/master/HASH.ProductsList/client/img/scheme.JPG?raw=true)


## How To Run

## Projet Description 
### Service 1 - Calculating The Discounts
Service 1 has 3 responsabilities:;
1 - Read the mongoDB database;
2 - Send to server 2 all Products via gRPC;
3 - Send to server 2 all Users via gRPC;
4 - Recieve a Procuct and calculate it's discount and send it back to Server 2;

It uses .NET core and C#.

### Service 2 - List The Products
1 - Ask to Server 1 all Products via gRPC and sent it to the client page;
2 - Ask to Server 1 all Users via gRPC and sent it to the client page;
4 - Send a Procuct to Server 2 calculate it discount and sent it to the client page;

It uses Node.js to the server and the client is a webPage with HTML, CSS, JavaScript and Bootstrap.
