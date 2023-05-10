using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    //EntityFrameworkdeki kismi aynen kopyaladık.Karismasin diye yaptık.Linq calısması yapilacak.
    /*Linq deki amacımız sorgulama yapma.Ornegin formumuza Search kismi ekledik.Herhangi bir harfe bastigimizda
    icinde o harfin gectigi urunleri getirmesi.*/
    public class ProductDal
    {
        
        public List<Product> GetAll()
        {
            using (ETradeContext context = new ETradeContext())

            {                          
                return context.Products.ToList();
            }

        }
        public List<Product> GetByName(string key)//burda direk veritabanina sorgu atiyoruz.
        {
            using (ETradeContext context = new ETradeContext())

            {
                return context.Products.Where(p=>p.Name.Contains(key)).ToList();//veritabanında kucuk-buyuk harf gozetılmez.
            }

        }
        public List<Product> GetByUnitPrice(decimal price)//girdigimiz fiyat geliyor.
        {
            using (ETradeContext context = new ETradeContext())

            {
                return context.Products.Where(p => p.UnitPrice>=price).ToList();//Fiyatı; girdigimiz fiyattan buyuk olanları getiriyor.
            }

        }
        public List<Product> GetByUnitPrice(decimal min,decimal max)//girdigimiz fiyatlar geliyor.
        {
            using (ETradeContext context = new ETradeContext())

            {
                return context.Products.Where(p => p.UnitPrice >= min&&p.UnitPrice<=max).ToList();//Fiyatı; girdigimiz fiyatlar arasında olanları getıriyor..
            }

        }
        //Bızım dondurecegımız sey sadece tek bir urun olacagı ıcın  sadece Product yapıyoruz.
        public Product GetById(int id)//girdigimiz id geliyor.
        {
            using (ETradeContext context = new ETradeContext())

            {//where Iqueryable oldugu ıcın yanı lıste donduruyor onu kullanmıcaz.
                //FirstOrDefault yazdıgımız id yi esşlestirirse urunu,eslestiremezzse default olarak null dondurecek.
                var result =context.Products.FirstOrDefault(p => p.Id == id);//SingleOrDefault ise birden fazla aynı urun varsa hepsini getiriyor.First olanda ise ilkini geitiroyr.
                return result;//id tek oldugu icin bunda ikisinide kullanabiliriz sikinti olmuyor.

            }

        }

        public void Add(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                

                var entity = context.Entry(product);
                

                entity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Update(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);
                

                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);
                

                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
