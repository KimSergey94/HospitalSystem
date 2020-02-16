using BLL.DTO;
using BLL.Interfaces;
using BLL.Util;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class PatientService : IPatientService
    {
        IUnitOfWork Database { get; set; }
        public PatientService(IUnitOfWork uow) { Database = uow; }

        public IEnumerable<PatientDTO> GetPatients()
        {
            return MapperUtil.MapToPatientDTOList(Database.Patients.GetAll());
        }

        public void AddPatient(PatientDTO patientDTO)
        {
            Database.Patients.Create(MapperUtil.MapToPatient(patientDTO));
            Database.Save();
        }

        public void EditPatient(PatientDTO patientDTO)
        {
            Patient patient = Database.Patients.Find(x => x.PatientId == patientDTO.PatientId).First();
            if (patient != null)
            {
                patient = MapperUtil.UpdatePatientFieldsFromDTO(patient, patientDTO);
                Database.Patients.Update(patient);
                Database.Save();
            }
        }

        public void DeletePatient(long id)
        {
            Database.Patients.Delete(id);
            Database.Save();
        }

        public bool isIINAvailable(string IIN)
        {
            var patient = Database.Patients.Find(x => x.IIN == IIN).ElementAtOrDefault(0);
            if (patient == null)
                return true;
            else
                return false;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
