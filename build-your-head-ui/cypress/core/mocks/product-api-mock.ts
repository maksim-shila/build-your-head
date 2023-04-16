import { Product } from "../models/product";

export class ProductApiMock {

    private autoincrementedId = 0;
    private products: Product[] = [];

    public setUp(): void {
        cy.intercept(
            { method: "GET", url: "/api/product" },
            (req) => req.reply(this.products)
        ).as("GET /product");

        cy.intercept(
            { method: "PUT", url: "/api/product" },
            (req) => {
                const product = { id: this.nextId(), ...req.body };
                this.products.push(product);
                req.reply(product);
            }
        ).as("PUT /product");
    }

    private nextId(): number {
        return ++this.autoincrementedId;
    }
}