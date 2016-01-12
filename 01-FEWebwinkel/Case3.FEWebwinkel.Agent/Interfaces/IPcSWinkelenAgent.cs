﻿using Case3.PcSWinkelen.Schema;

namespace Case3.FEWebwinkel.Agent.Interfaces
{
    public interface IPcSWinkelenAgent
    {
        CatalogusCollection GetProducts();
        CatalogusCollection GetProducts(int page, int pageSize);
    }
}
