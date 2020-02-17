using System.ComponentModel.DataAnnotations;

namespace WebHospitalSystem.Models
{
    public class AppointmentVM
    {
        [Display(Name = "ID приема")]
        public long AppointmentId { get; set; }

        [Display(Name = "ID врача")]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Необходимо выбрать врача")]
        [Display(Name = "ФИО врача")]
        public string DoctorName { get; set; }
        public DoctorVM Doctor { get; set; }

        [Display(Name = "ID пациента")]
        public long PatientId { get; set; }

        [Required(ErrorMessage = "Необходимо выбрать пациента")]
        [Display(Name = "ФИО пациента")]
        public string PatientName { get; set; }
        public PatientVM Patient { get; set; }

        [Display(Name = "Диагноз")]
        public string Diagnosis { get; set; }




        [Display(Name = "Симптомы")]
        public string Symptom { get; set; }

        [Display(Name = "Дата посещения")]
        public System.DateTime Date { get; set; }





        public AppointmentVM()
        {
            Patient = new PatientVM ();
            Doctor = new DoctorVM ();
        }
    }
}