class ProductController{

        constructor() {
        
            let $ = document.querySelector.bind(document);
      
            this._productsList = new ProductsList()
            this._service = new ProductsService();

            this._getProducts();

            this._productsView = new ProductsView($('#productsView'));            
            this._productsView.update(this._productsList);
        }
        
        getCalculatedProductDiscount(){

            this._productsList.products.forEach(product => { 

                this._service
                    .calculateProductDiscount(product.id, '3')
                    .then(product => {

                        let updatedItem =  this._productsList.products.find((p) => { return p.id === product.id })
                        updatedItem.setDiscount(product._discount);
                        
                        this._productsView.update(this._productsList);
                    }
                    ).catch(erro => console.log(erro));
            });   
        }

        _getProducts(){

            var initialDiscount = new Discount(0,0);

            this._productsList.add(new Product(
            
                "1",            
                10,                
                "Copo Plástico",
                "Copo Plástico, vermelho, 200ml.",
                initialDiscount
            ));

            this._productsList.add(new Product(
            
                "2",                
                1000,               
                "iPhone 11",
                "iPhone 11 Pro Max novo na caixa.",
                initialDiscount
            ));
            
            this._productsList.add(new Product(
                "3",                
                150,
                "Relógio",
                "Relógio de pulso, preto.",                
                initialDiscount
            ));

            this._productsList.add(new Product(
                "4",                
                3000,               
                "Monitor LED",
                "Monitor LED 30 polegadas.",
                initialDiscount
            ));

            this._productsList.add(new Product(
                "5",                
                570,            
                "Tênis de Corrida",
                "Tênis de corrida, preto, Nike.",
                initialDiscount
            ));      
        }        
}