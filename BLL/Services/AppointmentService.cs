using BLL.DTO;
using BLL.Interfaces;
using BLL.Util;
using DAL.Interfaces;
using System.Collections.Generic;

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
            //// применяем скидку
            //Database.Doctors.Create(MapToDoctor(doctorDTO));
            //Database.Save();
        }

        public void AddAppointmentRecord(AppointmentRecordDTO appointmentRecordDTO)
        {
            //// применяем скидку
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
