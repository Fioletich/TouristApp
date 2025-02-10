using TouristApp.Domain.Abstractions;

namespace TouristApp.Domain.Models.CategoryOfRoute;

public class CategoryOfRoute : AuditableEntity {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    private CategoryOfRoute() { }

    public static CategoryOfRoute Create(string name, string description) {
        var categoryOfRoute = new CategoryOfRoute()
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description
        };
        
        categoryOfRoute.Update();
        
        return categoryOfRoute;
    }
}