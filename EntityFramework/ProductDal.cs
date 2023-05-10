using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class ProductDal
    {
        //Daha oncesinde Form1_Load 'a yazdigimiz kodu tüm islemleri ProductDal' uzerinde yapmak icin buraya tasıyoruz.
        public List<Product> GetAll()
        {
            using (ETradeContext context = new ETradeContext())//Bu formatta bir kod yazılır.

            {                          //veritabanıyla baglantı kuran kod.
                return context.Products.ToList();// ıqueryable tipinde dönen nesneyi Listeye ceviriyoruz.
            }

        }
        public void Add(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                /* context.Products.Add(product);//Contexteki Products'a ekle (product)*///Alttaki kod ile aynı sey.

                var entity = context.Entry(product);//Bu context'e abone ol demek (kim icin product icin..)
                //Bu gonderdıgımız product'ı veritabanındaki productla eslestiriyor anlamina geliyor.(Id uzerinden)

                entity.State = EntityState.Added;//durumunu guncellendi olarak degistiryor.
                context.SaveChanges();//yaptıgımız ıslemleri veritabanına yaz diyoruz.(Arka arkaya ıslem yapabilriz.)
            }
        }
        public void Update(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);//Bu context'e abone ol demek (kim icin product icin..)
                //Bu gonderdıgımız product'ı veritabanındaki productla eslestiriyor anlamina geliyor.(Id uzerinden)

                entity.State = EntityState.Modified;//durumunu guncellendi olarak degistiryor.
                context.SaveChanges();
            }
        }
        public void Delete(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);//Bu context'e abone ol demek (kim icin product icin..)
                //Bu gonderdıgımız product'ı veritabanındaki productla eslestiriyor anlamina geliyor.(Id uzerinden)

                entity.State = EntityState.Deleted;//durumunu Silindi olarak degistiryor.
                context.SaveChanges();
            }
        }
    }
}
