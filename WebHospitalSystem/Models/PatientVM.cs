using System.ComponentModel.DataAnnotations;

namespace WebHospitalSystem.Models
{
    public class PatientVM
    {
        [Display(Name = "ID пациента")]
        public long PatientId { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [Display(Name = "ИИН")]
        public string IIN { get; set; }

        [Display(Name = "Телефонный номер")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Адрес проживания")]
        public string Address { get; set; }

        [Display(Name = "ID пользователя в системе")]
        public long UserId { get; set; }
    }
}