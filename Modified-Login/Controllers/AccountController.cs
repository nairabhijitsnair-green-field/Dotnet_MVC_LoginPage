using Microsoft.AspNetCore.Mvc;
using Modified_Login.Interfaces;
using Modified_Login.Model;

namespace SOLIDProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public AccountController(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (!ModelState.IsValid) return View();

            _userRepository.Add(user);
            _userRepository.Save();
            return RedirectToAction("Login");
        }

        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var (isValid, user) = await _authService.ValidateLoginAsync(email, password);

            if (isValid)
            {
                _authService.SignIn(user!);
                return RedirectToAction("Dashboard", "Home");
            }

            ViewBag.Error = "Invalid credentials";
            return View();
        }

        public IActionResult Logout()
        {
            _authService.SignOut();
            return RedirectToAction("Login");
        }
    }
}