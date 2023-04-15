import { Product } from "../models/product";

export class ProductForm {

    public get addButton() {
        return cy.contains("button", /^Add$/);
    }

    public fill(product: Product): ProductForm {
        cy.get("#name").type(product.name);
        cy.get("#description").type(product.description);
        cy.get("#carbohydrates").type(`${product.carbohydrates}`);
        cy.get("#fats").type(`${product.fats}`);
        cy.get("#proteins").type(`${product.proteins}`);
        cy.get("#nutrition").type(`${product.nutrition}`);
        return this;
    }

    public clickAdd(): void {
        this.addButton.click();
    }
}