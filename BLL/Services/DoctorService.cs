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
            // применяем скидку
            Doctor doctor = new Doctor
            {
                FirstName = doctorDTO.FirstName,
                LastName = doctorDTO.LastName,
                Patronymic = doctorDTO.Patronymic,
                PhoneNumber= doctorDTO.PhoneNumber,
                UserId = doctorDTO.UserId
            };
            Database.Doctors.Create(doctor);
            Database.Save();
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
