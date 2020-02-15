using System.ComponentModel.DataAnnotations;

namespace WebHospitalSystem.Models
{
    public class RegisterPatientVM
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }

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

        [Required(ErrorMessage = "Введите логин для входа в систему")]
        [Display(Name = "Логин для входа в систему")] 
        public string Login { get; set; }

        [Required(ErrorMessage = "Введите пароль для входа в систему")]
        [DataType(DataType.Password)] 
        [Display(Name = "Пароль для входа в систему")] 
        public string Password { get; set; }

        [Required(ErrorMessage = "Введите пароль повторно")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}