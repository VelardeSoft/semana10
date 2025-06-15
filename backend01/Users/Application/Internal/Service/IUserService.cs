using backend01.Users.Domain.Model.Aggregate;

namespace backend01.Users.Application.Internal.Service;

public interface IUserService
{
    Task<User> AuthenticateAsync(string email, string password);
    string HashPassword(string password);
}