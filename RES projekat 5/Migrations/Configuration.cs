namespace RES_projekat_5.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    [ExcludeFromCodeCoverage] //Deo UI-a
    internal sealed class Configuration : DbMigrationsConfiguration<RES_projekat_5.Model.Izvestaji>
    {
  
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RES_projekat_5.Model.Izvestaji context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
