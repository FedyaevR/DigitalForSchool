using DigitalForSchool.Data;
using DigitalForSchool.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalForSchool.Pages.User
{
    public class TestModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public List<Question> Input { get; set; } = new List<Question>();
        private readonly TestService _service;
        [BindProperty(SupportsGet = true)]
        public int QuestionId { get; set; }
        private List<string> answers = new List<string>();
        
        public TestModel(TestService service)
        {
            _service = service;
        }
        public async void OnGet(int id, int questionId = 0)
        {
            QuestionId = questionId;
            Input = await _service.GetQuestions(id);    
        }
        public async Task<IActionResult> OnPost(int id, int questionId)
        {
            Input = await _service.GetQuestions(id);
            var quest = Request.Form.Keys.First();
            if (Input.Last().Name != quest )
            {
                Request.Form.TryGetValue(quest, out var res);
                if (TempData["answers"] != null)answers = JsonConvert.DeserializeObject<List<string>>(TempData["answers"].ToString());
                answers.Add(res);

                TempData["answers"] = JsonConvert.SerializeObject(answers);
                questionId++;
                return RedirectToPage("Test", new { id= id, questionId = questionId });
            }
            else
            {
                Request.Form.TryGetValue(quest, out var res);
                answers = JsonConvert.DeserializeObject<List<string>>(TempData["answers"].ToString());
                answers.Add(res);
                TempData["answers"] = JsonConvert.SerializeObject(answers);
                return RedirectToPage("TestResult", new {id = id });
            }          
        }
    }
}
