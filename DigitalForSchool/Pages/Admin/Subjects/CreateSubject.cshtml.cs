using DigitalForSchool.Models;
using DigitalForSchool.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DigitalForSchool.Pages.Admin.Subjects
{
    public class CreateSubjectModel : PageModel
    {
        [BindProperty]
        public CreateSubjectCommand Input { get; set; }
        private readonly SubjectService _service;
        [BindProperty]
        public List<IFormFile> Upload { get; set; }
        public CreateSubjectModel(SubjectService service)
        {
            _service = service;
        }
        public void OnGet()
        {
            Input = new CreateSubjectCommand();
        }
        public  async Task<IActionResult> OnPost()
        {
           
            try
            {
                if (ModelState.IsValid == true)
                {
                    var res = Request.Form.Files;
                    for (int i = 0; i < res.Count; i++)
                    {
                        var path = Path.Combine("/presentation", res[i].FileName);
                        var file = Path.Combine("wwwroot", "presentation", res[i].FileName);
                        using (var fs = new FileStream(file, FileMode.Create))
                        {
                            await res[i].CopyToAsync(fs);
                        }
                        Input.Lessons[i].Presentation = path;

                    }
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
