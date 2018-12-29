namespace GisysArbetsprov.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GisysArbetsprov.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(GisysArbetsprov.Models.ApplicationDbContext context)
        {
            context.ConsultInformations.AddOrUpdate(x => x.Id,
        new ConsultInformation()
        {
            Id = 1,
            Name = "Robert",
            Hours = 160,
            YearsOfEmployment = new DateTime(2017, 10, 01)
        },
        new ConsultInformation()
        {
            Id = 2,
            Name = "Abel",
            Hours = 150,
            YearsOfEmployment = new DateTime(2015, 05, 08)
        });
        }
    }
}
