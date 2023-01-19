using DigitalForSchool.Data;
using DigitalForSchool.Models;
using DigitalForSchool.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalForSchool.Pages.Admin.Students
{
    public class RegisterStudentsModel : PageModel
    {
        [BindProperty]
        public List<RegisterStudentCommand> Input { get; set; }
        private readonly StudentService _service;
        public RegisterStudentsModel(StudentService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            Input = new List<RegisterStudentCommand>();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid == true)
            {
                var numberStudent = (Request.Form.Keys.Count - 1) / 4;
                int id = _service.LastStudentId();
                for (int i = 0; i < numberStudent; i++)
                {
                    id++;
                    //Input.Add(new RegisterStudentCommand
                    //{
                    //    Login = "user_" + id,
                    //    Password = _service.CreateRandomPass()
                    //});
                    Input[i].Login = "user_" + id;
                    Input[i].Password = _service.CreateRandomPass();
                }

                await _service.AddNewStudents(Input);
                TempData["Input"] = JsonConvert.SerializeObject(Input);
                return RedirectToPage("NewStudentsInfo");
            }
            return Page();

        }

    }
}
