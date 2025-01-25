namespace TouristApp.Domain.Abstractions;

public abstract class AuditableEntity {
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; private set; }

    public void Update() {
        UpdatedAt = DateTime.Now;
    }
}