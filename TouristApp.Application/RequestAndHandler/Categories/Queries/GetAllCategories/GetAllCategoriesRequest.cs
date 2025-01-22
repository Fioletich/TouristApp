using MediatR;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.Categories.Queries.GetAllCategories;

public class GetAllCategoriesRequest : IRequest<IEnumerable<Category>> {
    
}