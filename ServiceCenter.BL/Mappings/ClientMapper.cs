using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceCenter.Auth.Models;
using ServiceCenter.BL.Common.DTO;
using System.Linq.Expressions;

namespace ServiceCenter.BL.Mappings
{
    public static class ClientMapper
    {
        public static void CopyTo(this ClientDTO dto, Client dataModel)
        {
            dataModel.Id = dto.Id;
            dataModel.FullName = dto.FullName;
            dataModel.Info = dto.Info;            
            dataModel.Phone = dataModel.Phone;
            //dataModel.Orders = 
            dataModel.Orders.Clear();
            
        }

        public static readonly Expression<Func<Client, ClientDTO>> SelectExpression = u => new ClientDTO
        {
            Id = u.Id,
            Info = u.Info,
            //Orders = 
            FullName = u.FullName,
            Phone = u.Phone
        };
    }
}
