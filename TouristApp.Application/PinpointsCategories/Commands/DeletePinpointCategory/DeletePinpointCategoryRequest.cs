using MediatR;

namespace TouristApp.Application.PinpointsCategories.Commands.DeletePinpointCategory;

public class DeletePinpointCategoryRequest : IRequest{
    public Guid Id { get; set; }
}