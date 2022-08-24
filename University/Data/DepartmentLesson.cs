namespace University.Data
{
    public class DepartmentLesson
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public int DepartmentId { get; set; }
        public Lesson Lesson { get; set; }
        public Department Department { get; set; }

    }
}
