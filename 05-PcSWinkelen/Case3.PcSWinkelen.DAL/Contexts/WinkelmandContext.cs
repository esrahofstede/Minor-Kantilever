using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case3.PcSWinkelen.DAL.Entities;

namespace Case3.PcSWinkelen.DAL.Contexts
{
    public class WinkelmandContext : DbContext
    {
        public WinkelmandContext() : base("PcSWinkelenDB")
        {
        }

        public DbSet<WinkelmandItem> WinkelmandItems { get; set; }
    }
}
