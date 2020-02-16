using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

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
            Database.Doctors.Create(MapToDoctor(doctorDTO));
            Database.Save();
        }
        public void EditDoctor(DoctorDTO doctorDTO)
        {
            Doctor doctor = Database.Doctors.Find(x => x.DoctorId == doctorDTO.DoctorId).FirstOrDefault();
            if (doctor != null) {
                doctor = updateFields(doctor, doctorDTO);
                Database.Doctors.Update(doctor);
                Database.Save();
            }
        }
        public void DeleteDoctor(int id)
        {
            Database.Doctors.Delete(id);
            Database.Save();
        }

        public IEnumerable<DoctorDTO> GetDoctors()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Doctor, DoctorDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Doctor>, List<DoctorDTO>>(Database.Doctors.GetAll());
        }

        Doctor MapToDoctor(DoctorDTO doctorDTO)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<DoctorDTO, Doctor>()).CreateMapper()
             .Map<DoctorDTO, Doctor>(doctorDTO);
        }
        Doctor updateFields(Doctor doctor, DoctorDTO doctorDTO)
        {
            doctor.FirstName = doctorDTO.FirstName;
            doctor.LastName = doctorDTO.LastName;
            doctor.Patronymic = doctorDTO.Patronymic;
            doctor.PhoneNumber = doctorDTO.PhoneNumber;
            return doctor;
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
