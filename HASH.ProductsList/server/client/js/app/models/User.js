class User{
    
    constructor(id, first_name, last_name, date_of_birth){
        this._id = id;
        this._first_name = first_name;
        this._last_name = last_name;
        this._date_of_birth = date_of_birth;
    }

    
    get id() {
        
        return this._id;
    }
    
    get first_name() {
        
        return this._first_name;
    }

    get last_name() {
        
        return this._last_name;
    }

    get date_of_birth() {
        
        return this._date_of_birth;
    }

}