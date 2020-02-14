using System.ComponentModel.DataAnnotations;

namespace WebHospitalSystem.Models
{
    public class RoleVM
    {
        [Key]
        [Required(ErrorMessage = "Role Id field is required")]
        [Display(Name = "Role Id")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Name field is required")]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}