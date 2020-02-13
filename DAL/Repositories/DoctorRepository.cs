using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class DoctorRepository : IRepository<Doctor>
    {
        private HospitalSystemContext db;

        public DoctorRepository(HospitalSystemContext context)
        {
            this.db = context;
        }

        public IEnumerable<Doctor> GetAll()
        {
            return db.Doctors;
        }

        public Doctor Get(int id)
        {
            return db.Doctors.Find(id);
        }

        public void Create(Doctor item)
        {
            db.Doctors.Add(item);
        }

        public void Update(Doctor item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public IEnumerable<Doctor> Find(Func<Doctor, Boolean> predicate)
        {
            return db.Doctors.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Doctor item = db.Doctors.Find(id);
            if (item != null)
                db.Doctors.Remove(item);
        }

    }
}
