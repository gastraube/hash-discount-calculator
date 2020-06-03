var PORT = process.env.NODE_PORT || 3000 

var http = require('http')
    ,app = require('./config/express');

http.createServer(app).listen(PORT, function() {
    console.log('Server listening the port: ' + this.address().port);
});

