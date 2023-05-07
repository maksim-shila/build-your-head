import { Dish } from "../../models/dish";

export class DishPage {

    private dish: Dish;

    constructor(dish: Dish) {
        this.dish = dish;
    }

    public shouldBeOpened(): DishPage {
        cy.url().should("contain", "/dish/");
        cy.contains(this.dish.name).should("be.visible");
        return this;
    }
}