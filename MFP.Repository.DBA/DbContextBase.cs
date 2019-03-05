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



            // ���ö�Զ��ϵ��ļ���ɾ��
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

        #region ����
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
        /// ��ʽ�ع����񣬽�����ʽ�������������
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
        /// �����ݿ�ִ�и����� DDL/DML ��� 
        /// ����� SQL ���κ� API һ�������κ��û�������в������Ա���� SQL ע�빥����ʮ����Ҫ�ġ� �������� SQL ��ѯ�ַ����а�������ռλ����Ȼ�󽫲���ֵ��Ϊ���Ӳ����ṩ�� 
        /// ���ṩ���κβ���ֵ�����Զ�ת��Ϊ DbParameter�� unitOfWork.ExecuteSqlCommand("UPDATE dbo.Posts SET Rating = 5 WHERE Author = @p0", userSuppliedAuthor); 
        /// ���ߣ��������Թ���һ�� DbParameter �������ṩ�� SqlQuery�� ���������� SQL ��ѯ�ַ�����ʹ������������ unitOfWork.ExecuteSqlCommand("UPDATE dbo.Posts SET Rating = 5 WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor));
        /// </summary>
        /// <param name="transactionalBehavior">���ڴ������������Ĵ�����</param>
        /// <param name="sql">�����ַ�����</param>
        /// <param name="parameters">ҪӦ���������ַ����Ĳ�����</param>
        /// <returns>ִ������������ݿⷵ�صĽ����</returns>
        public int ExecuteSqlCommand(TransactionalBehavior transactionalBehavior, string sql, params object[] parameters)
        {
            return 0;
        }

        /// <summary>
        /// ����һ��ԭʼ SQL ��ѯ���ò�ѯ�����ظ����������͵�Ԫ�ء� ���Ϳ����ǰ�����Ӳ�ѯ���ص�����ƥ������Ե��κ����ͣ�Ҳ�����Ǽ򵥵Ļ�Ԫ���͡� �����Ͳ�����ʵ�����͡�
        ///  ��ʹ���ض����������ʵ�����ͣ�������Ҳ��������ٴ˲�ѯ�Ľ���� ʹ�� SqlQuery(String, Object[]) �����ɷ��������ĸ��ٵ�ʵ�塣 
        /// ����� SQL ���κ� API һ�������κ��û�������в������Ա���� SQL ע�빥����ʮ����Ҫ�ġ� �������� SQL ��ѯ�ַ����а�������ռλ����Ȼ�󽫲���ֵ��Ϊ���Ӳ����ṩ�� 
        /// ���ṩ���κβ���ֵ�����Զ�ת��Ϊ DbParameter�� unitOfWork.SqlQuery&lt;Post&gt;("SELECT * FROM dbo.Posts WHERE Author = @p0", userSuppliedAuthor); 
        /// ���ߣ��������Թ���һ�� DbParameter �������ṩ�� SqlQuery�� ���������� SQL ��ѯ�ַ�����ʹ������������ unitOfWork.SqlQuery&lt;Post&gt;("SELECT * FROM dbo.Posts WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor));
        /// </summary>
        /// <typeparam name="TElement">��ѯ�����ض�������͡�</typeparam>
        /// <param name="sql">SQL ��ѯ�ַ�����</param>
        /// <param name="parameters">ҪӦ���� SQL ��ѯ�ַ����Ĳ����� ���ʹ����������������ǵ�ֵ����ȫ��ȡ���֮ǰ�����á� �������� DbDataReader �Ļ�����Ϊ�����µģ��й���ϸ��Ϣ����μ� http://go.microsoft.com/fwlink/?LinkID=398589��</param>
        /// <returns></returns>
        public IEnumerable<T> SqlQuery<T>(string sql, params object[] parameters)
        {
          return null;
        }

        /// <summary>
        /// ����һ��ԭʼ SQL ��ѯ���ò�ѯ�����ظ������͵�Ԫ�ء� ���Ϳ����ǰ�����Ӳ�ѯ���ص�����ƥ������Ե��κ����ͣ�Ҳ�����Ǽ򵥵Ļ�Ԫ���͡� �����Ͳ�����ʵ�����͡� 
        /// ��ʹ���ض����������ʵ�����ͣ�������Ҳ��������ٴ˲�ѯ�Ľ���� 
        /// ʹ�� SqlQuery(String, Object[]) �����ɷ��������ĸ��ٵ�ʵ�塣 ����� SQL ���κ� API һ�������κ��û�������в������Ա���� SQL ע�빥����ʮ����Ҫ�ġ� 
        /// �������� SQL ��ѯ�ַ����а�������ռλ����Ȼ�󽫲���ֵ��Ϊ���Ӳ����ṩ�� 
        /// ���ṩ���κβ���ֵ�����Զ�ת��Ϊ DbParameter�� context.Database.SqlQuery(typeof(Post), "SELECT * FROM dbo.Posts WHERE Author = @p0", userSuppliedAuthor); 
        /// ���ߣ��������Թ���һ�� DbParameter �������ṩ�� SqlQuery�� ���������� SQL ��ѯ�ַ�����ʹ������������ context.Database.SqlQuery(typeof(Post), "SELECT * FROM dbo.Posts WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor));
        /// </summary>
        /// <param name="elementType">��ѯ�����ض�������͡�</param>
        /// <param name="sql">SQL ��ѯ�ַ�����</param>
        /// <param name="parameters">ҪӦ���� SQL ��ѯ�ַ����Ĳ����� ���ʹ����������������ǵ�ֵ����ȫ��ȡ���֮ǰ�����á� �������� DbDataReader �Ļ�����Ϊ�����µģ��й���ϸ��Ϣ����μ� http://go.microsoft.com/fwlink/?LinkID=398589��</param>
        /// <returns></returns>
        public IEnumerable SqlQuery(Type elementType, string sql, params Object[] parameters)
        {
            return null;
        }


        //#if NET45

        //        /// <summary>
        //        /// �����ݿ�ִ�и����� DDL/DML ��� 
        //        /// ����� SQL ���κ� API һ�������κ��û�������в������Ա���� SQL ע�빥����ʮ����Ҫ�ġ� �������� SQL ��ѯ�ַ����а�������ռλ����Ȼ�󽫲���ֵ��Ϊ���Ӳ����ṩ�� 
        //        /// ���ṩ���κβ���ֵ�����Զ�ת��Ϊ DbParameter�� unitOfWork.ExecuteSqlCommand("UPDATE dbo.Posts SET Rating = 5 WHERE Author = @p0", userSuppliedAuthor); 
        //        /// ���ߣ��������Թ���һ�� DbParameter �������ṩ�� SqlQuery�� ���������� SQL ��ѯ�ַ�����ʹ������������ unitOfWork.ExecuteSqlCommand("UPDATE dbo.Posts SET Rating = 5 WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor));
        //        /// </summary>
        //        /// <param name="transactionalBehavior">���ڴ������������Ĵ�����</param>
        //        /// <param name="sql">�����ַ�����</param>
        //        /// <param name="paramters">ҪӦ���������ַ����Ĳ�����</param>
        //        /// <returns>ִ������������ݿⷵ�صĽ����</returns>
        //        Task<int> ExecuteSqlCommandAsync(TransactionalBehavior transactionalBehavior, string sql, params object[] paramters);

        //        /// <summary>
        //        /// �첽�ύ��ǰ��Ԫ�����ĸ��ġ�
        //        /// </summary>
        //        /// <returns>����Ӱ�������</returns>
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
                 UserName="����Ա",
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
