class View {
    
    constructor(element) {
        
        this._element = element;
    }
    
    template() {
        
        throw new Error('The Template method needs to be implemented.');
    }
    
    update(model) {
        
        this._element.innerHTML = this.template(model);
    }
}