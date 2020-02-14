using System.ComponentModel.DataAnnotations;

namespace WebHospitalSystem.Models
{
    public class AppointmentVM
    {
        [Display(Name = "ID приема")]
        public long AppointmentId { get; set; }
        
        [Display(Name = "ID врача")]
        public int DoctorId { get; set; }
        
        [Display(Name = "ID пациента")]
        public long PatientId { get; set; }
        
        [Display(Name = "Диагноз")]
        public string Diagnosis { get; set; }
    }
}