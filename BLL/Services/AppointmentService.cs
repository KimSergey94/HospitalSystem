﻿using BLL.DTO;
using BLL.Interfaces;
using BLL.Util;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class AppointmentService : IAppointmentService
    {
        IUnitOfWork Database { get; set; }

        public AppointmentService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void AddAppointment(AppointmentDTO appointmentDTO)
        {
            if(appointmentDTO != null)
            {
                Database.Appointments.Create(MapperUtil.MapToAppointment(appointmentDTO));
                Database.Save();
            }
        }

        public void AddAppointmentRecord(AppointmentRecordDTO appointmentRecordDTO)
        {
            if (appointmentRecordDTO != null)
            {
                Database.AppointmentRecords.Create(MapperUtil.MapToAppointmentRecord(appointmentRecordDTO));
                Database.Save();
            }
        }

        public AppointmentDTO GetAppointment(long id)
        {
            return MapperUtil.MapToAppointmentDTO(Database.Appointments.Find(x => x.AppointmentId == id).FirstOrDefault());
        }
        public bool IsAppointmentIdValid(long id)
        {
            if(Database.Appointments.Find(x => x.AppointmentId == id).FirstOrDefault() != null)
            {
                return true;
            }
            return false;
        }

        public void EditAppointment(AppointmentDTO appointmentDTO)
        {
            var appointment = Database.Appointments.Find(x => x.AppointmentId == appointmentDTO.AppointmentId).FirstOrDefault();
            appointment = MapperUtil.UpdateAppointmentFieldsFromDTO(appointment, appointmentDTO);
            Database.Appointments.Update(appointment);
        }
        public void DeleteAppointment(AppointmentDTO appointmentDTO)
        {

        }
        public void CommitChanges()
        {
            Database.Save();
        }

        public string GetDoctorName(int id)
        {
            Doctor doctor = Database.Doctors.GetAll().Select(x => x).Where(docId => docId.DoctorId == id).FirstOrDefault();
            if (doctor != null) {
                return doctor.LastName + " " + doctor.FirstName + " " + doctor.Patronymic;
            }
            else
            {
                return "неизвестно";
            }
        }
        public string GetPatientName(long id)
        {
            Patient patient = Database.Patients.GetAll().Select(x => x).Where(patId => patId.PatientId == id).FirstOrDefault();
            if (patient != null)
            {
                return patient.LastName + " " + patient.FirstName + " " + patient.Patronymic;
            }
            else
            {
                return "неизвестно";
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<AppointmentDTO> GetAppointments()
        {
            return MapperUtil.MapToAppointmentDTOList(Database.Appointments.GetAll());
        }

        public IEnumerable<AppointmentRecordDTO> GetAppointmentsRecords()
        {
            return MapperUtil.MapToAppointmentRecordDTOList(Database.AppointmentRecords.GetAll());
        }
    }
}
