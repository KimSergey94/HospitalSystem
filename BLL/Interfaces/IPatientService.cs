using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IPatientService
    {
        bool isIINAvailable(string IIN);
        void AddPatient(PatientDTO patientDTO); 
        IEnumerable<PatientDTO> GetPatients(); 
        void Dispose();
    }
}
