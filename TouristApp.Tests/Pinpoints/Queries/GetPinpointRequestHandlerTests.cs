using TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetPinPoint;
using TouristApp.Tests.Common;

namespace TouristApp.Tests.Pinpoints.Queries;

public class GetPinpointRequestHandlerTests : TestCommandBase {
    [Fact]
    public async Task GetPinpointRequestHandler_Success() {
        //Arrange
        var handler = new GetPinpointRequestHandler(_context);
        var name = "Pinpoint1";
        var description = "Description1";
        var audioUrl = string.Empty;
        var xCoordinate = 2.0m;
        var yCoordinate = 3.0m;
        
        //Act
        var handlerPinpoint = await handler.Handle(new GetPinpointRequest()
        {
            Id = TouristApplicationContextFactory.PinpointIdForGet
        }, CancellationToken.None);
        
        //Assert
        Assert.True(handlerPinpoint.Name == name && handlerPinpoint.Description == description &&
                    handlerPinpoint.AudioUrl == audioUrl && handlerPinpoint.XCoordinate == xCoordinate &&
                    handlerPinpoint.YCoordinate == yCoordinate);
        
    }
}