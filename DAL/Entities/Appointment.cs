using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Appointment
    {
        public long AppointmentId { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public long PatientId { get; set; }
        public Patient Patient { get; set; }
        [DataType("NVARCHAR"), MaxLength(255)] 
        public string Diagnosis { get; set; }

        public virtual ICollection<AppointmentRecord> Records { get; set; }
    }
}
