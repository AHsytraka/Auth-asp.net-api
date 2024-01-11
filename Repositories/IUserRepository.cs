using Auth_Jwt.Models;

namespace Auth_Jwt.Repositories;

public interface IUserRepository
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<User> GetAll();
    User GetById(int id);
}
