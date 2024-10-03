using MediatR;
using TouristApp.Domain.Models;

namespace TouristApp.Application.Featureds.Queries.GetAllFeatereds;

public class GetAllFeateredsRequest : IRequest<IEnumerable<Featured>> {
    
}