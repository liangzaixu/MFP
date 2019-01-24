using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MFP.Repository.Entities
{
    public class DbContextFactory
    {
        public static DbContextBase GetDbContext()
        {
            DbContextBase dbContext = HttpContext.Current.Items["dbContext"] as DbContextBase;
            if (dbContext == null)
            {
                dbContext = new DbContextBase();
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

        public static void BeginTransaction(IsolationLevel iolationLevel = IsolationLevel.Unspecified)
        {
            DbContextBase dbContext = DbContextFactory.GetDbContext();
            DbContextTransaction transaction = dbContext.Database.CurrentTransaction;
            if (transaction == null)
            {
                dbContext.Database.BeginTransaction(iolationLevel);
            }
        }

        public static void CommitTransaction()
        {
            DbContextTransaction transaction = DbContextFactory.GetDbContext().Database.CurrentTransaction;
            if (transaction != null)
            {
                try
                {
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    transaction.Dispose();
                }
            }
        }

        public static int GetConnectionState()
        {
            DbContextBase dbContext = DbContextFactory.GetDbContext();
            ConnectionState state = dbContext.Database.Connection.State;
            return (int) state;
        }

        public static void CloseConnection()
        {
            DbContextBase dbContext = DbContextFactory.GetDbContext();
            dbContext.Database.Connection.Close();
        }
    }
}
