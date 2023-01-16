using System.Collections.Generic;

namespace DigitalForSchool.Data
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string VideoName { get; set; }
        public string VideoURL { get; set; }
        public string Presentation { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }
    }
}
