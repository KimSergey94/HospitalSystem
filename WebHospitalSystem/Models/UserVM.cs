using System.ComponentModel.DataAnnotations;

namespace WebHospitalSystem.Models
{
    public class UserVM
    {
        [Key]
        [Display(Name = "ID пользователя")]
        public long UserId { get; set; }

        [Required(ErrorMessage = "Введите логин")]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Тип пользователя")]
        public int RoleId { get; set; }
    }
}