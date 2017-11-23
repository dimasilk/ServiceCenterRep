using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.BL.Interfaces;
using ServiceCenter.BL.Tests.Common;
using Unity;

namespace ServiceCenter.BL.Tests.CustomersTest
{
    [TestClass]
    public class CompanyTest : BaseTestClass
    {
        private readonly CompanyDTO _companyDTO =
            new CompanyDTO()
            {
                Adress = "111",
                Info = "qwer",
                Name = "BIR",
                Phone = "+375295621001"
            };

        [TestMethod]
        public void ShouldAddUpdateAndDeleteCompany()
        {
            var service = Container.Resolve<ICompanyService>();
            
            var id = service.AddCompany(_companyDTO);
            Assert.IsTrue(id != null);
            var company = service.GetCompanyById(id);
            Assert.AreEqual(company.Info, _companyDTO.Info);
            Assert.AreEqual(company.Name, _companyDTO.Name);
            Assert.AreEqual(company.Phone, _companyDTO.Phone);
            Assert.AreEqual(company.Adress, _companyDTO.Adress);

            company.Info = company.Info + company.Info;
            company.Name = company.Name + company.Name;
            company.Phone = company.Phone + company.Phone;
            company.Adress = company.Adress + company.Adress;
            service.UpdateCompany(company);

            var updated = service.GetCompanyById(id);
            Assert.AreNotEqual(updated.Info, _companyDTO.Info);
            Assert.AreNotEqual(updated.Name, _companyDTO.Name);
            Assert.AreNotEqual(updated.Phone, _companyDTO.Phone);
            Assert.AreNotEqual(updated.Adress, _companyDTO.Adress);

            service.DeleteCompany(updated.Id);
            company = service.GetCompanyById(id);
            Assert.IsNull(company);
        }
        [TestMethod]
        public void ShouldGetAllCompanies()
        {
            var service = Container.Resolve<ICompanyService>();
            var a = service.AddCompany(_companyDTO);
            var b = service.AddCompany(_companyDTO);
            var c = service.GetAllCompanies();
            Assert.IsTrue(c.Length > 1);
            service.DeleteCompany(a);
            service.DeleteCompany(b);
        }



    }
}



