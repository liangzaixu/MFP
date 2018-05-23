

namespace Dal.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class MvcDemoEntities : DbContext
    {
        public MvcDemoEntities(): base("name=MvcDemoEntities")
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

            // 禁用多对多关系表的级联删除
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }

    public class SeedingDataInitializer : DropCreateDatabaseAlways<MvcDemoEntities>
    {
        protected override void Seed(MvcDemoEntities context)
        {
            context.Users.Add(new User()
            {
                 UserID="admin",
                 Name="管理员",
                 Age=99,
                 Email="admin@qq.com",
                 Pwd="123456"
            });

            base.Seed(context);
        }
    }
}
