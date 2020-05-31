class ProductController{

        constructor() {
        
            let $ = document.querySelector.bind(document);
      
            this._productsList = new ProductsList()
            this._service = new ProductsService();

            var discount = new Discount(0, 0);
            var product = new Product("1", 2, "Titulo", "Descricao", discount)

            this._productsList.add(product)

            this._productsView = new ProductsView($('#productsView'));            
            this._productsView.update(this._productsList);
        }
        
        getCalculatedProductDiscount(){

            this._productsList.products.forEach(product => { 

                this._service
                    .calculateProductDiscount(product.id, '1')
                    .then(product => {

                        if(!this._productsList.products.some(actualProduct =>
                            JSON.stringify(product) == JSON.stringify(actualProduct))){
                                this._productsList.add(product)
                        }

                        this._productsView.update(this._productsList);
                    }
                    ).catch(erro => console.log(erro));
            });   
        }
}