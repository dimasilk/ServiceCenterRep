using System;
using System.Collections.Generic;
using System.Linq;
using ServiceCenter.BL.Common.DTO;

namespace ServiceCenter.UI.OrderModule.ViewModel
{
    public class PriceListTreeViewModel : List<PriceListViewModel>
    {
        public PriceListTreeViewModel(PricelistDTO[] pricelistDtos, Guid? parentId = null)
        {
            var items = pricelistDtos.Where(x => x.ParentId == parentId).OrderBy(x => x.Name).ToArray();
            foreach (var element in items)
            {
                var vm = new PriceListViewModel(element) {Childs = new PriceListTreeViewModel(pricelistDtos, element.Id)};
                Add(vm);
            }
        }
    }
}
