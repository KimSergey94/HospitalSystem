using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IPatientService
    {
        void AddPatient(PatientDTO patientDTO); 
        IEnumerable<PatientDTO> GetPatients(); 
        void Dispose();
    }
}
