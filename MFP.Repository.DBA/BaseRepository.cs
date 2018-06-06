using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFP.Repository.DBA
{
    public class BaseRepository<T> where T : class, new()
    {
        public DbContextBase DbContext { get; private set; }

        private readonly DbSet<T> dbSet;

        public IQueryable<T> Entities
        {
            get { return dbSet.AsNoTracking(); }
        }

        public BaseRepository()
        {
            DbContext = DbContextFactory.GetDbContext();
            dbSet = DbContext.Set<T>();
        }

        public T GetByKey(string key)
        {
            return dbSet.Find(key);
        }

        public bool Insert(T entity)
        {
            dbSet.Add(entity);
            int result = DbContext.SaveChanges();
            return result > 0;
        }

        public bool Insert(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
            int result = DbContext.SaveChanges();
            return result > 0;
        }

        public bool Delete(string key)
        {
            T entity = dbSet.Find(key);
            return Delete(entity);
        }

        public bool Delete(T entity)
        {
            int num = 0;
            
            if (entity != null)
            {
                dbSet.Remove(entity);
                num = DbContext.SaveChanges();
            }
            return num > 0;
        }

        public bool Delete(Func<T,bool> predicate)
        {
            return false;
            dbSet.Where(predicate).ToArray();

        }

        public bool Update(T entity, string[] proNames=null)
        {
            int num = 0;
            DbEntityEntry entry = DbContext.Entry<T>(entity);
            if (proNames != null)
            {
                entry.State = EntityState.Unchanged;
                foreach (string proName in proNames)
                {
                    entry.Property(proName).IsModified = true;
                }
            }
            else
            {
                if (entry.State == EntityState.Detached)
                {
                    dbSet.Attach(entity);
                    entry.State = EntityState.Modified;
                }
            }
            return num>0;
        }

        public bool IsExists(string key)
        {
            return GetByKey(key) != (T) null;
        }
    }
}
