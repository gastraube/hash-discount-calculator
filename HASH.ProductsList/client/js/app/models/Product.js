class Product{

    constructor(id, price_in_cents, title, description, discount){
        
        this._id = id;
        this._price_in_cents = price_in_cents;
        this._title = title;
        this._description = description;
        this._discount = discount;
        
    } 

    get id() {
        
        return this._id;
    }

    get price_in_cents() {
        
        return this._price_in_cents;
    }

    get title() {
        
        return this._title;
    }

    get description() {
        
        return this._description;
    }

    get discount() {
        
        return this._discount;
    }

    setDiscount(discount){
        return this._discount = discount;
    }

}