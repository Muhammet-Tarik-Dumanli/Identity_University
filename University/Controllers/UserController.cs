using Microsoft.AspNetCore.Mvc;

namespace University.Controllers
{
    [Authorize(Roles = "StudentAffairs")]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {

            return View(_userManager.Users.ToList());
        }

        public async Task<IActionResult> Update(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.AddToRoleAsync(user, "Student");

            return View("Index", _userManager.Users.ToList());
        }
    }
}
