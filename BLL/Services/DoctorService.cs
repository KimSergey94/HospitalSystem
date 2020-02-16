using BLL.DTO;
using BLL.Interfaces;
using BLL.Util;
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
            Database.Doctors.Create(MapperUtil.MapToDoctor(doctorDTO));
            Database.Save();
        }
        public void EditDoctor(DoctorDTO doctorDTO)
        {
            Doctor doctor = Database.Doctors.Find(x => x.DoctorId == doctorDTO.DoctorId).FirstOrDefault();
            if (doctor != null) {
                doctor = MapperUtil.UpdateDoctorFieldsFromDTO(doctor, doctorDTO);
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
            return MapperUtil.MapToDoctorDTOList(Database.Doctors.GetAll());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
