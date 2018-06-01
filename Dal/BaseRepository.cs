using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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

        public bool Update(T entity,params string[] proNames)
        {
            DbEntityEntry entry = DbContext.Entry<T>(entity);
            //4.2先设置 对象的包装为Unchanged
            entry.State = EntityState.Unchanged;
            //4.3循环 被修改的属性名 数组
            if()

            foreach (string proName in proNames)
            {
                //4.4将每个 被修改的属性的状态 设置为已修改状态;后面生成update语句时，就只为已修改的属性 更新
                entry.Property(proName).IsModified = true;
            }
            return true;
        }

        public bool IsExists(string key)
        {
            return GetByKey(key) != (T) null;
        }




    }
}
