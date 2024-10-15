using MediatR;
using TouristApp.Domain.Models;

namespace TouristApp.Application.Categories.Queries.GetAllCategories;

public class GetAllCategoriesRequest : IRequest<IEnumerable<Category>> {
    
}