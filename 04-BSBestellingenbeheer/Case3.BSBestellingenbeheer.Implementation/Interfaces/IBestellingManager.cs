﻿using Case3.BSBestellingenbeheer.V1.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case3.BSBestellingenbeheer.Implementation.Interfaces
{
    public interface IBestellingManager
    {
        Bestelling FindFirstBestelling();
    }
}