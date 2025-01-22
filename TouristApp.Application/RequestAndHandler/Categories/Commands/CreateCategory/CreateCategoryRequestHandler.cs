using MediatR;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.Categories.Commands.CreateCategory;

public class CreateCategoryRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<CreateCategoryRequest, Guid> {

    public async Task<Guid> Handle(CreateCategoryRequest request, CancellationToken cancellationToken) {
        var entity = new Category()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description
        };

        await context.Categories.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}