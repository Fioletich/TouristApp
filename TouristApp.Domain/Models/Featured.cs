using System.ComponentModel.DataAnnotations.Schema;

namespace TouristApp.Domain.Models;

[Table("featured")]
public class Featured {
    [Column("id")]
    public Guid Id { get; set; }
    [Column("touristroute_id")]
    public Guid TouristRouteId { get; set; }
    [Column("user_id")]
    public Guid UserId { get; set; }
}