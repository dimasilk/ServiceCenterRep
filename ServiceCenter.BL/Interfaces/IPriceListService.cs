﻿using ServiceCenter.BL.Common.DTO;

namespace ServiceCenter.BL.Interfaces
{
    public interface IPriceListService
    {
        PricelistDTO[] GetFullPriceList();
    }
}
