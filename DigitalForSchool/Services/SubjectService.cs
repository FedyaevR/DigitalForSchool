using DigitalForSchool.Data;
using DigitalForSchool.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public int CreateSubject(CreateSubjectCommand cmd)
        {
            var subject = cmd.ToSubject();
            if (_context.Subjects.Contains(subject) == true)
            {
                return -1;
            }
            _context.Add(subject);
            _context.SaveChanges();
            return subject.Id;
        }
        public  List<SubjectSummaryViewModel> GetAllSubjects()
        {
            return  _context.Subjects
                .Select(s => new SubjectSummaryViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Lessons = s.Lessons.ToList()
                }).ToList();
        }

      
    }
}
