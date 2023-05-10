using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    class Program
    {
        //attributelerle calisma aninda metodlara,classlara,nesnelere anlam katiyoruz.
        //kendi olusturdugumuz attributelere kendimiz anlam katabiliriz.(RequiredProperty,ToTable)
        static void Main(string[] args)
        {
            //nesnemizi olusturduk ve ilk degerlerini atadik.
            //ilk etapda firstname'i girmedigimizi dusunelim ve [RequiredProperty]'nin kapali oldugunu dusunelim.
            Customer customer = new Customer { Id = 1,  LastName = "Celik", Age = 21 };

            //CustomerDal nesnemizi olusturdugumuzda ve Add metodunu kullandıgımızda FirstName olmadan ekrana basıyor.
            //Fakat atrribute kullarak belli kurallar koyabiliriz.(ORn RequiredProperty)
            CustomerDal customerDal = new CustomerDal();




            customerDal.Add(customer);//Bize uyarı veriyor bu metod eski diye.(Uzerine gelince bizim yazdıgımız mesaji gosteriyor.)
            Console.ReadLine();
        }
    }
    //classimiza attribute ekledik.Customer nesnesi veritabaninda Customers' tablosuna karsilik gelir.
    //Dinamik sorgular icin kullaniriz.Veritabanina musteri eklemeye calisan bir kisi bu özellikleri alip bir insert(Sql sorgusu ) olusturabilr.
    [ToTable("Customers")]
    [ToTable("tblcustomers")]//ya customersa yada tblcustomersa ekle diye kural getiriyoruz(ArrowMultiple ornegi.)
    class Customer
    {
        public int Id { get; set; }

        [RequiredProperty]//attribute yi ekleyerek(üst kısmına) Kullanicinin FirstName i girmesini zorunlu kilabiliriz.Ne anlama geldigini zorunlu kılmak icin lojik ekleyecegimiz yapi Reflectiondir..
       //reflection ile nesnlerin, methodlarin ustune bakariz attribute varsa hangi attribute var bakariz ve onlara anlamlar yükleriz.
        public string FirstName { get; set; }
        [RequiredProperty]//her birine ekleyeiliriz.
        public string LastName { get; set; }
        [RequiredProperty]
        public int Age { get; set; }
    }


    class CustomerDal//Ekleme islemini yapmis olalım
    {
        //programcıyı uyarıyoruz yeni metod yazdik bunu kullanma diye
        [Obsolete("Don't use add method,instead use AddNew method")]//hazir attirubute.(eski anlamina geliyor.)(MEsajda yazdirabiliriz.)
        public void Add(Customer customer)//Add metodunu kullanidk .yeni bir Add metodu(yeni versiyon) yaziyoruz.bunu silemiyoruz cunku projede bagli oldugu yerler olabilir.
        {
            Console.WriteLine("{0},{1},{2},{3} added",customer.Id,customer.FirstName,customer.LastName,customer.Age);
        }
        public void AddNew(Customer customer)
        {

        }
    }

    //Required attributesine, attribute ekldik.
    [AttributeUsage(AttributeTargets.All)]//herhangi bir attributeyi her seyde kullanabiliriz (orn=All) veya Class,method vb. degistirebiliriz.Belli bir seye tanimlarsak digrelerinde hata verir.
    //birden fazla seyde kullanabiliriz aralarına '|' isareti koyarak devam ettirilebilir.(orn=AttributeTargets.class|AttributeTargets.Method gibi)
    class RequiredPropertyAttribute : Attribute//isimlendirmesi boyle yapilir.ve Attribute olmasi icin Attribute classindan inherit edilir.
    {

    }
    //AllowMultiple=true yaparak bir attributeyi iki kere kullanabiliriz.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    class ToTableAttribute : Attribute//ToTable attribute parametre  bekledigi icin contructor ile set etmeliyiz.
    {
        private string _TableName { get;set; }
        public ToTableAttribute(string TableName)//gelen deger
        {
            _TableName= TableName;
        }

    }
   
}
