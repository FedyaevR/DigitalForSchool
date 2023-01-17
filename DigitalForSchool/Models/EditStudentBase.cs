using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DigitalForSchool.Models
{
    public class EditStudentBase
    {
        [Required, StringLength(100), DisplayName("Имя")]
        public string FirstName { get; set; }
        [Required, StringLength(100), DisplayName("Фамилия")]
        public string LastName { get; set; }
        [DisplayName("Отчество")]
        public string Patronymic { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

    }
}
