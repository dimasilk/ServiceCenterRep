using ServiceCenter.BL.Common.DTO;

namespace ServiceCenter.UI.CompanyModule.ViewModel
{
    public class CompanyItemViewModel
    {
        public CompanyItemViewModel(CompanyDTO companyDto)
        {
            Item = companyDto;
        }
        public CompanyDTO Item { get; set; }
    }
}
