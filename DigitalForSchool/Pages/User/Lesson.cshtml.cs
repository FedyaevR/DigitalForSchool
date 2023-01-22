using DigitalForSchool.Data;
using DigitalForSchool.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace DigitalForSchool.Pages.User
{
    public class LessonModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public Lesson Lesson { get; set; }
        private readonly SubjectService _service;
        public LessonModel(SubjectService service)
        {
            _service = service;
        }
        public async Task OnGet()
        {
            Lesson = await _service.GetLesson(Id);
            Lesson.VideoURL = Lesson.VideoURL.Replace("watch?v=", "embed/");
        }
    }
}
