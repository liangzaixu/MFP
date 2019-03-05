using System.Data;
using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;
using MFP.Repository.Entities.Entity;
using MFP.Repository.Entities.Map;
using System.Collections.Generic;
using System.Collections;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MFP.Repository.Entities
{


    public  partial class DbContextBase : IdentityDbContext<User,Role,string,UserLogin,UserRole,UserClaim>, IUnitOfWork
    {
        public DbContextBase(): base("name=DefaultConnection")
        {
            //Database.SetInitializer<MvcDemoEntities>(new DropCreateDatabaseAlways<MvcDemoEntities>());
            //Database.SetInitializer<MvcDemoEntities>(new CreateDatabaseIfNotExists<MvcDemoEntities>());
            //Database.SetInitializer<MvcDemoEntities>(new CreateDatabaseIfNotExists<MvcDemoEntities>());
            //Database.SetInitializer<MvcDemoEntities>(null);
            Database.SetInitializer(new SeedingDataInitializer());

        }

        public virtual DbSet<Log> Logs { get; set; }

        //public override IDbSet<User> Users { get; set; }

        //public virtual IDbSet<Role> Roles { get; set; }

        public virtual DbSet<City> Citys { get; set; }

        public virtual DbSet<Province> Provinces { get; set; }

        public virtual DbSet<Person> Persons { get; set; }

        public virtual DbSet<IDCard> IDCards { get; set; }

        public virtual DbSet<HeaderMenu> HeaderMenus { get; set; }

        public virtual DbSet<SideMenu> SideMenus { get; set; }

        public virtual DbSet<DetailAction> DetailAction { get; set; }

        //public virtual DbSet<RoleHeaderMenu> RoleHeaderMenu { get; set; }

        //public virtual DbSet<RoleSideMenu> RoleSideMenu { get; set; }

        //public virtual DbSet<RoleDetailAction> RoleDetailAction { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("User").HasKey(u => u.Id);
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<UserRole>().ToTable("UserRole");
            modelBuilder.Entity<UserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<UserClaim>().ToTable("UserClaim");



            // 禁用多对多关系表的级联删除
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new V_HeaderMenuMap());
            modelBuilder.Configurations.Add(new V_SideMenuMap());
            modelBuilder.Configurations.Add(new V_DetailActionMap());
            //modelBuilder.Configurations.Add(new RoleHeaderMenuMap());
            //modelBuilder.Configurations.Add(new RoleSideMenuMap());
            //modelBuilder.Configurations.Add(new RoleDetailActionMap());
            //modelBuilder.Configurations.Add(new UserRoleMap());
            //modelBuilder.Configurations.Add(new UserLoginMap());


        }
    }

    public partial class DbContextBase
    {
        public static DbContextBase Create()
        {
            return new DbContextBase();
        }

        public bool TransactionEnabled { get { return Database.CurrentTransaction != null; } }

        #region 方法
        public void BeginTransaction(IsolationLevel iolationLevel = IsolationLevel.Unspecified)
        {
            if (Database.CurrentTransaction == null)
            {
                DbContextTransaction dbTrans = Database.BeginTransaction(iolationLevel);
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
                finally
                {
                    transaction.Dispose();
                }
            }
        }

        /// <summary>
        /// 显式回滚事务，仅在显式开启事务后有用
        /// </summary>
        public void Rollback()
        {
            DbContextTransaction transaction = Database.CurrentTransaction;
            if(transaction!=null)
            {
                transaction.Rollback();
            }
        }


        /// <summary>
        /// 对数据库执行给定的 DDL/DML 命令。 
        /// 与接受 SQL 的任何 API 一样，对任何用户输入进行参数化以便避免 SQL 注入攻击是十分重要的。 您可以在 SQL 查询字符串中包含参数占位符，然后将参数值作为附加参数提供。 
        /// 您提供的任何参数值都将自动转换为 DbParameter。 unitOfWork.ExecuteSqlCommand("UPDATE dbo.Posts SET Rating = 5 WHERE Author = @p0", userSuppliedAuthor); 
        /// 或者，您还可以构造一个 DbParameter 并将它提供给 SqlQuery。 这允许您在 SQL 查询字符串中使用命名参数。 unitOfWork.ExecuteSqlCommand("UPDATE dbo.Posts SET Rating = 5 WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor));
        /// </summary>
        /// <param name="transactionalBehavior">对于此命令控制事务的创建。</param>
        /// <param name="sql">命令字符串。</param>
        /// <param name="parameters">要应用于命令字符串的参数。</param>
        /// <returns>执行命令后由数据库返回的结果。</returns>
        public int ExecuteSqlCommand(TransactionalBehavior transactionalBehavior, string sql, params object[] parameters)
        {
            return 0;
        }

        /// <summary>
        /// 创建一个原始 SQL 查询，该查询将返回给定泛型类型的元素。 类型可以是包含与从查询返回的列名匹配的属性的任何类型，也可以是简单的基元类型。 该类型不必是实体类型。
        ///  即使返回对象的类型是实体类型，上下文也决不会跟踪此查询的结果。 使用 SqlQuery(String, Object[]) 方法可返回上下文跟踪的实体。 
        /// 与接受 SQL 的任何 API 一样，对任何用户输入进行参数化以便避免 SQL 注入攻击是十分重要的。 您可以在 SQL 查询字符串中包含参数占位符，然后将参数值作为附加参数提供。 
        /// 您提供的任何参数值都将自动转换为 DbParameter。 unitOfWork.SqlQuery&lt;Post&gt;("SELECT * FROM dbo.Posts WHERE Author = @p0", userSuppliedAuthor); 
        /// 或者，您还可以构造一个 DbParameter 并将它提供给 SqlQuery。 这允许您在 SQL 查询字符串中使用命名参数。 unitOfWork.SqlQuery&lt;Post&gt;("SELECT * FROM dbo.Posts WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor));
        /// </summary>
        /// <typeparam name="TElement">查询所返回对象的类型。</typeparam>
        /// <param name="sql">SQL 查询字符串。</param>
        /// <param name="parameters">要应用于 SQL 查询字符串的参数。 如果使用输出参数，则它们的值在完全读取结果之前不可用。 这是由于 DbDataReader 的基础行为而导致的，有关详细信息，请参见 http://go.microsoft.com/fwlink/?LinkID=398589。</param>
        /// <returns></returns>
        public IEnumerable<T> SqlQuery<T>(string sql, params object[] parameters)
        {
          return null;
        }

        /// <summary>
        /// 创建一个原始 SQL 查询，该查询将返回给定类型的元素。 类型可以是包含与从查询返回的列名匹配的属性的任何类型，也可以是简单的基元类型。 该类型不必是实体类型。 
        /// 即使返回对象的类型是实体类型，上下文也决不会跟踪此查询的结果。 
        /// 使用 SqlQuery(String, Object[]) 方法可返回上下文跟踪的实体。 与接受 SQL 的任何 API 一样，对任何用户输入进行参数化以便避免 SQL 注入攻击是十分重要的。 
        /// 您可以在 SQL 查询字符串中包含参数占位符，然后将参数值作为附加参数提供。 
        /// 您提供的任何参数值都将自动转换为 DbParameter。 context.Database.SqlQuery(typeof(Post), "SELECT * FROM dbo.Posts WHERE Author = @p0", userSuppliedAuthor); 
        /// 或者，您还可以构造一个 DbParameter 并将它提供给 SqlQuery。 这允许您在 SQL 查询字符串中使用命名参数。 context.Database.SqlQuery(typeof(Post), "SELECT * FROM dbo.Posts WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor));
        /// </summary>
        /// <param name="elementType">查询所返回对象的类型。</param>
        /// <param name="sql">SQL 查询字符串。</param>
        /// <param name="parameters">要应用于 SQL 查询字符串的参数。 如果使用输出参数，则它们的值在完全读取结果之前不可用。 这是由于 DbDataReader 的基础行为而导致的，有关详细信息，请参见 http://go.microsoft.com/fwlink/?LinkID=398589。</param>
        /// <returns></returns>
        public IEnumerable SqlQuery(Type elementType, string sql, params Object[] parameters)
        {
            return null;
        }


        //#if NET45

        //        /// <summary>
        //        /// 对数据库执行给定的 DDL/DML 命令。 
        //        /// 与接受 SQL 的任何 API 一样，对任何用户输入进行参数化以便避免 SQL 注入攻击是十分重要的。 您可以在 SQL 查询字符串中包含参数占位符，然后将参数值作为附加参数提供。 
        //        /// 您提供的任何参数值都将自动转换为 DbParameter。 unitOfWork.ExecuteSqlCommand("UPDATE dbo.Posts SET Rating = 5 WHERE Author = @p0", userSuppliedAuthor); 
        //        /// 或者，您还可以构造一个 DbParameter 并将它提供给 SqlQuery。 这允许您在 SQL 查询字符串中使用命名参数。 unitOfWork.ExecuteSqlCommand("UPDATE dbo.Posts SET Rating = 5 WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor));
        //        /// </summary>
        //        /// <param name="transactionalBehavior">对于此命令控制事务的创建。</param>
        //        /// <param name="sql">命令字符串。</param>
        //        /// <param name="paramters">要应用于命令字符串的参数。</param>
        //        /// <returns>执行命令后由数据库返回的结果。</returns>
        //        Task<int> ExecuteSqlCommandAsync(TransactionalBehavior transactionalBehavior, string sql, params object[] paramters);

        //        /// <summary>
        //        /// 异步提交当前单元操作的更改。
        //        /// </summary>
        //        /// <returns>操作影响的行数</returns>
        //        Task<int> SaveChangesAsync();

        //#endif

        #endregion
    }

    public class SeedingDataInitializer : CreateDatabaseIfNotExists<DbContextBase>
    {
        protected override void Seed(DbContextBase context)
        {
            context.Users.Add(new User()
            {
                 AccountId="admin",
                 UserName="管理员",
                 Age=99,
                 Email="admin@qq.com",
                 PasswordHash="123456"
            });

            //string drop = @"DROP TABLE V_HeaderMenu;
            //                DROP TABLE V_SideMenu;
            //                DROP TABLE V_DetailAction";

            //context.Database.ExecuteSqlCommand(drop);

            //string createV_HeaderMenu= @"CREATE VIEW [dbo].[V_HeaderMenu]
            //                        AS
            //                        SELECT     RU.UserID , RHM.RoleID AS RoleID, HM.MenuID, HM.MenuName, HM.Url,HM.IconUrl, HM.MenuOrder
            //                        FROM         dbo.RoleHeaderMenu AS RHM INNER JOIN
            //                                              dbo.HeaderMenu AS HM ON RHM.MenuID = HM.MenuID INNER JOIN
            //                                              dbo.RoleUser AS RU ON RHM.RoleID = RU.RoleID;";
            //string createV_SideMenu = @"
            //                        CREATE VIEW [dbo].[V_SideMenu]
            //                        AS
            //                        SELECT     RU.UserID , RSM.RoleID AS RoleID, SM.MenuID, SM.MenuName, SM.Url,SM.IconUrl, SM.HeaderMenuID, SM.ParentID, SM.MenuOrder,
            //                                   (CASE WHEN EXISTS ( select TOP 1 1 from SideMenu AS CSM where CSM.ParentID=SM.MenuID)  THEN 1 ELSE 0 END) AS HasChildren
            //                        FROM         dbo.RoleSideMenu AS RSM INNER JOIN
            //                                              dbo.SideMenu AS SM ON RSM.MenuID = SM.MenuID INNER JOIN
            //                                              dbo.RoleUser AS RU ON RU.RoleID = RSM.RoleID";
            //string createV_DetailAction = @"
            //                        CREATE VIEW [dbo].[V_DetailAction ]
            //                        AS
            //                        SELECT     RU.UserID, RU.RoleID, DA.ActionID, DA.ActionName, DA.Title, DA.SideMenuID
            //                        FROM         dbo.DetailAction AS DA INNER JOIN
            //                                              dbo.RoleDetailAction AS RDA ON DA.ActionID = RDA.ActionID LEFT OUTER JOIN
            //                                              dbo.RoleUser AS RU ON RDA.RoleID = RU.RoleID";

            //context.Database.ExecuteSqlCommand(createV_HeaderMenu);
            //context.Database.ExecuteSqlCommand(createV_SideMenu);
            //context.Database.ExecuteSqlCommand(createV_DetailAction);

            base.Seed(context);
        }
    }


}
