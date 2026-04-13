using Modified_Login.Model;

namespace Modified_Login.Interfaces
{
    public interface IAuthService
    {
        Task<(bool isValid, User? user)> ValidateLoginAsync(string email, string password);
        void SignIn(User user);
        void SignOut();
    }
}