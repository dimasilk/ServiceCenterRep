using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.BL.Interfaces;
using ServiceCenter.Auth.Models;

namespace ServiceCenter.BL.CustomerService
{
    public class CustomerService : IClientService
    {
        private readonly ApplicationDbContext _context;
        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Guid AddClient(ClientDTO client)
        {
            throw new NotImplementedException();
        }

        public void DeleteClient(Guid clientId)
        {
            throw new NotImplementedException();
        }

        public ClientDTO[] GetAllClients()
        {
            throw new NotImplementedException();
        }

        public ClientDTO GetClientById(Guid clientId)
        {
            throw new NotImplementedException();
        }

        public void UpdateClient(ClientDTO client)
        {
            throw new NotImplementedException();
        }
    }
}
