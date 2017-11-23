using System;
using ServiceCenter.Auth.Models;
using ServiceCenter.BL.Common.DTO;
using System.Linq.Expressions;

namespace ServiceCenter.BL.Mappings
{
    public static class CustomerMapper
    {
        public static void CopyTo(this CustomerDTO dto, Customer dataModel)
        {
            dataModel.Id = dto.Id;
            dataModel.FullName = dto.FullName;
            dataModel.Info = dto.Info;            
            dataModel.Phone = dto.Phone;
            //dataModel.Orders = 
            dataModel.Orders.Clear();
            
        }

        public static readonly Expression<Func<Customer, CustomerDTO>> SelectExpression = u => new CustomerDTO
        {
            Id = u.Id,
            Info = u.Info,
            //Orders = 
            FullName = u.FullName,
            Phone = u.Phone
        };
    }
}
