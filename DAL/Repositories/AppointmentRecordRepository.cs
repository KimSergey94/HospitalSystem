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
    public class AppointmentRecordRepository : IRepositoryLong<AppointmentRecord>
    {
        private HospitalSystemContext db;

        public AppointmentRecordRepository(HospitalSystemContext context)
        {
            this.db = context;
        }

        public IEnumerable<AppointmentRecord> GetAll()
        {
            return db.AppointmentRecords;
        }

        public AppointmentRecord Get(long id)
        {
            return db.AppointmentRecords.Find(id);
        }

        public void Create(AppointmentRecord item)
        {
            db.AppointmentRecords.Add(item);
        }

        public void Update(AppointmentRecord item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public IEnumerable<AppointmentRecord> Find(Func<AppointmentRecord, Boolean> predicate)
        {
            return db.AppointmentRecords.Where(predicate).ToList();
        }

        public void Delete(long id)
        {
            AppointmentRecord item = db.AppointmentRecords.Find(id);
            if (item != null)
                db.AppointmentRecords.Remove(item);
        }

    }
}