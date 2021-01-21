context('Adding to inventory', ()=>{
    beforeEach(()=>{
        cy.intercept('GET','http://localhost:8080/inventory').as('getInventory')
        cy.intercept('PATCH','http://localhost:8080/inventory').as('updateInventory')

        cy.visit('http://localhost:4200');
        cy.wait(['@getInventory'])
    })
    it('CheeseAmount_ShouldBeZero', () => {
        cy.get('#cheese > .card > .card-body .card-title')
            .contains('cheese')
        cy.get('#cheese > .card > .card-body .card-text')
            .contains('0')
    })
    it('CheeseAmount_AddFive_ShouldBeFive', () => {
        cy.get('#cheese > .card > .card-body .amount-selector')
            .type('5')
        cy.get('#cheese > .card > .card-body button')
            .click()
        cy.wait(['@updateInventory','@getInventory'])
        cy.get('#cheese > .card > .card-body .card-text')
            .contains('5')
    })
    it('AddToAll_AllShouldIncreaseByTen', () => {
        cy.get('app-mass-delivery > .card > .card-body > button')
            .click()
        
        cy.wait(['@updateInventory','@getInventory'])

        cy.get('#cheese > .card > .card-body .card-text')
            .contains('15')
        cy.get('#cilantro > .card > .card-body .card-text')
            .contains('10')
        cy.get('#kebab > .card > .card-body .card-text')
            .contains('10')
        cy.get('#tomato > .card > .card-body .card-text')
            .contains('10')
        cy.get('#clam > .card > .card-body .card-text')
            .contains('10')
        cy.get('#mushrooms > .card > .card-body .card-text')
            .contains('10')
        cy.get('#onion > .card > .card-body .card-text')
            .contains('10')            
    });
});

context('Proccessing order', ()=>{
    beforeEach(()=>{
        cy.intercept('GET','http://localhost:8080/inventory').as('getInventory')

        cy.visit('http://localhost:4200');
        cy.wait(['@getInventory'])
    })
    it('AddToCart_ShouldRespondWith200', () => {
        cy.request(
            'POST',
            'http://localhost:13337/api/cart',
            {
                "pizzas":[{
                        "id": 1,
                        "extraIngredients": [1, 3]
                    }],
                "drinks": [1]
            }
        ).then(response =>{
            expect(response.status).to.eq(200)
        })
    })
    it('SaveOrder_IngredientsInStock_ShouldRespondWith200', () => {
        cy.request(
            'POST',
            'http://localhost:13337/api/order'
        ).then(response =>{
            expect(response.status).to.eq(200)
        })
    })
    it('RefreshPage_NewAmountsShouldReflectInventory', () => {
        cy.visit('http://localhost:4200');
        cy.wait(['@getInventory'])

        cy.get('#cheese > .card > .card-body .card-text')
            .contains('14')
        cy.get('#ham > .card > .card-body .card-text')
            .contains('9')
        cy.get('#tomatosauce > .card > .card-body .card-text')
            .contains('9')
        cy.get('#mushrooms > .card > .card-body .card-text')
            .contains('9')
    })
});