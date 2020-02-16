using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IDoctorService
    {
        void AddDoctor(DoctorDTO doctorDTO);
        void EditDoctor(DoctorDTO doctorDTO);
        void DeleteDoctor(int id);
        IEnumerable<DoctorDTO> GetDoctors();
        void Dispose();
    }
}
