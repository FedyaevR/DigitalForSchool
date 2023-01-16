using Microsoft.EntityFrameworkCore;

namespace DigitalForSchool.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        DbSet<Lesson> Lessons { get; set; }
        DbSet<Subject> Subjects { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Rank> Ranks { get; set; }
        DbSet<Test> Tests { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<Answer> Answers { get; set; }
    }
}
