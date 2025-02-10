using MediatR;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.Category;
using TouristApp.Domain.Models.CategoryOfPinpoint;

namespace TouristApp.Application.RequestAndHandler.CategoriesOfPinpoints.Commands.CreateCategoryOfPinpoint;

public class CreateCategoryOfPinpointRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<CreateCategoryOfPinpointRequest, Guid> {
    public async Task<Guid> Handle(CreateCategoryOfPinpointRequest request, CancellationToken cancellationToken) {
        var category = CategoryOfPinpoint.Create(request.Name, request.Description);

        await context.CategoriesOfPinpoints.AddAsync(category, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return category.Id;
    }
}