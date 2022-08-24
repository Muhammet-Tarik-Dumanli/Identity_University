
namespace University.Data
{
    public class Lesson
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        [Range(0, 10)]
        public int Credit { get; set; }

        [Required]
        [Range(0, 30)]
        public int Ects { get; set; }
        public List<DepartmentLesson> DepartmentLessons { get; set; }

    }
}
