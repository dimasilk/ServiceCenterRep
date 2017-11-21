using System;
using ServiceCenter.BL.Common.DTO;

namespace ServiceCenter.BL.Interfaces
{
    public interface IPriceListService
    {
        PricelistDTO[] GetFullPriceList();
        PricelistDTO GetPriceListItemById(Guid itemId);
        PricelistDTO[] GetPriceListItemsByOrder(Guid orderId);
    }
}
