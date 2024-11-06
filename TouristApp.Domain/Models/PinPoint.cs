using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TouristApp.Domain.Models;

[Table("Pinpoints")]
public class PinPoint {
    [Column("Id")] public Guid Id { get; set; }
    [Column("Name")] public string? Name { get; set; }
    [Column("Description")] public string? Description { get; set; }
    
    [Column("XCoordinate")][DisplayFormat(DataFormatString = "{0:0.000000}", ApplyFormatInEditMode = true)] 
    public decimal XCoordinate { get; set; }
    [Column("YCoordinate")] [DisplayFormat(DataFormatString = "{0:0.000000}", ApplyFormatInEditMode = true)] 
    public decimal YCoordinate { get; set; }
}