using TouristApp.Domain.Abstractions;

namespace TouristApp.Domain.Models.CategoryOfPinpoint;

public class CategoryOfPinpoint : AuditableEntity { 
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public string Description { get; set; }

    private CategoryOfPinpoint() {
    }

    public static CategoryOfPinpoint Create(string name, string description) {
        var category = new CategoryOfPinpoint()
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description,
        };
        
        category.Update();
        
        return category;
    }
}