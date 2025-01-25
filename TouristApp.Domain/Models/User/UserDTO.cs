namespace TouristApp.Domain.Models.User;

public record UserDTO(Guid Id, Guid RoleId, string Login, string Password, string? City);