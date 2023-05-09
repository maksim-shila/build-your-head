using BuildYourHead.Api.Controllers.Dish.Requests;
using BuildYourHead.Api.Exceptions;
using BuildYourHead.Application.Services;
using Moq;

namespace BuildYourHead.Tests.Controllers.Dish.Requests
{
    public class DeleteDishRequestHandlerTests
    {
        [Fact]
        public void Handle_ValidId_CallsDishServiceDelete()
        {
            // Arrange
            var dishServiceMock = new Mock<IDishService>();
            dishServiceMock.Setup(s => s.Delete(It.IsAny<int>()));
            var handler = new DeleteDishRequestHandler(dishServiceMock.Object);

            // Act
            const int id = 2;
            handler.Handle(id);

            // Assert
            dishServiceMock.Verify(s => s.Delete(id));
        }

        [Fact]
        public void Handle_NegativeId_ThrowsValidationException()
        {
            // Arrange
            var dishServiceMock = new Mock<IDishService>();
            var handler = new DeleteDishRequestHandler(dishServiceMock.Object);

            // Act, Assert
            const int id = -1;
            Assert.Throws<ValidationException>(() => handler.Handle(id));
        }

        [Fact]
        public void Handle_ZeroId_ThrowsValidationException()
        {
            // Arrange
            var dishServiceMock = new Mock<IDishService>();
            var handler = new DeleteDishRequestHandler(dishServiceMock.Object);

            // Act, Assert
            const int id = 0;
            Assert.Throws<ValidationException>(() => handler.Handle(id));
        }
    }
}
