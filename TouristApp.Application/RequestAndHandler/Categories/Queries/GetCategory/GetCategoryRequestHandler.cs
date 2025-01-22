using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.Categories.Queries.GetCategory;

public class GetCategoryRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<GetCategoryRequest, Category> {

    public async Task<Category> Handle(GetCategoryRequest request, CancellationToken cancellationToken) {
        var entity = await context.Categories
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        if (entity is null && entity.Id != request.Id)
        {
            throw new NotFoundException(nameof(Category), request.Id);
        }

        return entity;
    }
}