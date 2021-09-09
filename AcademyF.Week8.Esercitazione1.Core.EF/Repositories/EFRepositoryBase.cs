using AcademyF.Week8.Esercitazione1.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyF.Week8.Esercitazione1.Core.EF.Repositories
{
    public abstract class EFRepositoryBase<T> : IRepository<T>
        where T : class, IEntity, new()
    {
        
        public TicketDbContext Context { get; }

        public EFRepositoryBase(TicketDbContext context)
        {
            
            Context = context;
        }
        public bool Create(T entity)
        {
            if (entity == null)
                return false;
            GetDbSet().Add(entity);
            Context.SaveChanges();

            return true;

        }

        public abstract DbSet<T> GetDbSet();
        
        public bool Delete(int id)
        {
            if (id <= 0)
                return false;
            var item = GetDbSet().Find(id);

            if (item == null)
                return false;

            GetDbSet().Remove(item);
            Context.SaveChanges();

            return true;
        }

        public IEnumerable<T> Fetch(Func<T, bool> filter = null)
        {
            if (filter != null)
                return GetDbSet().Where(filter);

            return GetDbSet();
        }

        public T GetById(int id)
        {
            if (id <= 0)
                return null;
            return GetDbSet().Find(id);
        }

        public bool Update(T entity)
        {
            if (entity == null)
                return false;
            this.Context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.Context.SaveChanges();

            return true;
        }
    }
}
