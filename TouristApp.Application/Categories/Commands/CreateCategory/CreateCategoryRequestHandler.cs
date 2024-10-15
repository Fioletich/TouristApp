using MediatR;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.Categories.Commands.CreateCategory;

public class CreateCategoryRequestHandler : IRequestHandler<CreateCategoryRequest, Guid> {
    private readonly ITouristApplicationDbContext _context;
    
    public CreateCategoryRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }

    public async Task<Guid> Handle(CreateCategoryRequest request, CancellationToken cancellationToken) {
        var entity = new Category()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description
        };

        await _context.Categories.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}