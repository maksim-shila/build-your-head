using BuildYourHead.Api.Controllers.Dish.Requests;
using BuildYourHead.Api.Exceptions;
using BuildYourHead.Application.Dto;
using BuildYourHead.Application.Services;
using Moq;

namespace BuildYourHead.Tests.Controllers.Dish.Requests
{
    public class AddDishRequestHandlerTests
    {
        [Fact]
        public void Handle_ValidData_CallsDishServiceAdd()
        {
            // Arrange
            var dishServiceMock = new Mock<IDishService>();
            dishServiceMock
                .Setup(s => s.Add(It.IsAny<DishDto>(), It.IsAny<IList<int>>()))
                .Returns(It.IsAny<DishDto>());
            var handler = new AddDishRequestHandler(dishServiceMock.Object);

            // Act
            var request = new AddDishRequest
            {
                Name = "test name",
                Description = "test description",
                ProductIds = new List<int> { 1, 2 }
            };
            var result = handler.Handle(request);

            // Assert
            dishServiceMock.Verify(s => s.Add(
                It.Is<DishDto>(dishDto => dishDto.Name == request.Name && dishDto.Description == request.Description),
                request.ProductIds)
            );
        }

        [Fact]
        public void Handle_EmptyName_ThrowsValidationException()
        {
            // Arrange
            var dishServiceMock = new Mock<IDishService>();
            var handler = new AddDishRequestHandler(dishServiceMock.Object);

            // Act, Assert
            var request = new AddDishRequest { Name = null };
            Assert.Throws<ValidationException>(() => handler.Handle(request));
        }
    }
}
