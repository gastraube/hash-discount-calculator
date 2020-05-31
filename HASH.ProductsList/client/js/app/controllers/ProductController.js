class ProductController{

        constructor() {
        
            let $ = document.querySelector.bind(document);
      
            this._productsList = new ProductsList()
            this._service = new ProductsService();

            getProducts();

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

        getProducts(){
            this._productsList.add(new Product(
            
                "1",
                "Copo Plástico, vermelho, 200ml.",
                10,
                "Copo Plástico"
            ));

            this._productsList.add(new Product(
            
                "2",
                "iPhone 11 Pro Max novo na caixa.",
                100000000,
                "iPhone 11"
            ));
            

            this._productsList.add(new Product(
                "3",
                "Relógio de pulso, preto.",
                200,
                "Relógio"
            ));

            this._productsList.add(new Product(
                "4",
                "Monitor LED 30 polegadas.",
                3000,
                "Monitor LED"
            ));

            this._productsList.add(new Product(
                "5",
                "Tênis de corrida, preto, Nike.",
                570,
                "Tênis de Corrida"
            ));
        }        
}