using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;

namespace BLL.Services
{
    public class DoctorService : IDoctorService
    {
        IUnitOfWork Database { get; set; }

        public DoctorService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void AddDoctor(DoctorDTO doctorDTO)
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

        public IEnumerable<DoctorDTO> GetDoctors()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Doctor, DoctorDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Doctor>, List<DoctorDTO>>(Database.Doctors.GetAll());
        }
    }
}
