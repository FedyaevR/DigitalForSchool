using DigitalForSchool.Models;
using DigitalForSchool.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace DigitalForSchool.Pages.User
{
    public class SubjectSelectModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public List<SubjectSummaryViewModel> Subjects { get; set; }
        private readonly SubjectService _service;
        public SubjectSelectModel(SubjectService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            Subjects = _service.GetAllSubjects();
        }
    }
}
