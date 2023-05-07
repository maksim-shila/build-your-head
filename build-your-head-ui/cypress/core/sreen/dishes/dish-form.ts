import { Dish } from "../../models/dish";

export class DishForm {

    public get nameInput() {
        return cy.get("#name");
    }

    public get descriptionTextArea() {
        return cy.get("#description");
    }

    public get addButton() {
        return cy.contains("button", /^Add$/);
    }

    public get updateButton() {
        return cy.contains("button", /^Update$/);
    }

    public clickAdd(): DishForm {
        this.addButton.click();
        return this;
    }

    public clickUpdate(): DishForm {
        this.updateButton.click();
        return this;
    }

    public fill(dish: Dish): DishForm {
        this.nameInput.clear().type(dish.name);
        this.descriptionTextArea.clear().type(dish.description);
        return this;
    }

    public shouldBePrepopulated(dish: Dish): DishForm {
        this.nameInput.should("have.value", dish.name);
        this.descriptionTextArea.should("have.value", dish.description);
        return this;
    }

    public shouldBeClosed(): void {
        cy.get("#dishModal").should("not.exist");
    }
}

class DishFormControls {

}