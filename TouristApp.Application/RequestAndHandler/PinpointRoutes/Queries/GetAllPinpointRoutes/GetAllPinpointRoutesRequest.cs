using MediatR;
using TouristApp.Domain.Models.PinpointRoute;

namespace TouristApp.Application.RequestAndHandler.PinpointRoutes.Queries.GetAllPinpointRoutes;

public record GetAllPinpointRoutesRequest() : IRequest<IEnumerable<PinpointRoute>>;