using DigitalForSchool.Data;
using DigitalForSchool.Models;
using DigitalForSchool.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalForSchool.Pages.Admin.Subjects
{
    public class EditSubjectModel : PageModel
    {
        [BindProperty]
        public Subject Input { get; set; }
        private readonly SubjectService _service;
        public EditSubjectModel(SubjectService service)
        {
            _service = service;
        }
        public void OnGet(int id)
        {
            Input = _service.GetSubject(id);
        }
        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (ModelState.IsValid == true)
                {

                    var res = await _service.EditSubject(Input);

                    if (res != true)
                    {
                        ModelState.AddModelError(string.Empty, "Такой предмета не существует");
                        return Page();
                    }
                    return RedirectToPage("SubjectsPanel");
                }
            }
            catch (System.Exception)
            {

                ModelState.AddModelError(string.Empty, "При изменении предмета возникла ошибка");
            }
            return Page();
        } 
    }
}
