using MediatR;
using TouristApp.Domain.Models;

namespace TouristApp.Application.Users.Queries.GetAllUsers;

public class GetAllUsersRequest : IRequest<IEnumerable<User>> {
    
}