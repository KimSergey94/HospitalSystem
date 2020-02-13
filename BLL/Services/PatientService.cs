using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;

namespace BLL.Services
{
    public class PatientService : IPatientService
    {
        IUnitOfWork Database { get; set; }

        public PatientService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void AddPatient(PatientDTO patientDTO)
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

        public IEnumerable<PatientDTO> GetPatients()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Patient, PatientDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Patient>, List<PatientDTO>>(Database.Patients.GetAll());
        }
    }
}
