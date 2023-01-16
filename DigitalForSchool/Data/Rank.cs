using System.Collections;
using System.Collections.Generic;

namespace DigitalForSchool.Data
{
    public class Rank
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public string SubjectName { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
