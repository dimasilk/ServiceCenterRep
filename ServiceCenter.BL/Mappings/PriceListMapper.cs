using System;
using System.Linq.Expressions;
using ServiceCenter.Auth.Models;
using ServiceCenter.BL.Common.DTO;

namespace ServiceCenter.BL.Mappings
{
    public static class PriceListMapper
    {
        public static void CopyTo(this PricelistDTO dto, Pricelist dataModel)
        {
            dataModel.Id = dto.Id;
            dataModel.Name = dto.Name;
            dataModel.ParentId = dto.ParentId;
            dataModel.Price = dto.Price;
        }
    

        public static readonly Expression<Func<Pricelist, PricelistDTO>> SelectExpression = u => new PricelistDTO
        {
            Id = u.Id,
            ParentId = u.ParentId,
            Price = u.Price,
            Name = u.Name
        };
       


    }
}
