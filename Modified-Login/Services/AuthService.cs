using Modified_Login.Interfaces;
using Modified_Login.Model;

namespace Modified_Login.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<(bool isValid, User? user)> ValidateLoginAsync(string email, string password)
        {
            var foundUser = await _userRepository.GetByEmailAndPasswordAsync(email, password);

            return (foundUser != null, foundUser);
        }

        public void SignIn(User user)
        {
            _httpContextAccessor.HttpContext?.Session.SetString("UserName", user.Username);
        }

        public void SignOut()
        {
            _httpContextAccessor.HttpContext?.Session.Clear();
        }
    }
}