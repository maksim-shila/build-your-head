import { Product } from "../models/product";

export class ProductForm {

    public get addButton() {
        return cy.contains("button", /^Add$/);
    }

    public get updateButton() {
        return cy.contains("button", /^Update$/);
    }

    public fill(product: Product): ProductForm {
        cy.get("#name").clear().type(product.name);
        cy.get("#description").clear().type(product.description);
        cy.get("#carbohydrates").invoke('val', '').clear().type(`${product.carbohydrates}`);
        cy.get("#fats").clear().invoke('val', '').type(`${product.fats}`);
        cy.get("#proteins").clear().invoke('val', '').type(`${product.proteins}`);
        cy.get("#nutrition").clear().invoke('val', '').type(`${product.nutrition}`);
        return this;
    }

    public clickAdd(): void {
        this.addButton.click();
    }

    public clickUpdate() {
        this.updateButton.click();
    }
}