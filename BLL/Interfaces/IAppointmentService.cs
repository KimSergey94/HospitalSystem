using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IAppointmentService
    {
        void AddAppointment(AppointmentDTO appointmentDTO);
        void AddAppointmentRecord(AppointmentRecordDTO appointmentRecordDTO);
        IEnumerable<AppointmentDTO> GetAppointments();
        IEnumerable<AppointmentRecordDTO> GetAppointmentsRecords();
        void Dispose();
    }
}
