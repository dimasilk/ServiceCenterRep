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
            var a = _context.PricelistItems.ToArray();
            return _context.PricelistItems.AsExpandable().Select(PriceListMapper.SelectExpression).ToArray();
        }
    }
}
