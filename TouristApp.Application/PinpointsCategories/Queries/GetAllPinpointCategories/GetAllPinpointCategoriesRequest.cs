using MediatR;
using TouristApp.Domain.Models;

namespace TouristApp.Application.PinpointsCategories.Queries.GetAllPinpointCategories;

public class GetAllPinpointCategoriesRequest : IRequest<IEnumerable<PinpointCategory>>{
    
}