var api = require('../api');

module.exports  = function(app) {
            
    app.route('/product')
        .post(api.product);
};