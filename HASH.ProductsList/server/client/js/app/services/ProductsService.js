class ProductsService {
    constructor(){
        this._http = new HttpService();
    }

   calculateProductDiscount(productId, userId, todayDate){

        var productLookUpModel = {
            userId : userId,
            productId : productId,
            todayDate : todayDate
        };

        return new Promise((resolve, reject) => {

            this._http
            .post('/product', productLookUpModel)
            .then(product => 
                {
                    resolve(new Product(product.id, product.price_in_cents, product.title, product.description, product.discount))
                }
            )
            .catch(error => {
                console.log(error)
                reject(`It wasn't possible to calculate one or more Products discount.`)
            });
            
        });
   }

   getAllProducts(){

    return new Promise((resolve, reject) => {

        this._http
        .get('/products', null)
        .then(products => 
            {
                var returnProducts = [];
                
                products.forEach(product => {
                    returnProducts.push(new Product(product.id, product.price_in_cents, product.title, product.description, product.discount))
                });

                resolve(returnProducts)
            }
        )
        .catch(error => {
            console.log(error)
            reject(`It wasn't possible to get the products.`)
        });
        
    });
}
}