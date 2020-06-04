class ProductsList {
    
    constructor() {
        this._products = [];     
    }

    add(product) {       
        this._products.push(product);
    }
    
    get products() {
        
        return [].concat(this._products);
    }

    empty(){
        this._products = [];        
    }
    
    
    addProductsList(products) {
        
        return this._products = this._products.concat(products);
    }
}