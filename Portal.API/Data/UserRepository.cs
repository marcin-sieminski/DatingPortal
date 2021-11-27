using Portal.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Portal.API.Data;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context) 
    {
        _context = context;
    }

    public async Task<User> GetUser(int id)
    {
        var user = await _context.Users.Include(prop => prop.Photos).SingleAsync(u => u.Id == id);
        return user;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        var users = await _context.Users.Include(prop => prop.Photos).ToListAsync();
        return users;
    }
}
