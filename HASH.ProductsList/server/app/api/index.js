var PORT = process.env.HASHCALCULATOR_PORT || 50051 
var HOST = process.env.HASHCALCULATOR_HOST || "localhost" 

var api = {}

var protoPath = __dirname + '/discount.proto';
var grpc = require('grpc');
var protoLoader = require('@grpc/proto-loader');
var serverPort = `${HOST}:` + PORT

var packageDefinition = protoLoader.loadSync(
    protoPath,
    {keepCase: true,
     longs: String,
     enums: String,
     defaults: true,
     oneofs: true
    });

var discount_proto = grpc.loadPackageDefinition(packageDefinition);
var client = new discount_proto.Discount(serverPort, grpc.credentials.createInsecure());

api.product = function(req, res) {
    client.CalculateDiscount(req.body, function(err, response) {      
        res.status(200).json(response);
    });
 };

 api.products = function(req, res) {
    console.log(PORT)
    console.log(HOST)
    var call = client.GetAllProducts(null);

    var products =[];

    call.on('data',function(response){
        products.push(response)
      });
    
    call.on('end',function(){
        console.log(products)
        res.status(200).json(products);
    });      
 };

 api.users = function(req, res) {
    var call = client.GetAllUsers(null);

    var users =[];

    call.on('data',function(response){
        users.push(response)
      });
    
    call.on('end',function(){
        res.status(200).json(users);
    });      
 };

module.exports = api;