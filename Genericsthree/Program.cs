using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genericsthree
{
    class Program
    {
        static void Main(string[] args)
        {
            Utilities utilities = new Utilities();


            List<string> result = utilities.BuildList<string>("Ankara", "Istanbul", "Düzce");

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }



            List<Customer> result2 = utilities.BuildList<Customer>(new Customer { FirstName = "ahmet" }, new Customer { FirstName = "mehmet" });
            foreach (var item in result2)
            {
                Console.WriteLine(item.FirstName);
            }
            Console.ReadLine();

        }



    }

    //generics kisitlari(Constraints)//verdigimi tipleri kisitlayabilyoruz.
    //class bir referans tiptir.string de referans tip oldugundan yazilabilir.
    interface IRepository<T> where T : class,new()//where ile sadece buraya  yazdıgımız tipleri kullanabilriz.
    {//new herzaman en sona yazilir.kisitlarda sadecebelli bir class veya interfaceden implemente edilenler olacak sekildede kisitlayabilirdik.
        //sadece deger tiplerini kullanabilmek icin   kisitlara struct yazarak kullanabilirdik.

        List<T> GetAll();
        T Get(int id);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
    interface IStudentDal : IRepository<Customer> { }//string yazasak hata vermez.fakat kısıtlar new() de olursa string newlenemeyen bir sey oldugu icin hata verir.


    class Utilities
    {

        public List<T> BuildList<T>(params T[] items)
        {
            return new List<T>(items);

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
