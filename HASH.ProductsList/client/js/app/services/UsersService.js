class UsersService {
    constructor(){
        this._http = new HttpService();
    }

    getAllUsers(){

        return new Promise((resolve, reject) => {
    
            this._http
            .get('/users', null)
            .then(users => 
                {
                    var returnUsers = [];
                    
                    users.forEach(user => {
                        returnUsers.push(new User(user.id, user.first_name, user.last_name, user.date_of_birth))
                    });
    
                    resolve(returnUsers)
                }
            )
            .catch(error => {
                console.log(error)
                reject(`It wasn't possible to get the users.`)
            });
            
        });
    }
}