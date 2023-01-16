using DigitalForSchool.Data;
using Microsoft.Extensions.Logging;

namespace DigitalForSchool.Services
{
    public class SubjectService
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;

        public SubjectService(AppDbContext context, ILoggerFactory factory)
        {
            _context = context;
            _logger = factory.CreateLogger<SubjectService>();
        }

    }
}
