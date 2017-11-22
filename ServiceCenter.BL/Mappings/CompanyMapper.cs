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
    public static class CompanyMapper
    {
        public static void CopyTo(this CompanyDTO dto, Company dataModel)
        {
            dataModel.Id = dto.Id;
            dataModel.Adress = dto.Adress;
            dataModel.Info = dto.Info;
            dataModel.Phone = dataModel.Phone;
            dataModel.Name = dataModel.Name;
            //dataModel.Orders = 

        }

        public static readonly Expression<Func<Company, CompanyDTO>> SelectExpression = u => new CompanyDTO
        {
            Id = u.Id,
            Info = u.Info,
            //Orders = 
            Name = u.Name,
            Adress = u.Adress,           
            Phone = u.Phone
        };
    }
}
