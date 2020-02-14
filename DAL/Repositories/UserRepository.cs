using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class UserRepository : IRepositoryLong<User>
    {
        private HospitalSystemContext db;
        public UserRepository(HospitalSystemContext context)
        {
            this.db = context;
        }
        public void Create(User item)
        {
            db.User.Add(item);
        }

        public void Delete(long id)
        {
            User item = db.User.Find(id);
            if (item != null)
                db.User.Remove(item);
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return db.User.Where(predicate).ToList();
        }

        public User Get(long id)
        {
            return db.User.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.User.ToList();
        }

        public void Update(User item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}