using MediatR;
using TouristApp.Domain.Models;

namespace TouristApp.Application.PinpointsCategories.Queries.GetPinpointCategory;

public class GetPinpointCategoryRequest : IRequest<PinpointCategory> {
    public Guid Id { get; set; }
}