using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    //void olan ve parametre almayan methodlara hizmet eden delege tanımlamasi
    public delegate void MyDelegate();

    //void olan ve string parametre alan methodlara hizmet eden delege.
    public delegate void MyDelegate2(string text);

    //int döndüren ve iki int parametre alan operasyonlara hizmet eder.
    public delegate int MyDelegate3(int number1, int number2);
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            //normal sekilde ekrana bastık
            /* customerManager.SendMessage();
             customerManager.ShowAlert();*/


            //bir delegeden ayni isi yapan birden fazla delege olusturabiliyoruz.
            MyDelegate myDelegate = customerManager.SendMessage;//delege mesajı aldi fakat bu işlem tamamlanmadi
            myDelegate();//delegeyi cagırdıgımızda islem gerceklesti.
            myDelegate += customerManager.ShowAlert;//delegelerde bu sekide ekleme veya cıkarma yapabiliriz.
            myDelegate -= customerManager.SendMessage;
            myDelegate();
            //delegelerde, yapılacak islemleri topluyoruz ve bir sıra olusturup bunu cagirma eyleminde bulunuyoruz.


            MyDelegate2 myDelegate2 = customerManager.SendMessage2;//parametreli olan
            myDelegate2("Merhaba");//delegeyi cagirdik ve degeriyle yolladik.
            //birden fazla delegenin sirasini belirleyebiliriz.(myDelegate2i daha sonrada cagırabilirdik.)

            //Bunun icin yeni class olusturyoruz.(Matematik classi)
            Matematik matematik = new Matematik();
            MyDelegate3 myDelegate3 = matematik.Topla;
            Console.WriteLine(myDelegate3(4,5));//delegeyi cagirdik ve degerlerini yollayip donen degeri ekrana bastik.

            myDelegate3 += matematik.Carp;
            Console.WriteLine(myDelegate3(2, 3)); //burda daha oncesinde toplama yaptı ve simdi  carpma yaptı ve bunlari ekledi fakat deger donduren delegelerde en son yaptigi islemi dondurur.(carpma)
            //yani hem toplama yapip hemde carpma islemini ekleme yoluyla yapsaydik ayni degerlerde en son yaptigimiz carpma islemini dondururdu.
            Console.ReadLine();
        }
    }
    class CustomerManager
    {
        public void SendMessage()//Hello yazdıran parametre almayan method yazdık.
        {
            Console.WriteLine("Hello");
        }
        public void ShowAlert()//dikkatli ol yazan parametre almayan method
        {
            Console.WriteLine("be careful");
        }

        public void SendMessage2(string message)//paramerte alan ve ekrana basan method 
        {

            Console.WriteLine(message);
        }
        public void ShowAlert2(string alert)//parametre alan ve ekrana basan method.
        {

            Console.WriteLine(alert);
        }

    }

    class Matematik
    {
        public int Topla(int num1,int num2)//iki degeri alan ve toplamini donduren method.
        {
            return num1 + num2;
        }
        public int Carp(int num1, int num2)//iki degeri alan ve carpımını donduren method.
        {
            return num1 * num2;
        }
    }
}
