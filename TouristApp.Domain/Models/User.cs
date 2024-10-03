using System.ComponentModel.DataAnnotations.Schema;

namespace TouristApp.Domain.Models;

[Table("user")]
public class User {
    [Column("user_id")]
    public Guid UserId { get; set; }
    [Column("login")]
    public string? Login { get; set; }
    [Column("password")]
    public string? Password { get; set; }
}