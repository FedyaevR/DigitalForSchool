using DigitalForSchool.Data;
using System.ComponentModel.DataAnnotations;

namespace DigitalForSchool.Models
{
    public class CreateLessonCommand
    {
        [Required, StringLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required, StringLength(100)]
        public string VideoName { get; set; }
        [Required, Url(ErrorMessage = "Невозможно сохранить ссылку"), DataType("string")]
        public string VideoURL { get; set; }

        public string Presentation { get; set; }
        public CreateTestCommand Test { get; set; }

        public Lesson ToLesson()
        {
            return new Lesson
            {
                Name = Name,
                Description = Description,
                VideoName = VideoName,
                VideoURL = VideoURL,
                Presentation = Presentation,
                Test = Test.ToTest()
            };
        }
    }
}
