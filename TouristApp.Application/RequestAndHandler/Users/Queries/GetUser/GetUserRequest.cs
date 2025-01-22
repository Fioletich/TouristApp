using MediatR;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.Users.Queries.GetUser;

public class GetUserRequest : IRequest<User> {
    public Guid UserId { get; set; }
}