namespace ServiceCenter.UI.OrderModule.ViewModel
{
    public class OrderToolbarViewModel
    {
        public OrderCollectionViewModel ViewModel { get; private set; }

        public OrderToolbarViewModel (OrderCollectionViewModel orderCollectionViewModel)
        {
            ViewModel = orderCollectionViewModel;
        }
    }
}
