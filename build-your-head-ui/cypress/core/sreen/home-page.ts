import { ProductForm } from "./product-form";
import { ProductsList } from "./products-list";

export class HomePage {

    public readonly productForm: ProductForm;
    public readonly productsList: ProductsList;

    constructor() {
        this.productForm = new ProductForm()
        this.productsList = new ProductsList();
    }

    public get addProductButton() {
        return cy.contains("button", /^Add Product$/);
    }

    public open(): HomePage {
        cy.visit("/");
        return this;
    }

    public clickAddProduct(): ProductForm {
        this.addProductButton.click();
        return this.productForm;
    }
}