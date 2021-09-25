using System.Threading.Tasks;
using Portal.API.Models;

namespace Portal.API.Data
{
    public interface IAuthRepository
    {
        Task<User> Login(string username, string password);
        Task<User> Register(string user, string password);
        Task<bool> UserExists(string username);
    }
}