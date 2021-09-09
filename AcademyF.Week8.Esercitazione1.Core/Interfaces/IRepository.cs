using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyF.Week8.Esercitazione1.Core.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> Fetch(Func<T, bool> filter = null);
        T GetById(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }
}
