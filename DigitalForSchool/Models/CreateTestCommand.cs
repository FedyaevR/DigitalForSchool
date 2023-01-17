using DigitalForSchool.Data;
using System.Collections.Generic;

namespace DigitalForSchool.Models
{
    public class CreateTestCommand
    {
        public string Name { get; set; }
        public IList<Question> Questions { get; set; } = new List<Question>();

        public Test ToTest()
        {
            return new Test
            {
                Name = Name,
                Questions = Questions,
            };
        }
    }
}
