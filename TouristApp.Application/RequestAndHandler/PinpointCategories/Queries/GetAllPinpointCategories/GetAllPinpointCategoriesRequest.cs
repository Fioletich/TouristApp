using MediatR;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.PinpointCategories.Queries.GetAllPinpointCategories;

public class GetAllPinpointCategoriesRequest : IRequest<IEnumerable<PinpointCategory>>{
    
}