﻿using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class PatientService : IPatientService
    {
        IUnitOfWork Database { get; set; }

        public PatientService(IUnitOfWork uow)
        {
            Database = uow;
        }

        Patient MapToPatient(PatientDTO patientDTO)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<PatientDTO, Patient>()).CreateMapper()
             .Map<PatientDTO, Patient>(patientDTO);
        }
        

        public void AddPatient(PatientDTO patientDTO)
        {
            Database.Patients.Create(MapToPatient(patientDTO));
            Database.Save();
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

        public bool isIINAvailable(string IIN)
        {
            var patient = Database.Patients.Find(x => x.IIN == IIN).ElementAtOrDefault(0);
            if (patient == null)
                return true;
            else
                return false;
        }
    }
}
