using TouristApp.Application.Exceptions;
using TouristApp.Application.RequestAndHandler.Pinpoints.Commands.DeletePinpoint;
using TouristApp.Tests.Common;

namespace TouristApp.Tests.Pinpoints.Commands;

public class DeletePinpointCommandHandlerTests : TestCommandBase {
    [Fact]
    public async Task DeletePinpointCommandHandler_Success() {
        //Arrange
        var handler = new DeletePinpointRequestHandler(_context);
        //Act
        await handler.Handle(new DeletePinpointRequest()
        {
            Id = TouristApplicationContextFactory.PinpointIdForDelete
        }, CancellationToken.None);

        //Assert
        Assert.Null(_context.Pinpoints.SingleOrDefault(p =>
            p.Id == TouristApplicationContextFactory.PinpointIdForDelete));
    }

    [Fact]
    public async Task DeletePinpointCommandHandler_FailureOnWrongId() {
        //Arrange
        var handler = new DeletePinpointRequestHandler(_context);
        
        //Act
        
        //Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
        {
            await handler.Handle(new DeletePinpointRequest()
            {
                Id = Guid.NewGuid()
            }, CancellationToken.None);
        });
    }
}