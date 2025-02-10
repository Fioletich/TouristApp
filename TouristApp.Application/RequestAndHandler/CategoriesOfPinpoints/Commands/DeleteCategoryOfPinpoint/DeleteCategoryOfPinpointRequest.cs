using MediatR;

namespace TouristApp.Application.RequestAndHandler.CategoriesOfPinpoints.Commands.DeleteCategoryOfPinpoint;

public record DeleteCategoryOfPinpointRequest(Guid Id) : IRequest;