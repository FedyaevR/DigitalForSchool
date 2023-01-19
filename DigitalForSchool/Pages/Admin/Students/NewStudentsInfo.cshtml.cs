using DigitalForSchool.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DigitalForSchool.Pages.Admin.Students
{
    public class NewStudentsInfoModel : PageModel
    {
        [BindProperty]
        public List<RegisterStudentCommand> Input { get; set; }
        public void OnGet()
        {
            if (TempData["Input"] != null)
            {
                Input = JsonConvert.DeserializeObject<List<RegisterStudentCommand>>(TempData["Input"].ToString());
            }
            else
            {
                Input = new List<RegisterStudentCommand>();
            }
        }
    }
}
