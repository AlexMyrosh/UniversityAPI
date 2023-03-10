namespace UniversityAPI.Models
{
    public class Exam
    {
        public int Id { get; set; }

        public double Mark { get; set; }

        public Student Student { get; set; }

        public int StudentId { get; set; }

        public Subject Subject { get; set; }

        public int SubjectId { get; set; }
    }
}