using System.Data;
using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;
using MFP.Repository.DBA.Entity;
using MFP.Repository.DBA.Map;

namespace MFP.Repository.DBA
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

        public virtual DbSet<RoleHeaderMenu> RoleHeaderMenu { get; set; }

        public virtual DbSet<RoleSideMenu> RoleSideMenu { get; set; }

        public virtual DbSet<RoleDetailAction> RoleDetailAction { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // 禁用多对多关系表的级联删除
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new V_HeaderMenuMap());
            modelBuilder.Configurations.Add(new V_SideMenuMap());
            //modelBuilder.Configurations.Add(new V_DetailActionMap());
            modelBuilder.Configurations.Add(new RoleHeaderMenuMap());
            modelBuilder.Configurations.Add(new RoleSideMenuMap());
            modelBuilder.Configurations.Add(new RoleDetailActionMap());

            base.OnModelCreating(modelBuilder);
            //modelBuilder.Configurations.
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

    public class SeedingDataInitializer : DropCreateDatabaseAlways<DbContextBase>
    {
        protected override void Seed(DbContextBase context)
        {
            context.Users.Add(new User()
            {
                 UserID="admin",
                 Name="管理员",
                 Age=99,
                 Email="admin@qq.com",
                 Pwd="123456"
            });

            string drop = @"DROP TABLE V_HeaderMenu;
                            DROP TABLE V_SideMenu;";

            context.Database.ExecuteSqlCommand(drop);

            string createV_HeaderMenu= @"CREATE VIEW [dbo].[V_HeaderMenu]
                                    AS
                                    SELECT     UR.User_UserID AS UserID, RHM.Role_RoleID AS RoleID, HM.MenuID, HM.MenuName, HM.Url, HM.MenuOrder
                                    FROM         dbo.RoleHeaderMenu AS RHM INNER JOIN
                                                          dbo.HeaderMenu AS HM ON RHM.MenuID = HM.MenuID INNER JOIN
                                                          dbo.UserRoles AS UR ON RHM.RoleID = UR.RoleID;";
            string createV_SideMenu = @"
                                    CREATE VIEW [dbo].[V_SideMenu]
                                    AS
                                    SELECT     UR.User_UserID AS UserID, RSM.Role_RoleID AS RoleID, SM.MenuID, SM.MenuName, SM.Url, SM.HeaderMenuID, SM.ParentID, SM.MenuOrder
                                    FROM         dbo.RoleSideMenu AS RSM INNER JOIN
                                                          dbo.SideMenu AS SM ON RSM.MenuID = SM.MenuID INNER JOIN
                                                          dbo.UserRoles AS UR ON UR.RoleID = RSM.RoleID";

            context.Database.ExecuteSqlCommand(createV_HeaderMenu);
            context.Database.ExecuteSqlCommand(createV_SideMenu);


            //context.Database.ExecuteSqlCommand("");

            base.Seed(context);
        }
    }
}
