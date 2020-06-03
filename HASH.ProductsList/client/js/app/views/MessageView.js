class MessageView extends View {
    
    constructor(element) {
       super(element);
    }
    
   template(model) {
       
       return model.text ? `<p class="alert alert-info">${model.text}</p>` : '<p></p>';
   }

   update(model) {
        
    this._element.innerHTML = this.template(model);

    setInterval(() => {
        this._element.style.display = "none";
    }, 15000);
}
}