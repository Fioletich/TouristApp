using TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetAllPinPoints;
using TouristApp.Tests.Common;

namespace TouristApp.Tests.Pinpoints.Queries;

public class GetAllPinpointsRequestHandlerTests : TestCommandBase {
    [Fact]
    public async Task GetAllPinpoints_Success() {
        //Arrange
        var handler = new GetAllPinpointsRequestHandler(_context);

        //Act
        var pinpoints = await handler.Handle(new GetAllPinpointsRequest(), CancellationToken.None);

        //Assert
        Assert.True(pinpoints.Count() == 4);
    }
}