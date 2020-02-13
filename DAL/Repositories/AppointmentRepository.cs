using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class AppointmentRepository : IRepositoryLong<Appointment>
    {
        private HospitalSystemContext db;

        public AppointmentRepository(HospitalSystemContext context)
        {
            this.db = context;
        }

        public IEnumerable<Appointment> GetAll()
        {
            return db.Appointment;
        }

        public Appointment Get(long id)
        {
            return db.Appointment.Find(id);
        }

        public void Create(Appointment item)
        {
            db.Appointment.Add(item);
        }

        public void Update(Appointment item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public IEnumerable<Appointment> Find(Func<Appointment, Boolean> predicate)
        {
            return db.Appointment.Where(predicate).ToList();
        }

        public void Delete(long id)
        {
            Appointment item = db.Appointment.Find(id);
            if (item != null)
                db.Appointment.Remove(item);
        }

    }
}