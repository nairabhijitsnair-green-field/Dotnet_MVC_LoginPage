using Modified_Login.Model;

namespace Modified_Login.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAndPasswordAsync(string email, string password);
        void Add(User user);
        void Save();
    }
}
