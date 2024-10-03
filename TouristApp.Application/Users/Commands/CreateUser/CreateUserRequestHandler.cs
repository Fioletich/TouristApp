using MediatR;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.Users.Commands.CreateUser;

public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, Guid> {
    private readonly ITouristApplicationDbContext _context;

    public CreateUserRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }

    public async Task<Guid> Handle(CreateUserRequest request, CancellationToken cancellationToken) {
        var user = new User
        {
            UserId = Guid.NewGuid(),
            Login = request.Login,
            Password = request.Password
        };

        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return user.UserId;
    }
}