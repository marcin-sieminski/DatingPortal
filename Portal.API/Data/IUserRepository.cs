using Portal.API.Models;

namespace Portal.API.Data;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUser(int id);
}
