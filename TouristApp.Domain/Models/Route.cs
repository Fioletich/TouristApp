using System.ComponentModel.DataAnnotations.Schema;

namespace TouristApp.Domain.Models;

[Table("routes")]
public class Route {
    [Column("id")] public Guid Id { get; set; }
    [Column("name")] public string Name { get; set; }
    [Column("description")] public string Description { get; set; }
}