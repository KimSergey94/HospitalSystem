using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IAppointmentService
    {
        void AddAppointment(AppointmentDTO appointmentDTO);
        void EditAppointment(AppointmentDTO appointmentDTO);
        void EditAppointmentRecord(AppointmentRecordDTO appointmentDTO);
        void DeleteAppointment(long appointmentId);
        void DeleteAppointmentRecord(long appointmentRecordId);

        void AddAppointmentRecord(AppointmentRecordDTO appointmentRecordDTO);
        string GetDoctorName(int id);
        string GetPatientName(long id);
        AppointmentDTO GetAppointment(long id);
        bool IsAppointmentIdValid(long id);


        IEnumerable<AppointmentDTO> GetAppointments();
        IEnumerable<AppointmentRecordDTO> GetAppointmentRecords();
        IEnumerable<AppointmentRecordDTO> GetAppointmentRecordsByAppointment(long appointmentId);
        void Dispose();
    }
}
