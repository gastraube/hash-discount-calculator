var api = require('../api');

module.exports  = function(app) {
            
    app.route('/product')
        .post(api.product);

    app.route('/products')
        .get(api.products);

    app.route('/users')
        .get(api.users);
};