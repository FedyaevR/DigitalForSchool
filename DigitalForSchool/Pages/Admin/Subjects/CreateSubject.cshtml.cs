using DigitalForSchool.Models;
using DigitalForSchool.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace DigitalForSchool.Pages.Admin.Subjects
{
    public class CreateSubjectModel : PageModel
    {
        [BindProperty]
        public CreateSubjectCommand Input { get; set; }
        private readonly SubjectService _service;
        public CreateSubjectModel(SubjectService service)
        {
            _service = service;
        }
        public void OnGet()
        {
            Input = new CreateSubjectCommand();
        }
        public  IActionResult OnPost()
        {
           
            try
            {
                if (ModelState.IsValid == true)
                {

                    var id = _service.CreateSubject(Input);

                    if (id == -1)
                    {
                        ModelState.AddModelError(string.Empty, "Такой предмет уже есть");
                        return Page();
                    }
                    return RedirectToPage("SubjectsPanel");
                }
            }
            catch (System.Exception)
            {

                ModelState.AddModelError(string.Empty, "При создании нового предмета возникла ошибка");
            }
            return Page();
        }
    }
}
