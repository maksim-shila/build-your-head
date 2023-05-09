using BuildYourHead.Api.Controllers.Dish.Requests;
using BuildYourHead.Application.Services;
using Moq;

namespace BuildYourHead.Tests.Controllers.Dish.Requests
{
    public class GetDishesRequestHandlerTests
    {
        [Fact]
        public void Handle_NoArgs_CallsDishServiceGetAll()
        {
            // Arrange
            var dishServiceMock = new Mock<IDishService>();
            var handler = new GetDishesRequestHandler(dishServiceMock.Object);

            // Act
            handler.Handle();

            // Assert
            dishServiceMock.Verify(s => s.GetAll());
        }
    }
}
