using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class PatientRepository : IRepositoryLong<Patient>
    {
        private HospitalSystemContext db;

        public PatientRepository(HospitalSystemContext context)
        {
            this.db = context;
        }

        public IEnumerable<Patient> GetAll()
        {
            return db.Patients;
        }

        public Patient Get(long id)
        {
            return db.Patients.Find(id);
        }

        public void Create(Patient item)
        {
            db.Patients.Add(item);
        }

        public void Update(Patient item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public IEnumerable<Patient> Find(Func<Patient, Boolean> predicate)
        {
            return db.Patients.Where(predicate).ToList();
        }

        public void Delete(long id)
        {
            Patient item = db.Patients.Find(id);
            if (item != null)
                db.Patients.Remove(item);
        }

    }
}