using DigitalForSchool.Data;
using DigitalForSchool.Models;
using DigitalForSchool.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Collections.Generic;

namespace DigitalForSchool.Pages.Admin.Students
{
    public class AllStudentsInfoModel : PageModel
    {
        [BindProperty]
        public List<Student> Input { get; set; } = new List<Student>();
        private readonly StudentService _service;
        public AllStudentsInfoModel(StudentService service)
        {
            _service = service;
        }
        public  void OnGet()
        {
            Input = _service.GetAllStudents();
        }
    }
}
