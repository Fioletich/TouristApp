using MediatR;
using TouristApp.Domain.Models;

namespace TouristApp.Application.Categories.Queries.GetCategory;

public class GetCategoryRequest : IRequest<Category> {
    public Guid Id { get; set; }
}