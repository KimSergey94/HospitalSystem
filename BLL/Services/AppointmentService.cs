using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
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
            //decimal sum = new Discount(0.1m).GetDiscount(orderDto.Price);
            //Order order = new Order
            //{
            //    Date = DateTime.Now,
            //    UserId = 2,
            //    Sum = sum,
            //    Name = orderDto.Name,
            //    Price = orderDto.Price
            //}; 
            //Database.Orders.Create(order); 
            //Database.Save();
        }

        public void AddAppointmentRecord(AppointmentRecordDTO appointmentRecordDTO)
        {
            //// применяем скидку
            //decimal sum = new Discount(0.1m).GetDiscount(orderDto.Price);
            //Order order = new Order
            //{
            //    Date = DateTime.Now,
            //    UserId = 2,
            //    Sum = sum,
            //    Name = orderDto.Name,
            //    Price = orderDto.Price
            //}; 
            //Database.Orders.Create(order); 
            //Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<AppointmentDTO> GetAppointments()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Appointment, AppointmentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Appointment>, List<AppointmentDTO>>(Database.Appointments.GetAll());
        }

        public IEnumerable<AppointmentRecordDTO> GetAppointmentsRecords()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AppointmentRecord, AppointmentRecordDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<AppointmentRecord>, List<AppointmentRecordDTO>>(Database.AppointmentRecords.GetAll());
        }
    }
}
