
var api = {}

var protoPath = __dirname + '/discount.proto';
var grpc = require('grpc');
var protoLoader = require('@grpc/proto-loader');
var serverPort = 'localhost:50051'

var packageDefinition = protoLoader.loadSync(
    protoPath,
    {keepCase: true,
     longs: String,
     enums: String,
     defaults: true,
     oneofs: true
    });

var discount_proto = grpc.loadPackageDefinition(packageDefinition);
function main() {
    var client = new discount_proto.Discount(serverPort, grpc.credentials.createInsecure());

    client.GetAllProducts(null, null, function(err, response) {
        console.log(response)
        res.status(200).json(response);
    });

//   var user;
//   if (process.argv.length >= 3) {
//     user = process.argv[2];
//   } else {
//     user = 'world';
//   }
//   client.sayHello({name: user}, function(err, response) {
//     console.log('Greeting:', response.message);
//   });
}

main();