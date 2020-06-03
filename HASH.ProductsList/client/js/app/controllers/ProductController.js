class ProductController{

        constructor() {
                      
            let $ = document.querySelector.bind(document);           

            this._productsService = new ProductsService();
            this._usersService = new UsersService();

            this._getProducts();
            this._setTodayDate();
            this._getUsers();

            this._messageView = new MessageView($('#messageView'));   
            this._message = new Message();
                        
       
        }
        
        _setTodayDate(){
            let $ = document.querySelector.bind(document);           

            Date.prototype.toDateInputValue = (function() {
                var local = new Date(this);
                local.setMinutes(this.getMinutes() - this.getTimezoneOffset());
                return local.toJSON().slice(0,10);
            });

            var todayDate = $('#today-date');
            todayDate.value = new Date().toDateInputValue();
        }

        _getCalculatedProductDiscount(){

            this._productsList.products.forEach(product => { 

                this._productsService
                    .calculateProductDiscount(product.id, '5ed704bc6b98434760615023')
                    .then(product => {

                        let updatedItem =  this._productsList.products.find((p) => { return p.id === product.id })
                        updatedItem.setDiscount(product._discount);
                        
                        this._productsView.update(this._productsList);
                    }
                    ).catch(error => {
                        console.log(error)
                        this._message.text = error;
                        this._messageView.update(this._message);
                    });
            });   
        }

        _getProducts(){
            let $ = document.querySelector.bind(document);
            this._productsList = new ProductsList()
           
            this._productsService
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

        _getUsers(){
            let $ = document.querySelector.bind(document);        
            var usersList = $("#users");
            
            this._usersService
                .getAllUsers()
                .then(users => {
                    
                    users.forEach(user => {   
                        var option = document.createElement("option");                              
                        option.text = `${user.first_name} ${user.last_name}`;
                        option.value = user.id;
                        usersList.add(option);
                    })
                    
                }
                ).catch(error => {
                    console.log(error)
                    this._message.text = `${this._message.text} ${error}<br/>`;
                    this._messageView.update(this._message);
            });
        }
}