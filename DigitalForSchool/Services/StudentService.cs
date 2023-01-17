using DigitalForSchool.Data;
using DigitalForSchool.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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


        public async Task<bool> AddNewStudents(List<RegisterStudentCommand> students)
        {
            
            try
            {
                var res = students.Select(s => s.ToStudent());
                foreach (var item in res)
                {
                    _context.Add(item);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
            
            
        } 
        public int LastStudentId()
        {
            var lastStud = _context.Students.OrderBy(s => s).LastOrDefault() ;
            if(lastStud != null) return lastStud.Id;
            return 0;
        }
        public string CreateRandomPass()
        {
            return Guid.NewGuid().ToString().Substring(0, 6);
        }

        public Student GetStudent(int id)
        {
            return  _context.Students.FirstOrDefault(s => s.Id == id);
        }
        public async void EditStudent(Student student)
        {
            var stud = _context.Students.FirstOrDefault(s => s.Id == student.Id);
            stud.FirstName = student.FirstName;
            stud.LastName = student.LastName;
            stud.Patronymic = student.Patronymic;
            stud.Login = student.Login;
            stud.Password = student.Password;

             _context.SaveChanges();
        }
    }
}
