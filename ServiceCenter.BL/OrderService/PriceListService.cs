using System;
using System.Linq;
using ServiceCenter.Auth.Models;
using ServiceCenter.BL.Common.DTO;
using ServiceCenter.BL.Interfaces;
using LinqKit;
using ServiceCenter.BL.Mappings;

namespace ServiceCenter.BL.OrderService
{
    public class PriceListService : IPriceListService
    {
        private readonly ApplicationDbContext _context;

        public PriceListService(ApplicationDbContext context)
        {
            _context = context;
        }

        public PricelistDTO[] GetFullPriceList()
        {
            return _context.PricelistItems.AsExpandable().Select(PriceListMapper.SelectExpression).ToArray();
        }

        public PricelistDTO GetPriceListItemById(Guid itemId)
        {
            return
                _context.PricelistItems.AsExpandable()
                    .Where(x => x.Id == itemId)
                    .Select(PriceListMapper.SelectExpression)
                    .FirstOrDefault();
        }

        public PricelistDTO[] GetPriceListItemsByOrder(Guid orderId)
        {
            var z = _context.PricelistOrders.Where(x => x.Order_Id == orderId).Select(x => x.Pricelist_Id).ToList();
            var v = _context.PricelistItems.AsExpandable().Where(x => z.Contains(x.Id)).Select(PriceListMapper.SelectExpression).ToArray();
            return v;
        }
    }
}
