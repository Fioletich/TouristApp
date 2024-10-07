using System.ComponentModel.DataAnnotations.Schema;

namespace TouristApp.Domain.Models;

[Table("Routes")]
public class Route {
    [Column("Id")] public Guid Id { get; set; }
    [Column("Name")] public string Name { get; set; }
    [Column("Description")] public string Description { get; set; }
}