using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return db.Appointments;
        }

        public Appointment Get(long id)
        {
            return db.Appointments.Find(id);
        }

        public void Create(Appointment item)
        {
            db.Appointments.Add(item);
        }

        public void Update(Appointment item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public IEnumerable<Appointment> Find(Func<Appointment, Boolean> predicate)
        {
            return db.Appointments.Where(predicate).ToList();
        }

        public void Delete(long id)
        {
            Appointment item = db.Appointments.Find(id);
            if (item != null)
                db.Appointments.Remove(item);
        }

    }
}