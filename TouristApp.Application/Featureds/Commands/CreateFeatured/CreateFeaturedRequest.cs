using MediatR;

namespace TouristApp.Application.Featureds.Commands.CreateFeatured;

public class CreateFeaturedRequest : IRequest<Guid> {
    public Guid TouristRouteId { get; set; }
    public Guid UserId { get; set; }
}