using DigitalForSchool.Data;
using System.ComponentModel.DataAnnotations;

namespace DigitalForSchool.Models
{
    public class CreateLessonCommand
    {
        [Required(ErrorMessage = "Укажите навзание урока"), StringLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Укажите название видео"), StringLength(100)]
        public string VideoName { get; set; }
        [Required, Url(ErrorMessage = "Невозможно сохранить ссылку"), DataType("string")]
        public string VideoURL { get; set; }

        public string Presentation { get; set; }
        public Test Test { get; set; }

        public Lesson ToLesson()
        {
            return new Lesson
            {
                Name = Name,
                Description = Description,
                VideoName = VideoName,
                VideoURL = VideoURL,
                Presentation = Presentation
            };
        }
    }
}
