using Authentication_api.Model;

namespace Authentication_api.Repository;

public interface IUserRepository
{
    User GetUserByEmail(string email);
    User GetUserById(int uid);
}
