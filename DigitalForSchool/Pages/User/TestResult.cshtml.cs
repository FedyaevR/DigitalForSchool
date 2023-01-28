using DigitalForSchool.Data;
using DigitalForSchool.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace DigitalForSchool.Pages.User
{
    public class TestResultModel : PageModel
    {
        [BindProperty]
        public int Score { get; set; }
        [BindProperty]
        public List<Question> Questions { get; set; }
        [BindProperty]
        public List<string> StudentAnswers { get; set; }    
        private readonly TestService _service;
        public TestResultModel(TestService service)
        {
            _service = service;
        }
        public async void OnGet(int id)
        {
            Questions = await _service.GetQuestions(id);
            var questions = await _service.GetQuestions(id);
            StudentAnswers = JsonConvert.DeserializeObject<List<string>>(TempData["answers"].ToString());
            for (int i = 0; i < questions.Count; i++)
            {
                var answer = questions[i].Answers.FirstOrDefault(a => a.Text == StudentAnswers[i]);
                if (answer.IsRight == true)
                {
                    Score++;
                }
            }
        }
    }
}
