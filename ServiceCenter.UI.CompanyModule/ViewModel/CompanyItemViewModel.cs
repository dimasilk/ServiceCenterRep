using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
