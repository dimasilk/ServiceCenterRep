using System;
using System.Linq;
using LinqKit;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.BL.Interfaces;
using ServiceCenter.Auth.Models;
using ServiceCenter.BL.Mappings;

namespace ServiceCenter.BL.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;
        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Guid AddCustomer(CustomerDTO client)
        {
            Customer dataModel = new Customer();
            client.CopyTo(dataModel);
            _context.Customers.Add(dataModel);
            _context.SaveChanges();
            return dataModel.Id;
        }

        public void DeleteCustomer(Guid clientId)
        {
            var c = _context.Customers.AsExpandable().FirstOrDefault(x => x.Id == clientId);
            if (c != null)
            {
                _context.Customers.Remove(c);
                _context.SaveChanges();
            }
            return;
        }

        public CustomerDTO[] GetAllCustomers()
        {
            return _context.Customers.AsExpandable().Select(CustomerMapper.SelectExpression).ToArray();
        }

        public CustomerDTO GetCustomerById(Guid clientId)
        {
            return _context.Customers.Where(x => x.Id == clientId).Select(CustomerMapper.SelectExpression).FirstOrDefault();
        }

        public void UpdateCustomer(CustomerDTO client)
        {
            Customer dataModel = _context.Customers.FirstOrDefault(x => x.Id == client.Id);
            if (dataModel == null) return;
            client.CopyTo(dataModel);
            _context.SaveChanges();
            return;
        }
    }
}
