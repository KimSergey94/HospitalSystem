using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities
{
    class AppointmentRecord
    {
        public long appointmentRecordId { get; set; }
        public long appointmentId { get; set; }
        public Appointment appointment { get; set; }
        public string symptom { get; set; }
        public DateTime date { get; set; }
    }
}
