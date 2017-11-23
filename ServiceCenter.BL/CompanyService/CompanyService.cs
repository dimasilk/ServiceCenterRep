using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.BL.Interfaces;
using ServiceCenter.Auth.Models;
using ServiceCenter.BL.Mappings;
using LinqKit;

namespace ServiceCenter.BL.CompanyService
{
    public class CompanyService : ICompanyService
    {
        private readonly ApplicationDbContext _context;
        public CompanyService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Guid AddCompany(CompanyDTO company)
        {
            Company dataModel = new Company();
            company.CopyTo(dataModel);
            _context.Companies.Add(dataModel);
            _context.SaveChanges();
            return dataModel.Id;
        }

        public void DeleteCompany(Guid companyId)
        {
            var c = _context.Companies.AsExpandable().FirstOrDefault(x => x.Id == companyId);
            if (c != null)
            {
                _context.Companies.Remove(c);
                _context.SaveChanges();
            }
            return;
        }

        public CompanyDTO[] GetAllCompanies()
        {
            return _context.Companies.AsExpandable().Select(CompanyMapper.SelectExpression).ToArray();
        }

        public CompanyDTO GetCompanyById(Guid companyId)
        {
            return _context.Companies.Where(x => x.Id == companyId).Select(CompanyMapper.SelectExpression).FirstOrDefault();
        }

        public void UpdateCompany(CompanyDTO company)
        {
            Company dataModel = _context.Companies.FirstOrDefault(x => x.Id == company.Id);
            if (dataModel == null) return;
            company.CopyTo(dataModel);            
            _context.SaveChanges();
            return;
        }
    }
}
