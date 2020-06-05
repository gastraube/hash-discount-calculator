db.Products.insertMany([
    {           
        Description : "Copo Plástico, vermelho, 200ml.",
        PriceCents : 10,
        Title : "Copo Plástico"
    },
    {
        Description : "iPhone 11 Pro Max novo na caixa.",
        PriceCents : 1000,
        Title : "iPhone 11"
    }
    ,
    {
        Description : "Relógio de pulso, preto.",
        PriceCents : 150,
        Title : "Relógio"
    }
    ,
    {
        Description : "Monitor LED 30 polegadas.",
        PriceCents : 3000,
        Title : "Monitor LED"
    }
     ,
    {
        Description : "Tênis de corrida, preto, Nike.",
        PriceCents : 3000,
        Title : "Monitor LED"
    }
])

db.Users.insertMany([
    {                  
        FirstName : "Joao",
        LastName : "Carlos",
        BirthDate: ISODate('1993-06-18')
    },
    {
        FirstName : "Ana",
        LastName : "Claudia",
        BirthDate: ISODate('1989-11-25')
    }
    ,
    {
         FirstName : "Maria",
        LastName : "Luiza",
        BirthDate: ISODate('1997-01-15')
    }
])