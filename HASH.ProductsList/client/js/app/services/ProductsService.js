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
            .then(objeto => 
                resolve(new Product(objeto.id, objeto.price_in_cents, objeto.title, objeto.description, objeto.discount))
            )
            .catch(erro => {
                console.log(erro)
                reject("It wasn't possible to get the product discount.")
            });
            
        });
   }
}