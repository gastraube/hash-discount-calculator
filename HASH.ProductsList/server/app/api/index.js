
var PROTO_PATH = __dirname + '/discount.proto';

var grpc = require('grpc');
var protoLoader = require('@grpc/proto-loader');

var packageDefinition = protoLoader.loadSync(
    PROTO_PATH,
    {keepCase: true,
     longs: String,
     enums: String,
     defaults: true,
     oneofs: true
    });
var discount_proto = grpc.loadPackageDefinition(packageDefinition);


var api = {}

api.product = function(req, res) {
    var client = new discount_proto.Discount('localhost:50051',
    grpc.credentials.createInsecure());

    var productLookUpModel = {
    userId : '1',
    productId : '1'
    };

    client.CalculateDiscount(productLookUpModel, function(err, response) {
        res.status(200).json(response);
    });
 };

module.exports = api;