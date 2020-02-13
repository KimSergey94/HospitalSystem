using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRepositoryLong<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        IEnumerable<T> Find(Func<T, Boolean> predicate); void Create(T item);
        void Update(T item);
        void Delete(long id);
    }
}
