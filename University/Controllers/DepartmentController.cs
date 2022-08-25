using Microsoft.AspNetCore.Mvc;

namespace University.Controllers
{
    [Authorize(Roles = "StudentAffairs")]
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DepartmentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Department department)
        {
            _db.Departments.Add(department);
            _db.SaveChanges();
            return View();
        }
    }
}
