using System;

namespace WebHospitalSystem.Models
{
    public class AppointmentRecordVM
    {
        public long AppointmentRecordId { get; set; }
        public long AppointmentId { get; set; }
        public string Symptom { get; set; }
        public DateTime Date { get; set; }
    }
}