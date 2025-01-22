using TouristApp.Application.Exceptions;
using TouristApp.Application.RequestAndHandler.Pinpoints.Commands.UpdatePinpoint;
using TouristApp.Tests.Common;

namespace TouristApp.Tests.Pinpoints.Commands;

public class UpdatePinpointCommandHandlerTests : TestCommandBase {
    [Fact]
    public async Task UpdatesPinpoint_Success() {
        //Arrange
        var handler = new UpdatePinpointRequestHandler(_context);
        var name = "pinpoint1";
        var description = "description1";
        var audioUrl = "audioUrl1";
        var xCoordinate = 1.0m;
        var yCoordinate = 2.0m;

        //Act
        await handler.Handle(new UpdatePinpointRequest()
        {
            Id = TouristApplicationContextFactory.PinpointIdForUpdate,
            Name = name,
            Description = description,
            AudioUrl = audioUrl,
            XCoordinate = xCoordinate,
            YCoordinate = yCoordinate
        }, CancellationToken.None);

        //Assert
        Assert.NotNull(_context.Pinpoints.Single(p => 
            p.Id == TouristApplicationContextFactory.PinpointIdForUpdate && p.Name == name &&
            p.Description == description && p.AudioUrl == audioUrl && p.XCoordinate == xCoordinate && 
            p.YCoordinate == yCoordinate));
    }

    [Fact]
    public async Task UpdatesPinpoint_FailureOnWrongId() {
        //Arrange
        var handler = new UpdatePinpointRequestHandler(_context);
        
        //Act
        
        
        //Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
        {
            await handler.Handle(new UpdatePinpointRequest()
            {
                Id = Guid.NewGuid()
            }, CancellationToken.None);
        });
    }
}