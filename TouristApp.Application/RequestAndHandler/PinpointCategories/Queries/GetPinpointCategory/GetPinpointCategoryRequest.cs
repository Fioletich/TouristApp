using MediatR;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.PinpointCategories.Queries.GetPinpointCategory;

public class GetPinpointCategoryRequest : IRequest<PinpointCategory> {
    public Guid Id { get; set; }
}