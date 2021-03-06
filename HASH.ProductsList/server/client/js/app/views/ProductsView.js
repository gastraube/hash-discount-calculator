class ProductsView extends View {
    
    constructor(element) {
        super(element);
    }
    
    template(model) {
        
        return `
        <table class="table table-hover table-bordered">
        <thead>
            <tr>         
                <th onclick="">Product Id</th>
                <th onclick="">Price In Cents</th>
                <th onclick="">Title</th>
                <th onclick="">Description</th>
                <th onclick="">Discount Percentage</th>
                <th onclick="">Discount In Cents</th>
            </tr>
        </thead>
        
            <tbody>
                ${model.products.map(p => `
                    
                    <tr>                        
                        <td>${p.id}</td>
                        <td>${p.price_in_cents}</td>
                        <td>${p.title}</td>
                        <td>${p.description}</td>
                        <td>${parseFloat(p.discount.pct).toFixed(2)}%</td>
                        <td>${p.discount.value_in_cents}</td>
                    </tr>
                    
                `).join('')}                
            </tbody>
                  
            <tfoot>
                <td colspan="7"></td>
                
            </tfoot>
            
        </table>
        `;
    }
}
