class HttpService{
    constructor(){
        
    }

    post(url, dado) {
        return new Promise((resolve, reject) => {

            let xhr = new XMLHttpRequest();
            xhr.open("POST", url, true);
            xhr.setRequestHeader("Content-type", "application/json");
            xhr.onreadystatechange = () => {

                if (xhr.readyState == 4) {

                    if (xhr.status == 200) {

                        if(xhr.responseText == "")
                            reject("Invalid JSON response");

                        resolve(JSON.parse(xhr.responseText));
                    } else {

                        reject(xhr.responseText);
                    }
                }
            };
            xhr.send(JSON.stringify(dado));
        });
    }

    get(url){
        return new Promise((resolve, reject) => {

            let xhr = new XMLHttpRequest();
    
            xhr.open('GET', url);
    
            xhr.onreadystatechange = () => {
    
                if(xhr.readyState == 4){
                    if(xhr.status == 200){
                        resolve(JSON.parse(xhr.responseText));
                    }else{
                        reject(xhr.responseText)
                    }
                };
            }
    
            xhr.send();
        }); 
    }

}