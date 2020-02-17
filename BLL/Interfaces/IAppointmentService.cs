using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IAppointmentService
    {
        void AddAppointment(AppointmentDTO appointmentDTO);
        void AddAppointmentRecord(AppointmentRecordDTO appointmentRecordDTO);
        
        void EditAppointment(AppointmentDTO appointmentDTO);
        void EditAppointmentRecord(AppointmentRecordDTO appointmentDTO);
        
        void DeleteAppointment(long appointmentId);
        void DeleteAppointmentRecord(long appointmentRecordId);

        AppointmentDTO GetAppointment(long id);
        AppointmentRecordDTO GetAppointmentRecord(long id);

        string GetDoctorName(int id);
        string GetPatientName(long id);
        bool IsAppointmentIdValid(long id);

        IEnumerable<AppointmentDTO> GetAppointments();
        IEnumerable<AppointmentRecordDTO> GetAppointmentRecords();
        IEnumerable<AppointmentRecordDTO> GetAppointmentRecordsByAppointment(long appointmentId);
        void Dispose();
    }
}
