using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPatientService
    {
        void AddPatient(PatientDTO patientDTO); 
        IEnumerable<PatientDTO> GetPatients(); 
        void Dispose();
    }
}
