﻿using System;

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
