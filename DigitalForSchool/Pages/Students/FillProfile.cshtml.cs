using DigitalForSchool.Data;
using DigitalForSchool.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigitalForSchool.Pages.Students
{
    public class FillProfileModel : PageModel
    {
        [BindProperty]
        public Student Input { get; set; }
        private readonly StudentService _service;
        public int Id { get; set; }
        public FillProfileModel(StudentService service)
        {
            _service = service;
        }

        public  void OnGet(int id)
        {
            this.Id = id;
            Input =  _service.GetStudent(id);
        }
        public void OnPost()
        {
            _service.EditStudent(Input);
        }
    }
}
