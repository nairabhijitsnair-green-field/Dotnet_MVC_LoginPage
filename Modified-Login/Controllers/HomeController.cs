using Microsoft.AspNetCore.Mvc;

namespace LoginPage_with_Database_Final.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Dashboard()
        {
            var name = HttpContext.Session.GetString("UserName") 
                ?? Request.Cookies["UserName"];
            if (string.IsNullOrEmpty(name)) return RedirectToAction("Login", "Account");

            ViewBag.Name = name;
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
