using Modified_Login.Interfaces;
using Modified_Login.Model;
using Modified_Login.Data;
using Microsoft.EntityFrameworkCore;

namespace Modified_Login.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAndPasswordAsync(string email, string password)
        {
            return await _context.Users
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
