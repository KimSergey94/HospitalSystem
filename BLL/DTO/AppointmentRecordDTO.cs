using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class AppointmentRecordDTO
    {
        public long AppointmentRecordId { get; set; }
        public long AppointmentId { get; set; }
        public string Symptom { get; set; }
        public DateTime Date { get; set; }
    }
}
