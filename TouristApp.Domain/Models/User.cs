using System.ComponentModel.DataAnnotations.Schema;

namespace TouristApp.Domain.Models;

[Table("Users")]
public class User {
    [Column("Id")] public Guid Id { get; set; }
    [Column("Login")] public string Login { get; set; }
    [Column("Password")] public string Password { get; set; }
    [Column("PhoneNumber")] public string? PhoneNumber { get; set; }
    [Column("Bio")] public string? Bio { get; set; }
    [Column("Country")] public string? Country { get; set; }
    [Column("City")] public string? City { get; set; }
}