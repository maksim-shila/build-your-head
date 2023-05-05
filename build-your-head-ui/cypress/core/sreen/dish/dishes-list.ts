import { Dish } from "../../models/dish";
import { DishForm } from "./dish-form";

export class DishesList {

    public readonly productForm: DishForm;

    constructor() {
        this.productForm = new DishForm();
    }

    public clickEdit(dish: Dish): DishForm {
        this.row(dish.name).within(_ => {
            cy.contains("button", /^Edit$/).click();
        });

        return this.productForm;
    }

    public clickDelete(dish: Dish) {
        this.row(dish.name).within(_ => {
            cy.contains("button", /^Delete$/).click();
        });
    }

    public shouldHaveDish(dish: Dish): DishesList {
        cy.log(`Verify table has dish: ${dish.name}`);
        this.row(dish.name).within(_ => {
            cy.get("td.cell-description").should("have.text", dish.description);
        });

        return this;
    }

    public shouldNotHaveDish(dish: Dish): DishesList {
        cy.log(`Verify table hasn't dish: ${dish.name}`);
        cy.contains(new RegExp(`^${dish.name}$`)).should("not.exist");
        return this;
    }

    private row(dishName: string) {
        return cy.contains("td", new RegExp(`^${dishName}$`)).parent("tr");
    }
}