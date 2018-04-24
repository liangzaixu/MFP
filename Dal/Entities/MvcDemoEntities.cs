

namespace Dal
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<Log>()
                .Property(e => e.IP)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Pwd)
                .IsUnicode(false);

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
