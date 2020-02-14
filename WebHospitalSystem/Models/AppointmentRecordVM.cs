using System;
using System.ComponentModel.DataAnnotations;

namespace WebHospitalSystem.Models
{
    public class AppointmentRecordVM
    {
        [Display(Name = "ID записи приема")]
        public long AppointmentRecordId { get; set; }
        
        [Display(Name = "ID приема")]
        public long AppointmentId { get; set; }
        
        [Display(Name = "Симптомы")]
        public string Symptom { get; set; }
        
        [Display(Name = "Дата посещения")]
        public DateTime Date { get; set; }
    }
}