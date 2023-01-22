using System.Collections.Generic;
using System.Security.Policy;

namespace DigitalForSchool.Data
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public IList<Lesson> Lessons { get; set; } = new List<Lesson>();
        public ICollection<Rank> Rank { get; set; } 
    }
}
