using System.ComponentModel.DataAnnotations.Schema;

namespace TouristApp.Domain.Models;

[Table("PinpointCategories")]
public class PinpointCategory {
    [Column("Id")] public Guid Id { get; set; }
    [Column("CategoryId")] public Guid CategoryId { get; set; }
    [Column("PinpointId")] public Guid PinpointId { get; set; }
}