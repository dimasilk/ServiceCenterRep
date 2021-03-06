﻿using System;
using System.Linq;
using LinqKit;
using ServiceCenter.Auth.Models;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.BL.Interfaces;
using ServiceCenter.BL.Mappings;

namespace ServiceCenter.BL.CustomerService
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

        public CompanyDTO[] GetCompaniesByFilter(CompanyFilterDTO filter)
        {
            var query = _context.Companies.AsExpandable();
            if (!string.IsNullOrEmpty(filter.Name)) query = query.Where(x => x.Name.Contains(filter.Name));
            if (!string.IsNullOrEmpty(filter.Info)) query = query.Where(x => x.Info.Contains(filter.Info));
            if (!string.IsNullOrEmpty(filter.Phone)) query = query.Where(x => x.Phone.Contains(filter.Phone));
            if (!string.IsNullOrEmpty(filter.Adress)) query = query.Where(x => x.Adress.Contains(filter.Adress));

            return query.Select(CompanyMapper.SelectExpression).ToArray();
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
