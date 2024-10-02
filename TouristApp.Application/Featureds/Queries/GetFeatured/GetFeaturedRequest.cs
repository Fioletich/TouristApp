using MediatR;
using TouristApp.Domain.Models;

namespace TouristApp.Application.Featureds.Queries.GetFeatured;

public class GetFeaturedRequest : IRequest<Featured> {
    public Guid Id { get; set; }
}