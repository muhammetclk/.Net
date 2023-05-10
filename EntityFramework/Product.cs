using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    //sinif ismi tablonun tekil hali olur.(Product)
    public class Product//publice cektik.Bu class tablomuzun kodsal karsiligini olustracak.
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public int StockAmount { get; set; }

    }
}
