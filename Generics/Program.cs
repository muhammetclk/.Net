using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        //butun islemlerimizde listeleme,ekleme,silme,guncelleme yaparak ayni islmei yaptik.Ve fazlaca kod yazmis olduk(ICustomerDal,IProductDal).
        //gecerics ile ayni islemi coklu olacak sekilde yapabiliriz(Birdaha birdaha yazmayacak sekilde.).
        //generics ile nesne bazli calisiriz.(Hangi nesneyle calisacagimizi belirtiriz.)
        static void Main(string[] args)
        {
        }
    }
    class Product
    {


    }
    //Veri işlemleri yapan interface
    interface IProductDal : IRepository<Product>//Product T yerine geciyor. 
    {
        /* List<Product> GetAll();//urunleri listeieyen metod.
         Product Get(int id);//id getiren metod

         void Add(Product product);//verilen product'ı eklıcek metot tanımı
         void Update(Product product);//verilen product'ı guncellicek metot tanımı
         void Delete(Product product);//verilen product'ı sisicek metot tanımı
        */
    }
    class Customer
    {

    }
    //Ayni sekilde ayni Veri işlemlerini yapan interface 
    interface ICustomerDal : IRepository<Customer>//: 'den sonrası baslangıcta yoktu.Bu yapı ICustomerDal'a sen Bir IRepository'sin calısma tipin ise Customer Diyor.
    {//Y yerine Customer geciyor.

        /*  List<Customer> GetAll();//musterileri listeieyen metod.
          Customer Get(int id);//id getiren metod

          void Add(Customer customer);//verilen customer'ı eklıcek metot tanımı
          void Update(Customer customer);//verilen customer'ı guncellicek metot tanımı
          void Delete(Customer customer);//verilen customer'ı sisicek metot tanımı
        */
    }
    interface IRepository<T>//hangi nesneyle calisacagimiz diyebilecegimiz generics yapi.(<...> bu sekilde ... olan kisma isimlendirme kurallarina göre istedigimiz seyi yazabilriz.)
    {//T burda type dan geliyor gennelikle T kullanilir.Ben repository diye bir sey yapicam bana calisacagim nesneyi ver.

        List<T> GetAll();
        T Get(int id);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }

    //simdiProcutDal classi oluturup implemente edicez.
    class ProductDal : IProductDal//implemente ettık ve hepsi Producta gore geldi.
    {
        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }

    //Aynı sekilde CustomerDal classimizi olusturduk
    class CustomerDal : ICustomerDal//implemente ettik ve hepsi  Customer'a gore geldi.
    {
        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
    /*classlarda direk IRepository<Product> veya IRepository<Customer> 'da yapabilirdik ama bu sekilde yapmamızın nedeni
     yani ICustomerDal ve IPRoductDal olustumamizin nedeni ilerde bunlara özel metodlar tanimlayabilmemiz.
     ornegin ICustomerDal intefaceinde ayın müsterisini getiren bir metod olabilirdi ve bu IProductDal'i ilgilendirmezidi.Bu yuzden bu sekilde 
     tanımlama yaptık.*/

    //Generics yapıyı classlar uzerindede tanımlayabilirdik.
}

