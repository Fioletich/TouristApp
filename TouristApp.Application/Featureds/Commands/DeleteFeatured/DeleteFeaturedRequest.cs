using MediatR;

namespace TouristApp.Application.Featureds.Commands.DeleteFeatured;

public class DeleteFeaturedRequest : IRequest {
    public Guid Id { get; set; }
}