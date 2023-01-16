using System.Collections.Generic;

namespace DigitalForSchool.Data
{
    public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Answer> Answers { get; set; } = new List<Answer>();
    }
}
