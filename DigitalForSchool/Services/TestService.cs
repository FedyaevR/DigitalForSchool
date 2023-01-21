using DigitalForSchool.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalForSchool.Services
{
    public class TestService
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;

        public TestService(AppDbContext context, ILoggerFactory factory)
        {
            _context = context;
            _logger = factory.CreateLogger<TestService>();
        }
        public Lesson GetLesson(int id)
        {
            return _context.Lessons.FirstOrDefault(l => l.Id == id);
        }
        public async Task<int> CreateTest(Test test, int lessonId)
        {
            if (await _context.Tests.ContainsAsync(test) == true)
            {
                return -1;
            }
            _context.Add(test);
            await _context.SaveChangesAsync();
            _context.Lessons.FirstOrDefault(l => l.Id == lessonId).TestId = test.Id;
            await _context.SaveChangesAsync();
            return test.Id;
        }
    }
}
