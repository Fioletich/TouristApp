using MediatR;
using TouristApp.Domain.Models.PinpointCategory;

namespace TouristApp.Application.RequestAndHandler.PinpointsCategories.Queries.GetAllPinpointCategories;

public record GetAllPinpointCategoriesRequest : IRequest<IEnumerable<PinpointCategory>>;