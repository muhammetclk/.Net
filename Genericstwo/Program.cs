using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genericstwo
{
    class Program
    {//generic yapıyı metodlar icinde kullanabiliyoruz.
        static void Main(string[] args)//Utilities işlemleri yapmak icin kullanılır(isimlendirilir). araclar gibi dusunebiliriz ornegin convert islemi
        {
            Utilities utilities = new Utilities();

                                                    //buraya hangi tipi yazarsak o tipte liste olustur anlamına geliyor. 
            List<string> result = utilities.BuildList<string>("Ankara", "Istanbul", "Düzce");//motoda generic bir yapı olusturdk.

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }


            //Aynı sekilde bana bir musteri listesi olustur.
            List<Customer> result2 = utilities.BuildList<Customer>(new Customer {FirstName="ahmet" },new Customer {FirstName="mehmet" });
            foreach (var item in result2)
            {
                Console.WriteLine(item.FirstName);
            }
            Console.ReadLine();

        }
        


    }
    class Utilities
    {
        //hangi tipte calisacaksak o tipte dondur.
        public List<T> BuildList<T>(params T[] items)//onceki kisimda yaptigimiz gibi calisacagimiz tipi sonda  veriyoruz.
        {//vercegimiz tipi donus tıpı olarak  ve parametrelerde kullandık.
            return new List<T>(items);//List<T> dondur kim icin=items icin
        
        }
    }


    interface IProductDal : IRepository<Product>
    {

    }
    class Customer
    {
        public string FirstName { get; set; }

    }
    interface ICustomerDal : IRepository<Customer>
    {
    }
    interface IRepository<T>
    {

        List<T> GetAll();
        T Get(int id);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
    class ProductDal : IProductDal
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
    class Product
    {


    }
    class CustomerDal : ICustomerDal
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
}
