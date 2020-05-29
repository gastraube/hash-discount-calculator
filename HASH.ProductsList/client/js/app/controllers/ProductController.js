class ProductController{

        constructor() {
        
            let $ = document.querySelector.bind(document);
      
            this._productsList = new ProductsList()

            var discount = new Discount(0.1, 1);
            var product = new Product("1", 2, "Titulo", "Descricao", discount)

            this._productsList.add(product)

            this._productsView = new ProductsView($('#productsView'));            
            this._productsView.update(this._productsList);

            this._init();
        }
        
        _init(){
    
            // this._service
            //     .lista()
            //     .then(negociacoes => 
            //         negociacoes.forEach(negociacao => 
            //             this._listaNegociacoes.adiciona(negociacao)))
            //     .catch(erro => this._mensagem.texto = erro);
    
            // setInterval(() => {
            //     this.importaNegociacoes();
            // }, 5000);
        }
}