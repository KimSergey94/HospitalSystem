using System;

namespace DAL.Entities
{
    public class AppointmentRecord
    {
        public long AppointmentRecordId { get; set; }
        public long AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        public string Symptom { get; set; }
        public DateTime Date { get; set; }
    }
}
