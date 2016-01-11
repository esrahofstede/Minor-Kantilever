using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CatalogusProd = Case3.BSCatalogusBeheer.Schema.Prod;
using VoorraadProd = Case3.BSVoorraadBeheer.Schema.Prod;
using System.Threading.Tasks;
using AutoMapper;

namespace Case3.PcSWinkelen.Implementation
{
    public class AutomapBootstrap
    {
        public static void InitializeMap()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CatalogusProd.Product, VoorraadProd.Product>());
            Mapper.Initialize(cfg => cfg.CreateMap<VoorraadProd.Product, CatalogusProd.Product>());

        }
    }
}
