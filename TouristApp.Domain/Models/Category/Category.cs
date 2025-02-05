using TouristApp.Domain.Abstractions;

namespace TouristApp.Domain.Models.Category;

public class Category : AuditableEntity { 
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public string Description { get; set; }

    private Category() {
    }

    public static Category Create(string name, string description) {
        var category = new Category()
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description,
        };
        
        category.Update();
        
        return category;
    }
}