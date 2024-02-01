using Authentication_api.Model;

namespace Authentication_api.Repository;

public class UserRepository : IUserRepository
{
    public List<User> users = new()
    {
        new User { Uid = 1, Email = "user1@gmail.com", Pwd = "user1mdp", Role = "Admin"},
        new User { Uid = 2, Email = "user2@gmail.com", Pwd = "user2mdp", Role = "User" }
    };
    public User GetUserByEmail(string email)
    {
        var user = users.FirstOrDefault(u => u.Email == email);
        return user;
    }

    public User GetUserById(int uid)
    {
        var user = users.FirstOrDefault(u => u.Uid == uid);
        return user;
    }

}
