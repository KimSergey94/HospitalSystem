using System.ComponentModel.DataAnnotations;

namespace WebHospitalSystem.Models
{
    public class DoctorVM
    {
        [Display(Name = "ID врача")]
        public int DoctorId { get; set; }
        
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        
        [Display(Name = "Телефонный номер")]
        public string PhoneNumber { get; set; }
        
        [Display(Name = "ID пользователя в системе")]
        public long UserId { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1} {2}", LastName, FirstName, Patronymic);
            }
        }
    }
}