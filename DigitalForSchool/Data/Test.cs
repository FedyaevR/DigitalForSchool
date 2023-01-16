using System.Collections;
using System.Collections.Generic;

namespace DigitalForSchool.Data
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Question> Questions { get; set; } = new List<Question>();
        public Lesson Lesson { get; set; }

    }
}
