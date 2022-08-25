using Microsoft.AspNetCore.Mvc;

namespace University.Controllers
{
    [Authorize(Roles = "Dean")]
    public class DepartmentLessonListController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DepartmentLessonListController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            return View(_db.DepartmentLessons.Include(dl => dl.Department).Include(dl => dl.Lesson).ToList());
        }
    }
}
