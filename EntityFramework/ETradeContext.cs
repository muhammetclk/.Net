using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    //entityFramework basitçe adonette yaptigimiz fazla kod yazımlarini minimuma indiriyor.(Daha az kod yazarak ayni islevi yapiyoruz.)

    //proje adına sag tıklayarak(EntityFramework) bircok kutuphanenin bulundugu 
    // manage NuGet Packages kısmından EntityFramework kutuphanesini indirerek projemize ekliyoruz.

    //EntityFramework'de veritabaninin kodsal karsiligi olmasi gereklidir.(Adonet deki gibi.)
    //Daha sonra classımızı veritabanındaki tabloyla eslesitirmemiz lazim.
    //Bunun icin entityframeworkde context kullanicaz.(tasarım desenini implemente ediyor.Anlamına geliyor.(Context))
    //projemize Veritabaiyla ayni isimde bir class olusturup sonuna Context ekliyoruz.(ETradeContext)



    //publice cekiyoruz.
    //Bunun bir EntityFramework Contexti olabilmesi icin DbContext'den inherit edilmesi gerekiyor.
    public class ETradeContext : DbContext
    {
        //DbSet<Product> generic yapısı kullanılır.Bu benim bir Product'ım var ve onu tablo gibi, Products ismiyle kullanıcaz.
        //Bu yapı tablolarda Products adında birsey ariyor.
        //Temel anlamda Contextimizi olusturduk.
        public DbSet<Product> Products { get; set; }
    }
}
