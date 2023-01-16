using DigitalForSchool.Data;
using Microsoft.Extensions.Logging;

namespace DigitalForSchool.Services
{
    public class StudentService
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;

        public StudentService(AppDbContext context, ILoggerFactory factory)
        {
            _context = context;
            _logger = factory.CreateLogger<StudentService>();
        }
    }
}
