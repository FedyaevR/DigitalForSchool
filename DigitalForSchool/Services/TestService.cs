using DigitalForSchool.Data;
using Microsoft.Extensions.Logging;

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
    }
}
