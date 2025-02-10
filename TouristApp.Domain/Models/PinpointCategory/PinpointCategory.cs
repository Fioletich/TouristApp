using TouristApp.Domain.Abstractions;

namespace TouristApp.Domain.Models.PinpointCategory;

public class PinpointCategory : AuditableEntity {
    public Guid PinpointId { get; private set; }
    public Guid CategoryOfPinpointId { get; private set; }

    private PinpointCategory() { }

    public static PinpointCategory Create(Guid categoryOfPinpointId, Guid pinpointId) {
        var pinpointCategory = new PinpointCategory()
        {
            PinpointId = pinpointId,
            CategoryOfPinpointId = categoryOfPinpointId
        };
        
        pinpointCategory.Update();
        
        return pinpointCategory;
    }
}