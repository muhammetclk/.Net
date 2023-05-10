using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflectiontwo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Bazen olusturdugumuz intance hakkinda nesnenin ne geldigini, veya icindeki metodların az onceki ornekte oldugu gibi topla oldugunu bilmiyor olabilriz.


            var type = typeof(DortIslem);

            var instance = Activator.CreateInstance(type, 6, 7);

            //olusturdugumuz instance hakkinda bilgi sahibi olup onun icindeki metodu calistrdik.
            //metodun ismini bildigimizi varsayarak yaptik bilmeseydik dinamik olarak yapabilirdik(Eger yazdigimiz method ismi olmasaydi hata verirdi veya parametresizken deger yollasaydik hata verirdi.).
            //GetType ile tipini aldik.GetMethod ile istedigimiz metoda ulastik.İnvoke ilede calistirdik.İnvoke'da neresi icin calistiracagini belirtmeliyiz(ornek icin=instance yazdik.)
           /* Console.WriteLine(instance.GetType().GetMethod("Topla2").Invoke(instance, null));*/

            //yukardakiyle ayni sey neden iki kere instance yazdigimizi anlamak icin.
            MethodInfo methodİnfo = instance.GetType().GetMethod("Topla2");//sadece method bilgisi topladık.İnstance ile bir bagi kalmadigi icin calistirirken tekrar instance yazıyoruz
            Console.WriteLine(methodİnfo.Invoke(instance,null)); 

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
