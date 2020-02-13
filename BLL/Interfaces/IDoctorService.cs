using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IDoctorService
    {
        void AddDoctor(DoctorDTO doctorDTO);
        IEnumerable<DoctorDTO> GetDoctors();
        void Dispose();
    }
}
