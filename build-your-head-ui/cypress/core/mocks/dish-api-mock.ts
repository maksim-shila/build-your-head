import { Dish } from "../models/dish";

export class DishApiMock {

    private autoincrementedId = 0;
    private dishes: Dish[] = [];

    public setUp(): void {
        cy.intercept(
            { method: "GET", url: "/api/dish" },
            (req) => req.reply(this.dishes)
        ).as("GET /product");

        cy.intercept(
            { method: "PUT", url: "/api/dish" },
            (req) => {
                const dish = this.addDish({ ...req.body });
                req.reply(dish);
            }
        ).as("PUT /product");

        cy.intercept(
            { method: "POST", url: "/api/dish/*" },
            (req) => {
                const id = Number(req.url.split("/").pop());
                const product = { id, ...req.body };
                const existing = this.dishes.find(p => p.id === product.id);
                const index = this.dishes.indexOf(existing);
                this.dishes[index] = product;
                req.reply(product);
            }
        ).as("POST /product/{id}");

        cy.intercept(
            { method: "DELETE", url: "/api/dish/*" },
            (req) => {
                const id = Number(req.url.split("/").pop());
                this.dishes = this.dishes.filter(p => p.id !== id);
                req.reply("");
            }
        ).as("DELETE /product/{id}");
    }

    public addDish(dish: Dish): Dish {
        const created = { id: this.nextId(), ...dish };
        this.dishes.push(created);
        return created;
    }

    private nextId(): number {
        return ++this.autoincrementedId;
    }
}