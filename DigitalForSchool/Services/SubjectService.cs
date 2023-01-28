﻿using DigitalForSchool.Data;
using DigitalForSchool.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
        public async Task<bool> EditSubject(Subject subject)
        {

            var subjectSource = _context.Subjects.Include(l => l.Lessons).Where(s => s.Id == subject.Id).FirstOrDefault();
            subjectSource.Name = subject.Name;
            if(subjectSource.Lessons.Count > subject.Lessons.Count)
            {
                for (int i =0; i<  subjectSource.Lessons.Count; i++)
                {
                    var item = subjectSource.Lessons[i];
                    if (subject.Lessons.FirstOrDefault(l => l.Id == item.Id) == null)
                    {
                        _context.Lessons.Remove(subjectSource.Lessons.FirstOrDefault(l => l.Id == item.Id));
                        subjectSource.Lessons.Remove(item);

                    }
                }
            }
            foreach (var item in subjectSource.Lessons)
            {
                var sub = subject.Lessons.Where(l => l.Id == item.Id).FirstOrDefault();
                if(sub != null)
                {
                    item.Name = sub.Name;
                    item.VideoURL = sub.VideoURL;
                    item.Description = sub.Description;
                    item.VideoName = sub.VideoName;
                }
                
            }
            if(subjectSource.Lessons.Count < subject.Lessons.Count)
            {
                foreach (var item in subject.Lessons)
                {
                    if(subjectSource.Lessons.FirstOrDefault(l => l.Id == item.Id) == null)
                    {
                        subjectSource.Lessons.Add(item);
                    }
                }
            }
         
            await _context.SaveChangesAsync();
            return true;
        }
        public Subject GetSubject(int id)
        {
            return _context.Subjects.Include(l => l.Lessons).Where(s => s.Id == id).FirstOrDefault();
        }
        public async Task<Lesson> GetLesson(int id)
        {
            return await _context.Lessons.Include(t => t.Test).ThenInclude(q => q.Questions).
                ThenInclude(a => a.Answers).Where(l => l.Id == id).FirstOrDefaultAsync();
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
