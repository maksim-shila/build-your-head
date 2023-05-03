import { DishForm } from "./dish-form";
import { DishesList } from "./dishes-list";

export class DishesPage {

    public readonly dishForm: DishForm;
    public readonly dishesList: DishesList;

    constructor() {
        this.dishForm = new DishForm();
        this.dishesList = new DishesList();
    }

    public get addDishButton() {
        return cy.contains("button", /^Add Dish$/);
    }

    public open(): DishesPage {
        cy.visit("/dishes");
        return this;
    }

    public clickAddDish(): DishForm {
        this.addDishButton.click();
        return this.dishForm;
    }
}