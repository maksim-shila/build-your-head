import { Dish } from "../../models/dish";
import { DishPage } from "../dish/dish-page";
import { DishForm } from "./dish-form";

export class DishesList {

    public readonly productForm: DishForm;

    constructor() {
        this.productForm = new DishForm();
    }

    public clickEdit(dish: Dish): DishForm {
        const row = new DishRow(dish.name);
        row.within(row => row.editBtn.click());
        return this.productForm;
    }

    public clickDelete(dish: Dish): DishesList {
        const row = new DishRow(dish.name);
        row.within(row => row.deleteBtn.click());
        return this;
    }

    public clickView(dish: Dish): DishPage {
        const row = new DishRow(dish.name);
        row.within(row => row.viewBtn.click());
        return new DishPage(dish);
    }

    public shouldHaveDish(dish: Dish): DishesList {
        cy.log(`Verify table has dish: ${dish.name}`);
        const row = new DishRow(dish.name);
        row.within(_ => cy.get("td.cell-description").should("have.text", dish.description));
        return this;
    }

    public shouldNotHaveDish(dish: Dish): DishesList {
        cy.log(`Verify table hasn't dish: ${dish.name}`);
        cy.contains(new RegExp(`^${dish.name}$`)).should("not.exist");
        return this;
    }
}

class DishRow {
    private name: string;

    constructor(name: string) {
        this.name = name;
    }

    public get editBtn() {
        return cy.contains("button", /^Edit$/);
    }

    public get deleteBtn() {
        return cy.contains("button", /^Delete$/);
    }

    public get viewBtn() {
        return cy.contains("button", /^View$/);
    }

    public within(action: (row: DishRow) => unknown) {
        this.row().within(_ => action(this));
    }

    private row() {
        return cy.contains("td", new RegExp(`^${this.name}$`)).parent("tr");
    }
}