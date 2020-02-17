using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IAppointmentService
    {
        void AddAppointment(AppointmentDTO appointmentDTO);
        void EditAppointment(AppointmentDTO appointmentDTO);
        void DeleteAppointment(AppointmentDTO appointmentDTO);
        void CommitChanges();

        void AddAppointmentRecord(AppointmentRecordDTO appointmentRecordDTO);
        string GetDoctorName(int id);
        string GetPatientName(long id);
        AppointmentDTO GetAppointment(long id);
        bool IsAppointmentIdValid(long id);


        IEnumerable<AppointmentDTO> GetAppointments();
        IEnumerable<AppointmentRecordDTO> GetAppointmentsRecords();
        void Dispose();
    }
}
