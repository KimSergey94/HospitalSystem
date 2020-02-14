using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebHospitalSystem.Models
{
    public class RegisterPatientVM
    {
        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "ИИН")]
        public string IIN { get; set; }

        [Required]
        [Display(Name = "Телефонный номер")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Адрес проживания")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Логин для входа в систему")] 
        public string Login { get; set; }

        [Required] 
        [DataType(DataType.Password)] 
        [Display(Name = "Пароль для входа в систему")] 
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}