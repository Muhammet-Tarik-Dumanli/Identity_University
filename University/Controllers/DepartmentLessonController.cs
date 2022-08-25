using Microsoft.AspNetCore.Mvc;

namespace University.Controllers
{
    [Authorize(Roles = "StudentAffairs")]
    public class DepartmentLessonController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DepartmentLessonController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            ViewBag.Lessons = _db.Lessons.ToList();
            ViewBag.Departments = _db.Departments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Index(DepartmentLesson departmentLesson)
        {
            if (_db.DepartmentLessons.Where(dl => dl.DepartmentId == departmentLesson.DepartmentId && dl.LessonId == departmentLesson.LessonId).Count() > 0)
                return View("Error_DepartmentLesson");

            _db.DepartmentLessons.Add(departmentLesson);
            _db.SaveChanges();
            ViewBag.Lessons = _db.Lessons.ToList();
            ViewBag.Departments = _db.Departments.ToList();
            return RedirectToAction("Index", "DepartmentLesson");
        }

        public IActionResult Error_DepartmentLesson()
        {
            return View();
        }
    }
}
