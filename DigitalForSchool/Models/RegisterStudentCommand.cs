using DigitalForSchool.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace DigitalForSchool.Models
{
    public class RegisterStudentCommand : EditStudentBase
    {
        public IList<CreateSubjectCommand> Subjects { get; set; } = new List<CreateSubjectCommand>();
        public IList<Rank> Ranks { get; set; } = new List<Rank>();
        public Student ToStudent()
        {
            return new Student
            {
                FirstName = FirstName,
                LastName = LastName,
                Patronymic = Patronymic,
                Login = Login,
                Password = Password,
                Subjects = Subjects.Select(s => s.ToSubject()).ToList(),
                Ranks = Ranks
            };  
        }
    }
}
