import { Product } from "../models/product";

export class ProductsList {

    public shouldHaveProduct(product: Product): void {
        cy.log("Verify table has product");
        this.row(product.name).within(_ => {
            cy.get("td.cell-description").should("have.text", product.description);
            cy.get("td.cell-carbohydrates").should("have.text", product.carbohydrates);
            cy.get("td.cell-proteins").should("have.text", product.proteins);
            cy.get("td.cell-fats").should("have.text", product.fats);
            cy.get("td.cell-nutrition").should("have.text", product.nutrition);
        })
    }

    private row(productName: string) {
        return cy.contains("td", new RegExp(`^${productName}$`)).parent("tr");
    }
}