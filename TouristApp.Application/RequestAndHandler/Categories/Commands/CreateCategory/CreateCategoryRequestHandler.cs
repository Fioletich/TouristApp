using MediatR;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.Category;

namespace TouristApp.Application.RequestAndHandler.Categories.Commands.CreateCategory;

public class CreateCategoryRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<CreateCategoryRequest, Guid> {
    public async Task<Guid> Handle(CreateCategoryRequest request, CancellationToken cancellationToken) {
        var category = Category.Create(request.Name, request.Description);

        await context.Categories.AddAsync(category, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return category.Id;
    }
}