class MessageView extends View {
    
    constructor(element) {
       super(element);
    }
    
   template(model) {
       
       return model.text ? `<div class="alert alert-primary" role="alert">${model.text}</div>` : '<div></div>';
   }

   update(model) {
        
    this._element.innerHTML = this.template(model);

    setInterval(() => {
        this._element.style.display = "none";
    }, 15000);
}
}