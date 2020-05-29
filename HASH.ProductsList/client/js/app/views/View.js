class View {
    
    constructor(elemento) {
        
        this._elemento = elemento;
    }
    
    template() {
        
        throw new Error('The Template method needs to be implemented.');
    }
    
    update(model) {
        
        this._elemento.innerHTML = this.template(model);
    }
}