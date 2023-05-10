using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public delegate void StockControl();//delege tanımı
    public class Product
    {
        int _stock;
        public Product(int stock)//stock adedini veriyoruz.Normalde veritabanindan cekeriz.
        {
            _stock = stock;
        }

        public event StockControl StockControlEvent;//eventi StockControl turunde tanımladik. iSimlendirmeside sonuna event yazarak olur.
        public string ProductName { get; set; }//urun ismi tutar.



        public int Stock
        {
            get
            {
                return _stock;
            }
            set { 

                _stock = value;
                if (value <= 15 && StockControlEvent != null) //ıcınde deger varsa abone olmusuzdur.Ve bu kosul saglarsa eventi tetikliyor.
                {
                    StockControlEvent();
                }

            }
        }//stock bilgisi tutar.
        public void Sell(int amount)//satıs yapilan tutari alicaz ve stockdan dusucez.
        {
            Stock -= amount;
            Console.WriteLine("{1} Stock Amount {0}", Stock, ProductName);//hangi urunden ne kadar kaldıgını basıyoruz.
        }

    }
}
