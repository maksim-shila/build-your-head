import { ProductApiMock } from "../../../core/mocks/product-api-mock";
import { Product } from "../../../core/models/product";
import { HomePage } from "../../../core/sreen/home-page";
import { Guid } from "../../../core/utils/guid";

describe("Products manipulations", () => {

    const homePage = new HomePage();
    const productApi = new ProductApiMock();

    beforeEach("Mock Products API", () => {
        productApi.setUp();
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

    it("User edit product -> product info changed", () => {
        // Arrange
        const productName = Guid.next();
        const product: Product = {
            name: productName,
            description: "New Description",
            carbohydrates: 1,
            fats: 2,
            proteins: 3,
            nutrition: 4
        };
        const updatedProduct: Product = {
            name: productName + " Updated",
            description: "Updated Description",
            carbohydrates: 2,
            fats: 3,
            proteins: 4,
            nutrition: 5
        }
        productApi.addProduct(product);

        // Act
        homePage
            .open()
            .productsList
            .clickEdit(product)
            .fill(updatedProduct)
            .clickUpdate();

        // Assert
        homePage.productsList.shouldHaveProduct(updatedProduct);
        homePage.productsList.shouldNotHaveProduct(product);
    });
})