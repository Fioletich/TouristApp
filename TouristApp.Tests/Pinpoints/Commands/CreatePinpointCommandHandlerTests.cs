using Microsoft.EntityFrameworkCore;
using TouristApp.Application.RequestAndHandler.Pinpoints.Commands.CreatePinpoint;
using TouristApp.Tests.Common;

namespace TouristApp.Tests.Pinpoints.Commands;

public class CreatePinpointCommandHandlerTests : TestCommandBase {
    [Fact]
    public async Task CreatePinpointCommandHandler_Success() {
        //Arrange
        var handler = new CreatePinpointRequestHandler(_context);
        var name = "pinpoint1";
        var description = "description1";
        var audioUrl = "audioUrl1";
        var xCoordinate = 1.0m;
        var yCoordinate = 2.0m;
        
        //Act
        var pinpointId = await handler.Handle(new CreatePinpointRequest()
        {
            Name = name,
            Description = description,
            AudioUrl = audioUrl,
            XCoordinate = xCoordinate,
            YCoordinate = yCoordinate
        }, CancellationToken.None);
        
        //Assert
        Assert.NotNull(_context.Pinpoints.SingleOrDefaultAsync(p => 
            p.Id == pinpointId && p.Name == name && p.Description == description && p.AudioUrl == audioUrl 
            && p.XCoordinate == xCoordinate && p.YCoordinate == yCoordinate));
    }
}