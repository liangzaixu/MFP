using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Entities;

namespace Dal
{
    public class BaseRepository<T> where T : class, new()
    {
        public DbContextBase DbContext { get; private set; }

        private readonly DbSet<T> dbSet;

        public BaseRepository()
        {
            DbContext = DbContextFactory.GetDbContext();
            dbSet = DbContext.Set<T>();
        }

        public bool Insert(T entity)
        {
            dbSet.Add(entity);
            int result = DbContext.SaveChanges();
            return result > 0;
        }
    }

    //public bool Delete(string key)
    //    {
    //        return true;
    //    }

    //    public bool Update(T entity)
    //    {
    //        return true;
    //    }

       
    //}
}
