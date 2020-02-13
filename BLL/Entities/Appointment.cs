using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities
{
    class Appointment
    {
        public long appointmentId { get; set; }
        public int doctorId { get; set; }
        public Doctor doctor { get; set; }
        public long patientId { get; set; }
        public Patient patient { get; set; }
        public string diagnosis { get; set; }

        public virtual ICollection<AppointmentRecord> records { get; set; }
    }
}
