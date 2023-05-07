import { Dish } from "../models/dish";

export class DishApiMock {

    private autoincrementedId = 0;
    private dishes: Dish[] = [];

    public setUp(): void {
        cy.intercept(
            { method: "GET", url: "/api/dish" },
            (req) => req.reply(this.dishes)
        ).as("GET /dish");

        cy.intercept(
            { method: "GET", url: "/api/dish/*" },
            (req) => {
                const id = Number(req.url.split("/").pop());
                const dish = this.dishes.find(p => p.id === id);
                req.reply(dish);
            }
        ).as("GET /dish/{id}");

        cy.intercept(
            { method: "PUT", url: "/api/dish" },
            (req) => {
                const dish = this.addDish({ ...req.body });
                req.reply(dish);
            }
        ).as("PUT /dish");

        cy.intercept(
            { method: "POST", url: "/api/dish/*" },
            (req) => {
                const id = Number(req.url.split("/").pop());
                const dish = { id, ...req.body };
                const existing = this.dishes.find(p => p.id === dish.id);
                const index = this.dishes.indexOf(existing);
                this.dishes[index] = dish;
                req.reply(dish);
            }
        ).as("POST /dish/{id}");

        cy.intercept(
            { method: "DELETE", url: "/api/dish/*" },
            (req) => {
                const id = Number(req.url.split("/").pop());
                this.dishes = this.dishes.filter(p => p.id !== id);
                req.reply("");
            }
        ).as("DELETE /dish/{id}");
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