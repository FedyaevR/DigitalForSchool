using DigitalForSchool.Data;
using DigitalForSchool.Models;
using DigitalForSchool.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalForSchool.Pages.Admin
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
            if (TempData["Input"]!= null)
            {
                Input = JsonConvert.DeserializeObject<List<RegisterStudentCommand>>(TempData["Input"].ToString());
                ViewData["Message"] = "Учетные записи студентов успешно созданы";
            }
            else
            {
                Input = new List<RegisterStudentCommand>();
            }
            
        }
        public async Task<IActionResult> OnPost(int numberOfStudent)
        {
            int id = _service.LastStudentId();
            for (int i = 0; i < numberOfStudent; i++)
            {
                id++;
                Input.Add(new RegisterStudentCommand
                {
                    Login = "user_" + id,
                    Password = _service.CreateRandomPass()
                });
            }

            await _service.AddNewStudents(Input);
            TempData["Input"] = JsonConvert.SerializeObject(Input);
            return RedirectToPage("RegisterStudents");
        }
        
    }
}
