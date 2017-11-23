using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ServiceCenter.BL.Common.DTO;

namespace ServiceCenter.BL.Interfaces
{
    public interface IClientService
    {
        ClientDTO[] GetAllClients();
        void DeleteClient(Guid clientId);
        void UpdateClient(ClientDTO client);
        Guid AddClient(ClientDTO client);
        ClientDTO GetClientById(Guid clientId);
        //ClientDTO[] GetClientsByUserId(Guid userId);
    }
}
