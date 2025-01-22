using MediatR;

namespace TouristApp.Application.RequestAndHandler.PinpointCategories.Commands.DeletePinpointCategory;

public class DeletePinpointCategoryRequest : IRequest{
    public Guid Id { get; set; }
}