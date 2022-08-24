using Microsoft.AspNetCore.Mvc;

namespace University.Controllers
{
    [Authorize(Roles = "Department")]
    public class LessonController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LessonController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Lesson lesson)
        {
            _db.Lessons.Add(lesson);
            _db.SaveChanges();
            return View();
        }
    }
}
