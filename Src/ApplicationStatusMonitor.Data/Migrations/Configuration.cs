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

            var environments = new List<Model.Entities.Environment>
            {
                new Model.Entities.Environment {EnvironmentName = "Development"},
                new Model.Entities.Environment {EnvironmentName = "System Test"},
                new Model.Entities.Environment {EnvironmentName = "Prod Mirror"},
                new Model.Entities.Environment {EnvironmentName = "Production "}
            };
            environments.ForEach(env => context.Environment.AddOrUpdate(e => e.EnvironmentName, env));
            context.SaveChanges();

            var serviceTypes = new List<ServiceType>
            {
                new ServiceType {ServiceTypeName = "Windows"},
                new ServiceType {ServiceTypeName = "AppPool"}
            };
            serviceTypes.ForEach(s => context.ServiceType.AddOrUpdate(st => st.ServiceTypeName, s));
            context.SaveChanges();

            var systemUser = "system";
            var createdOn = DateTime.Now;

            var servers = new List<Server>
            {
                new Server
                {
                    ServerName = "ESIHM1AP6",
                    CreatedBy = systemUser,
                    CreatedOn = createdOn,
                    ModifiedBy = systemUser,
                    ModifiedOn = createdOn
                },
                new Server
                {
                    ServerName = "TSTHM1AP7",
                    CreatedBy = systemUser,
                    CreatedOn = createdOn,
                    ModifiedBy = systemUser,
                    ModifiedOn = createdOn
                },
                new Server
                {
                    ServerName = "TSTHM1BIZDEV1",
                    CreatedBy = systemUser,
                    CreatedOn = createdOn,
                    ModifiedBy = systemUser,
                    ModifiedOn = createdOn
                }
            };
            servers.ForEach(s => context.Server.AddOrUpdate(sv => sv.ServerName, s));
            context.SaveChanges();

            context.Application.AddOrUpdate(
                a => a.ApplicationName,
                new Application
                {
                    ApplicationName = "AWB", ApplicationDescription = "Analyst Workbench Applicaiton",
                    Services = new List<ApplicationService>
                    {
                        new ApplicationService
                        {
                            Server = context.Server.Single(s => s.ServerName == "ESIHM1AP6"),
                            ServiceName = "AWB WCF Service",
                            ServiceDescription = "Application Pool that hosts all AWB Services",
                            CreatedBy = systemUser,
                            CreatedOn = createdOn,
                            ModifiedBy = systemUser,
                            ModifiedOn = createdOn
                        },
                        new ApplicationService
                        {
                            Server = context.Server.Single(s => s.ServerName == "ESIHM1AP6"),
                            ServiceName = "RI Common WCF Service",
                            ServiceDescription = "Application Pool that host all RI Common Services",
                            CreatedBy = systemUser,
                            CreatedOn = createdOn,
                            ModifiedBy = systemUser,
                            ModifiedOn = createdOn
                        },
                        new ApplicationService
                        {
                            Server = context.Server.Single(s => s.ServerName == "TSTHM1AP7"),
                            ServiceName = "AWB WCF Service",
                            ServiceDescription = "Application Pool that hosts all AWB Services",
                            CreatedBy = systemUser,
                            CreatedOn = createdOn,
                            ModifiedBy = systemUser,
                            ModifiedOn = createdOn
                        },
                        new ApplicationService
                        {
                            Server = context.Server.Single(s => s.ServerName == "TSTHM1AP7"),
                            ServiceName = "RI Common WCF Service",
                            ServiceDescription = "Applicaiton Pool that host all RI Common Services",
                            CreatedBy = systemUser,
                            CreatedOn = createdOn,
                            ModifiedBy = systemUser,
                            ModifiedOn = createdOn
                        }
                    },
                    Environment = context.Environment.Single(e => e.EnvironmentName == "System Test"),
                    CreatedBy = systemUser,
                    CreatedOn = createdOn,
                    ModifiedBy = systemUser,
                    ModifiedOn = createdOn
                });
            context.SaveChanges();

            context.Application.AddOrUpdate(a => a.ApplicationName,
                new Application
                {
                    ApplicationName = "Polaris BizTalk",
                    ApplicationDescription = "Polaris BizTalk Genius Integration Server",
                    Environment = context.Environment.Single(e => e.EnvironmentName == "Development"),
                    Services = new List<ApplicationService>
                    {
                        new ApplicationService
                        {
                            Server = context.Server.Single(s => s.ServerName == "TSTHM1BIZDEV1"),
                            ServiceName = "BTSSvc$BizTalkServerApplication",
                            ServiceDescription = "Polaris Development BizTalk Service",
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
