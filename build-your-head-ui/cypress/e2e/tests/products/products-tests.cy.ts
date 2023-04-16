// Sometimes import of cy, describe and other things from cypress not accepted by VSCode, so added this hack
// eslint-disable-next-line @typescript-eslint/no-unused-vars
import * as _ from "cypress";

import { ProductApiMock } from "../../../core/mocks/product-api-mock";
import { Product } from "../../../core/models/product";
import { HomePage } from "../../../core/sreen/home-page";
import { Guid } from "../../../core/utils/guid";

describe("Products manipulations", () => {

    const homePage = new HomePage();

    before("Mock Products API", () => {
        new ProductApiMock().setUp();
    });

    it("User adds product -> new product created", () => {
        // Arrange
        const product: Product = {
            name: Guid.next(),
            description: "New Description",
            carbohydrates: 1,
            fats: 2,
            proteins: 3,
            nutrition: 4
        };

        // Act
        homePage
            .open()
            .clickAddProduct()
            .fill(product)
            .clickAdd();

        // Assert
        homePage.productsList.shouldHaveProduct(product);
    });
})