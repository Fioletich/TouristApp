using MediatR;

namespace TouristApp.Application.PinpointsCategories.Commands.CreatePinpointCategory;

public class CreatePinpointCategoryRequest : IRequest<Guid> {
    public Guid CategoryId { get; set; }
    public Guid PinpointId { get; set; }
}