using DigitalForSchool.Data;
using System.Collections.Generic;

namespace DigitalForSchool.Models
{
    public class SubjectSummaryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
