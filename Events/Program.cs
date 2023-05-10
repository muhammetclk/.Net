using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {       
        static void Main(string[] args)
        {
            //eventi bir ürünün hep satilmasiyla ve bir urunun satısının bitecegi ile aciklayabiliriz.
            //ornegin telefonu hep satmak isteriz ve stockta bitmesini istemeyiz ve bunun icin urun stogunun azaldıgını belirten bir evente abone oluruz.
            //baska bır urunun satısını artık yapmayacaksan evente abone olmana gerek kalmaz.
            //eventler aslında bir delegedir.Delegelerden faydalanırız.

            Product product = new Product(50);//ctor stock adedini istiyor.
            Product product2 = new Product(50);
            product.ProductName = "Harrdisk";
            product2.ProductName = "Gsm";
            product2.StockControlEvent += Product2_StockControlEvent;//+= yapıp taba basarak evente abone oluyoruz.(Product2 icin(Gsm))
            //Assagi ise metodunu olusturuyor.

            for (int i = 0; i < 10; i++)
            {
                product.Sell(10);
                product2.Sell(10);
                Console.ReadLine();
            }
            Console.ReadLine();
            //product2.StockControlEvent = StockControl();

        }

        private static void Product2_StockControlEvent()//eger abone olma mantigi ile yapmasaydik bir suru urun icin bir suru if kullanmak zorunda kalirdik.
        {
            Console.WriteLine("Telefon stok'u bitmek üzere");
        }
    }
     
}
