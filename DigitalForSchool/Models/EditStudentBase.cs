using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DigitalForSchool.Models
{
    public class EditStudentBase
    {
        [Required(ErrorMessage = "Укажите имя ученика"), StringLength(100), DisplayName("Имя")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Укажите фамилию ученика"), StringLength(100), DisplayName("Фамилия")]
        public string LastName { get; set; }
        [DisplayName("Отчество")]
        public string Patronymic { get; set; }
        [Required(ErrorMessage = "Введите название учебного учреждения"), DisplayName("Учебное учреждение")]
        public string SchoolName { get; set; }
        public string BirthdayDate { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

    }
}
