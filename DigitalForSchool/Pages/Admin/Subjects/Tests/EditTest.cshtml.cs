using DigitalForSchool.Data;
using DigitalForSchool.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace DigitalForSchool.Pages.Admin.Subjects.Tests
{
    public class EditTestModel : PageModel
    {
        [BindProperty]
        public Test Test { get; set; }
        [BindProperty]
        public int Id { get; set; }
        private readonly TestService _service;
        public EditTestModel(TestService service)
        {
            _service = service;
        }
        public void OnGet(int id)
        {
            var testId = _service.GetLesson(id).TestId;
            if ( testId > 0)
            {
                Test = _service.GetTest(testId);
            }
        }
        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    foreach (var item in Request.Form.Keys)
                    {
                        if (char.IsDigit(item[0]) == true)
                        {
                            Int32.TryParse(item, out var questIndex);
                            Int32.TryParse(Request.Form[item], out var answerIndex);
                            Test.Questions[questIndex].Answers[answerIndex].IsRight = true;
                        }
                    }

                    var res = await _service.EditTest(Test);
                    if (res == false)
                    {
                        ModelState.AddModelError(string.Empty, "Теста нет на платформе");
                        return Page();
                    }

                    return RedirectToPage("/Admin/AdminPanel");
                }
            }
            catch (System.Exception)
            {

                ModelState.AddModelError(string.Empty, "Возникла ошибка");
            }
            return Page();
        }
    }
}
