namespace AndersonCRMContext.Migrations
{
    using AndersonCRMEntity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AndersonCRMContext.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AndersonCRMContext.Context context)
        {
            var company = context.Companies.FirstOrDefault(a => a.CompanyName == "AndersonGroup");
            if (company == null)
            {
                company = context.Companies.Add(
                   new ECompany
                   {
                       CompanyName = "AndersonGroup"
                   });
                context.SaveChanges();
            }
        }
    }
}
