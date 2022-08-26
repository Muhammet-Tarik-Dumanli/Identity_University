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
        public async Task<IActionResult> Index()
        {
            List<UserRole> userRoles = new List<UserRole>();
            List<IdentityUser> users = _userManager.Users.ToList();

            foreach (var item in users)
            {
                UserRole userRole = new UserRole();
                userRole.Name = item.UserName;
                userRole.Roles = (await _userManager.GetRolesAsync(item)).ToList();
                userRoles.Add(userRole);
            }

            ViewData["userManager"] = userRoles;
            return View(_userManager.Users.ToList());
        }

        public async Task<IActionResult> Update(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (!await _userManager.IsInRoleAsync(user, "Student"))
            {
                await _userManager.AddToRoleAsync(user, "Student");
                ViewData["Code"] = 1;
                ViewData["Message"] = "The student role has been assigned to the user!";
            }
            else
            {
                ViewData["Message"] = "The student role has already been assigned to the user!";
                ViewData["Code"] = 2;
            }

            List<UserRole> userRoles = new List<UserRole>();
            List<IdentityUser> users = _userManager.Users.ToList();

            foreach (var item in users)
            {
                UserRole userRole = new UserRole();
                userRole.Name = item.UserName;
                userRole.Roles = (await _userManager.GetRolesAsync(item)).ToList();
                userRoles.Add(userRole);
            }

            ViewData["userManager"] = userRoles;

            return View("Index", _userManager.Users.ToList());
        }
    }
}
