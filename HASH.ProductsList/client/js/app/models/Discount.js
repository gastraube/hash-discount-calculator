class Discount{

    constructor(pct, value_in_cents){
        this._pct = pct;
        this._value_in_cents = value_in_cents;
    } 

    get pct() {
        
        return this._pct;
    }

    get value_in_cents() {
        
        return this._value_in_cents;
    }
}