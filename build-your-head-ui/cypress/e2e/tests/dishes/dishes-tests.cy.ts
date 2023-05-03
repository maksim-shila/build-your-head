import { DishApiMock } from "../../../core/mocks/dish-api-mock";
import { Dish } from "../../../core/models/dish";
import { DishesPage } from "../../../core/sreen/dish/dishes-page";
import { Guid } from "../../../core/utils/guid";

describe("Dishes Create/Update/Delete", () => {

    const dishesPage = new DishesPage();
    const dishesApi = new DishApiMock();

    beforeEach("Mock Dishes API", () => {
        dishesApi.setUp();
    });

    it("Add dish -> new dish created", () => {
        // Arrange
        const dish: Dish = {
            name: Guid.next(),
            description: "New Description"
        };

        // Act
        dishesPage
            .open()
            .clickAddDish()
            .fill(dish)
            .clickAdd()
            .shouldBeClosed();

        // Assert
        dishesPage.dishesList.shouldHaveDish(dish);
    });

    it("Edit dish -> dish info changed", () => {
        // Arrange
        const productName = Guid.next();
        const dish: Dish = {
            name: productName,
            description: "New Description"
        };
        const updatedDish: Dish = {
            name: productName + " Updated",
            description: "Updated Description"
        }
        dishesApi.addDish(dish);

        // Act
        dishesPage
            .open()
            .dishesList
            .clickEdit(dish)
            .shouldBePrepopulated(dish)
            .fill(updatedDish)
            .clickUpdate()
            .shouldBeClosed();

        // Assert
        dishesPage.dishesList.shouldHaveDish(updatedDish);
        dishesPage.dishesList.shouldNotHaveDish(dish);
    });

    it("Delete dish -> dish removed from list", () => {
        // Arrange
        const dish: Dish = {
            name: Guid.next(),
            description: "New Description"
        };
        dishesApi.addDish(dish);

        // Act
        dishesPage
            .open()
            .dishesList
            .clickDelete(dish);

        // Assert
        dishesPage.dishesList.shouldNotHaveDish(dish);
    })
})