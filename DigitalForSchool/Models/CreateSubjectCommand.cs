using DigitalForSchool.Data;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DigitalForSchool.Models
{
    public class CreateSubjectCommand
    {
        [Required(ErrorMessage = "Укажите название предмета")]
        public string Name { get; set; }
        public IList<CreateLessonCommand> Lessons { get; set; } = new List<CreateLessonCommand>();

        public Subject ToSubject()
        {
            return new Subject
            {
                Name = Name,
                Lessons = Lessons.Select(l => l.ToLesson()).ToList()
            };
        }
    }
}
