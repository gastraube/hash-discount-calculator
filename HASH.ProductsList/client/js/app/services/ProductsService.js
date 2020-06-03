class ProductsService {
    constructor(){
        this._http = new HttpService();
    }

   calculateProductDiscount(productId, userId){

        var productLookUpModel = {
            userId : userId,
            productId : productId
        };

        return new Promise((resolve, reject) => {

            this._http
            .get('/product', productLookUpModel)
            .then(product => 
                {
                    resolve(new Product(product.id, product.price_in_cents, product.title, product.description, product.discount))
                }
            )
            .catch(error => {
                console.log(error)
                reject(`It wasn't possible to get the product with Id ${productId}, discount.`)
            });
            
        });
   }
}