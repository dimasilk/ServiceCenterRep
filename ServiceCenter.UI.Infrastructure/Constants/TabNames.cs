using ServiceCenter.UI.Infrastructure.Attributes;

namespace ServiceCenter.UI.Infrastructure.Constants
{
    public static class TabNames
    {
        [ShowOnStartup]
        [ModuleInfo("OrderModule")]
        public const string OrdersTab = "Orders";
        [ModuleInfo("CustomerModule")]
        public const string CustomersTab = "Customers";
        [ModuleInfo("CompanyModule")]
        public const string CompaniesTab = "Companies";
    }
}
