using ServiceCenter.BL.Common.DTO;

namespace ServiceCenter.UI.OrderModule.ViewModel
{
    public class PriceListViewModel
    {
        

        public PriceListViewModel(PricelistDTO pricelistDto)
        {
            PricelistDto = pricelistDto;
        }

        public PriceListTreeViewModel Childs { get; set; }
        public PricelistDTO PricelistDto { get; set; }
    }
}
