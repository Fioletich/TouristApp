using System.ComponentModel.DataAnnotations.Schema;

namespace TouristApp.Domain.Models;

[Table("pinpoints")]
public class PinPoint {
    [Column("id")] public Guid Id { get; set; }
    [Column("name")] public string? Name { get; set; }
    [Column("xcoordinate")] public decimal XCoordinate { get; set; }
    [Column("ycoordinate")] public decimal YCoordinate { get; set; }
}