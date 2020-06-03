class ProductController{

        constructor() {
                      
            let $ = document.querySelector.bind(document);
            this._service = new ProductsService();

            this._getProducts();
            
            this._messageView = new MessageView($('#messageView'));   
            this._message = new Message();
        }
        
        getCalculatedProductDiscount(){

            this._productsList.products.forEach(product => { 

                this._service
                    .calculateProductDiscount(product.id, '5ed704bc6b98434760615023')
                    .then(product => {

                        let updatedItem =  this._productsList.products.find((p) => { return p.id === product.id })
                        updatedItem.setDiscount(product._discount);
                        
                        this._productsView.update(this._productsList);
                    }
                    ).catch(error => {
                        console.log(error)
                        this._message.text = `${this._message.text} ${error}<br/>`;
                        this._messageView.update(this._message);
                    });
            });   
        }

        _getProducts(){
            let $ = document.querySelector.bind(document);
            this._productsList = new ProductsList()
           

            this._service
                .getAllProducts()
                .then(products => {
                    
                    this._productsList.addProductsList(products);
                    this._productsView = new ProductsView($('#productsView'));            
                    this._productsView.update(this._productsList);
                    
                }
                ).catch(error => {
                    console.log(error)
                    this._message.text = `${this._message.text} ${error}<br/>`;
                    this._messageView.update(this._message);
            });
        }        
}