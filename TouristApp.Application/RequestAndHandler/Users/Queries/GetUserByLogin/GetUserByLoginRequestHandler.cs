using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.User;

namespace TouristApp.Application.RequestAndHandler.Users.Queries.GetUserByLogin;

public class GetUserByLoginRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<GetUserByLoginRequest, User> {

    public async Task<User> Handle(GetUserByLoginRequest request, CancellationToken cancellationToken) {
        var users = context.Users
            .Include(u => u.Role);
        
        var user = await users.FirstOrDefaultAsync(u => u.Login == request.Login, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException("User", request.Login);
        }
        
        return user;
    }
}