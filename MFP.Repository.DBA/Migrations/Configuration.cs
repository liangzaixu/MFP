namespace MFP.Repository.Entities.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MFP.Repository.Entities.DbContextBase>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MFP.Repository.Entities.DbContextBase";
        }

        protected override void Seed(MFP.Repository.Entities.DbContextBase context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
