using System;
using System.Globalization;
using System.Windows.Controls;
using ServiceCenter.UI.Infrastructure.Validation;

namespace ServiceCenter.UI.OrderModule.Validation
{
    public class AddEditOrderValidationMessages
    {
        public string PriceListMessage { get; } = "No items selected from the pricelist";

        public string CustomerCompanyMessage { get; } =
            "Can not save order without customer and company. Select at least one of them";
    }
}
