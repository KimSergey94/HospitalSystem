using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities
{
    class Patient
    {
        public long patientId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string iin { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
    }
}
