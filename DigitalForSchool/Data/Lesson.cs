using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalForSchool.Data
{
    public class Lesson
    {
        public int Id { get; set; }
        [Required( ErrorMessage = "Укажите название")]
        public string Name { get; set; }
        public string Description { get; set; }

        public string VideoName { get; set; }
        [Required(ErrorMessage = "Укажите ссылку на видео")]
        public string VideoURL { get; set; }

        public string Presentation { get; set; }
        public int? TestId { get; set; }
        public Test Test { get; set; }
    }
}
