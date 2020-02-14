using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class RoleRepository : IRepository<Role>
    {
        private HospitalSystemContext db;
        public RoleRepository(HospitalSystemContext context)
        {
            this.db = context;
        }
        public void Create(Role item)
        {
            db.Role.Add(item);
        }

        public void Delete(int id)
        {
            Role item = db.Role.Find(id);
            if (item != null)
                db.Role.Remove(item);
        }

        public IEnumerable<Role> Find(Func<Role, bool> predicate)
        {
            return db.Role.Where(predicate).ToList();
        }

        public Role Get(int id)
        {
            return db.Role.Find(id);
        }

        public IEnumerable<Role> GetAll()
        {
            return db.Role.ToList();
        }

        public void Update(Role item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}