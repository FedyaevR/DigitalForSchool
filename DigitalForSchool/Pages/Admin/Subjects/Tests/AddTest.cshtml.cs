using DigitalForSchool.Data;
using DigitalForSchool.Models;
using DigitalForSchool.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalForSchool.Pages.Admin.Subjects.Tests
{
    public class AddTestModel : PageModel
    {
        [BindProperty]
        public Test Test { get; set; }
        [BindProperty]
        public int Id { get; set; }
        private readonly TestService _service;

        public AddTestModel(TestService service)
        {
            _service = service;
        }
        public void OnGet(int id)
        {
            if(_service.GetLesson(id).TestId > 0)
            {
                Test = null;
            }
            else
            {
                Test = new Test();
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
                    
                    var id = await _service.CreateTest(Test, Id);
                    if (id == -1)
                    {
                        ModelState.AddModelError(string.Empty, "Test already have on platform");
                        return Page();
                    }

                    return RedirectToPage("/Admin/AdminPanel");
                }
            }
            catch (System.Exception)
            {

                ModelState.AddModelError(string.Empty, "An error occured a create new subject");
            }
            return Page();
        }
    }
}
