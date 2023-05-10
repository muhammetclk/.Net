using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflectionthree
{
    class Program
    {
        static void Main(string[] args)
        {
            //Reflection ile bir classin metodlarina özelliklerine,attributelerine liste halinde ulasabiliyoruz.

            var type = typeof(DortIslem);

            var instance = Activator.CreateInstance(type, 6, 7);
            MethodInfo methodİnfo = instance.GetType().GetMethod("Topla2");
            Console.WriteLine(methodİnfo.Invoke(instance, null));
            Console.WriteLine("-----------------------------");

            //methodlarımızı listeledik.
            var metodlar = type.GetMethods();//DortIslem icindeki metodlara ulastik.(Type'e atamisitk.)
            foreach (var info in metodlar)
            {
                Console.WriteLine("Method adı {0}", info.Name);
                foreach (var parameterInfo in info.GetParameters())//infoya atadigimiz metodlardaki parametrelere ulastik.
                {
                    Console.WriteLine("Parametre adı {0}", parameterInfo.Name);
                }
                foreach (var attribute in info.GetCustomAttributes())//metodlarin varsa attributelerine ulastik.
                {
                    Console.WriteLine("Attribute adi {0}", attribute.GetType().Name);
                }
            }


            Console.ReadLine();
        }


    }
    public class DortIslem
    {
        private int _sayi1 { get; set; }
        private int _sayi2 { get; set; }
        public DortIslem(int sayi1, int sayi2)
        {
            _sayi1 = sayi1;
            _sayi2 = sayi2;

        }

        [MethodName("Toplama")]
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
        [MethodName("Carpma")]
        public int Carp2()
        {
            return _sayi1 * _sayi2;
        }

    }
    public class MethodNameAttribute : Attribute//attribute olustruduk.
    {
        
        public MethodNameAttribute(string MethodName)
        {
            
        }
    }
}

