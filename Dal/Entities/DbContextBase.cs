using System.Data;
using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;
using Dal.Entities;

namespace Dal
{

    public  partial class DbContextBase : DbContext
    {
        public DbContextBase(): base("name=MvcDemoEntities")
        {
            //Database.SetInitializer<MvcDemoEntities>(new DropCreateDatabaseAlways<MvcDemoEntities>());
            //Database.SetInitializer<MvcDemoEntities>(new CreateDatabaseIfNotExists<MvcDemoEntities>());
            //Database.SetInitializer<MvcDemoEntities>(new CreateDatabaseIfNotExists<MvcDemoEntities>());
            //Database.SetInitializer<MvcDemoEntities>(null);
            Database.SetInitializer(new SeedingDataInitializer());
        }

        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<City> Citys { get; set; }

        public virtual DbSet<Province> Provinces { get; set; }

        public virtual DbSet<Person> Persons { get; set; }

        public virtual DbSet<IDCard> IDCards { get; set; }

        public virtual DbSet<HeaderMenu> HeaderMenus { get; set; }

        public virtual DbSet<SideMenu> SideMenus { get; set; }

        public virtual DbSet<DetailAction> DetailAction { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // ���ö�Զ��ϵ��ļ���ɾ��
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }



        public void BeginTransaction(IsolationLevel iolationLevel= IsolationLevel.Unspecified)
        {
            if (Database.CurrentTransaction == null)
            {
                DbContextTransaction dbTrans=Database.BeginTransaction(iolationLevel);
            }
        }

        public void Commit()
        {
            DbContextTransaction transaction = Database.CurrentTransaction;
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
            }
        }
    }

    public class SeedingDataInitializer : CreateDatabaseIfNotExists<DbContextBase>
    {
        protected override void Seed(DbContextBase context)
        {
            context.Users.Add(new User()
            {
                 UserID="admin",
                 Name="����Ա",
                 Age=99,
                 Email="admin@qq.com",
                 Pwd="123456"
            });

            base.Seed(context);
        }
    }
}
