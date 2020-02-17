using System.ComponentModel.DataAnnotations;

namespace WebHospitalSystem.Models
{
    public class PatientVM
    {
        [Display(Name = "ID пациента")]
        public long PatientId { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введите фамилию")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [Required(ErrorMessage = "Введите ИИН")]
        [Display(Name = "ИИН")]
        public string IIN { get; set; }

        [Required(ErrorMessage = "Введите телефонный номер")]
        [Display(Name = "Телефонный номер")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Введите адрес проживания")]
        [Display(Name = "Адрес проживания")]
        public string Address { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1} {2}", LastName, FirstName, Patronymic);
            }
        }
    }
}