class UsersList {
    
    constructor() {
        this._users = [];     
    }

    add(user) {       
        this._users.push(user);
    }
    
    get users() {
        
        return [].concat(this._users);
    }    
}