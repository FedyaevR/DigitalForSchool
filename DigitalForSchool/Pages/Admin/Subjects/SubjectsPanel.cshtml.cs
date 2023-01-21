using DigitalForSchool.Data;
using DigitalForSchool.Models;
using DigitalForSchool.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace DigitalForSchool.Pages.Admin.Subjects
{
    public class SubjectsPanelModel : PageModel
    {
        public List<SubjectSummaryViewModel> Subjects { get; set; } = new List<SubjectSummaryViewModel>();
        private readonly SubjectService _service;
        public SubjectsPanelModel(SubjectService service)
        {
            _service = service;
        }
        public void OnGet()
        {
            Subjects =  _service.GetAllSubjects();
        }
        public JsonResult OnGetGetTestAvailable(int lessonId)
        {
            return  new JsonResult("student saved successfully");
        }
    }


}
