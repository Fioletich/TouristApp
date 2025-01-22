using MediatR;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.Categories.Queries.GetCategory;

public class GetCategoryRequest : IRequest<Category> {
    public Guid Id { get; set; }
}