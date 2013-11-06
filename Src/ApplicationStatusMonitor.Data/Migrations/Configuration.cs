using System.Collections.Generic;
using System.Net.Mime;
using ApplicationStatusMonitor.Model.Entities;

namespace ApplicationStatusMonitor.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationServiceDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationServiceDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var systemUser = "system";
            var createdOn = DateTime.Now;

            var ac1 = new Server
            {
                ServerName = "ESIHM1AC1",
                CreatedBy = systemUser,
                CreatedOn = createdOn,
                ModifiedBy = systemUser,
                ModifiedOn = createdOn

            };
            var ac2 = new Server
            {
                ServerName = "ESIHM1AC2",
                CreatedBy = systemUser,
                CreatedOn = createdOn,
                ModifiedBy = systemUser,
                ModifiedOn = createdOn
            };

            context.Server.AddOrUpdate(s => s.ServerName, ac1);
            context.Server.AddOrUpdate(s => s.ServerName, ac2);


            context.Application.AddOrUpdate(
                a => a.ApplicationName,
                new Application
                {
                    ApplicationName = "AWB", ApplicationDescription = "Analyst Workbench Applicaiton",
                    Services = new List<ApplicationService>
                    {
                        new ApplicationService
                        {
                            Server = ac1,
                            ServiceName = "AWB WCF Service",
                            ServiceDescription = "Application Pool that hosts all AWB Services",
                            CreatedBy = systemUser,
                            CreatedOn = createdOn,
                            ModifiedBy = systemUser,
                            ModifiedOn = createdOn
                        },
                        new ApplicationService
                        {
                            Server = ac1,
                            ServiceName = "RI Common WCF Service",
                            ServiceDescription = "Applicaiton Pool that host all RI Common Services",
                            CreatedBy = systemUser,
                            CreatedOn = createdOn,
                            ModifiedBy = systemUser,
                            ModifiedOn = createdOn
                        },
                        new ApplicationService
                        {
                            Server = ac2,
                            ServiceName = "AWB WCF Service",
                            ServiceDescription = "Application Pool that hosts all AWB Services",
                            CreatedBy = systemUser,
                            CreatedOn = createdOn,
                            ModifiedBy = systemUser,
                            ModifiedOn = createdOn
                        },
                        new ApplicationService
                        {
                            Server = ac2,
                            ServiceName = "RI Common WCF Service",
                            ServiceDescription = "Applicaiton Pool that host all RI Common Services",
                            CreatedBy = systemUser,
                            CreatedOn = createdOn,
                            ModifiedBy = systemUser,
                            ModifiedOn = createdOn

                        }
                    },
                    CreatedBy = systemUser,
                    CreatedOn = createdOn,
                    ModifiedBy = systemUser,
                    ModifiedOn = createdOn

                });

        }
    }
}
