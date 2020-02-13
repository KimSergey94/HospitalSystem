﻿namespace WebHospitalSystem.Models
{
    public class AppointmentVM
    {
        public long AppointmentId { get; set; }
        public int DoctorId { get; set; }
        public long PatientId { get; set; }
        public string Diagnosis { get; set; }
    }
}