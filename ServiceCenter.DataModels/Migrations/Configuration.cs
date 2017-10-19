namespace ServiceCenter.DataModels.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ServiceCenter.DataModels.ServiceCenterContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ServiceCenter.DataModels.ServiceCenterContext";
        }

        protected override void Seed(ServiceCenter.DataModels.ServiceCenterContext context)
        {
            
        }
    }
}
