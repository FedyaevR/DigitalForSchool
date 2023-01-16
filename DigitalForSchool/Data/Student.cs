using System.Collections.Generic;

namespace DigitalForSchool.Data
{
    //TODO: Check correlation Student with Rank
    public class Student
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
        
    }
}
