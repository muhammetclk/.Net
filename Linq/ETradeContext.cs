using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
   
    public class ETradeContext : DbContext
    {
        
        public DbSet<Product> Products { get; set; }
    }
}
