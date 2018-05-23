using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Dal.Entities
{
    public class DbContextFactory
    {
        public static DbContext GetDbContext()
        {
            DbContext dbContext = HttpContext.Current.Items["dbContext"] as DbContext;
            if (dbContext == null)
            {
                dbContext = new MvcDemoEntities();
                HttpContext.Current.Items["dbContext"] = dbContext;
            }
            return dbContext;
        }
    }
    public class DbSession
    {
        public static int SaveChanges()
        {
            return DbContextFactory.GetDbContext().SaveChanges();
        }
    }
}
