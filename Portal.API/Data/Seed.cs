using Portal.API.Models;
using System.Text;

namespace Portal.API.Data;

public class Seed
{
    private readonly DataContext _context;

    public Seed(DataContext context)
    {
        _context = context;
    }

    public void SeedDatabase()
    {
        if (!_context.Users.Any())
        {
            SeedUsers();
        }

    }

    private void SeedUsers()
    {
        var users = new List<User>()
        {
            new User() { Username = "Ala" },
            new User() { Username = "Adam" }
        };

        foreach (var user in users)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHashSaltForSeed("password", out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Username = user.Username.ToLower();

            _context.Users.Add(user);
        }

        _context.SaveChanges();
    }

    private void CreatePasswordHashSaltForSeed(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}

