using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //Reflection calisma aninda nesneler hakkinda bilgi almamizi ve bu nesneleri calistirabilmemizi saglar.

            //temel metoda deger yollayarak topla ve ctor ile topla islemleri
            /* DortIslem dortIslem = new DortIslem(4, 5);
             Console.WriteLine(dortIslem.Topla2());
             Console.WriteLine(dortIslem.Topla(2, 3)); *///Bu kısımda yazdıgımız kodları calısma anında olacak sekilde yani reflection kullanarak yapıcaz.

            //burda DortIslem ile calısacagımızı belırtıyoruz.Normalde Oda parametre olarak alınıyor biz direk yazdık.
            var type = typeof(DortIslem);


            //reflectionda Activator sınfını kullanıyoruz.calisma aninda dinamik instance uretiyoruz.(neyin instance'sini olusturmak istedigimizi parantezin icine yazıyoruz.)
            //Activator.CreateInstance(type) islemi  new DortIslem(4, 5); 'le ayni sey.Farki bunu, calisma aninda gelen type'e gore yapmamiz.
            //geri donus tipini bildigimiz icin Activator'in yanina (DortIslem) yazariz.
            //dortislem nesnesini olustururken paramerte degerlerini girmeliyiz yoksa hata verir. 
            DortIslem dortIslem = (DortIslem)Activator.CreateInstance(type,4,6);//paramerteli ctor oldugu ıcın hata verdı.Parametresiz ctor olsaydı sıkıntı olmazdi.Bunun ıcın DortIslem classında Boş ctor olusturabiliriz yada type'ın yanına parametre veririz.
            Console.WriteLine(dortIslem.Topla(4, 5));
            Console.WriteLine(dortIslem.Topla2());
            Console.ReadLine();
        }
        class DortIslem
        {
            private int _sayi1 { get; set; }
            private int _sayi2 { get; set; }
            public DortIslem(int sayi1, int sayi2)
            {
                _sayi1 = sayi1;
                _sayi2 = sayi2;

            }
            public int Topla(int sayi1, int sayi2)
            {
                return sayi1 + sayi2;
            }
            public int Carp(int sayi1, int sayi2)
            {
                return sayi1 * sayi2;
            }
            public int Topla2()
            {
                return _sayi1 + _sayi2;
            }
            public int Carp2()
            {
                return _sayi1 * _sayi2;
            }

        }
    }
}
