using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adonet
{
    //form uygulamasi uzerinde olusturdugumuz DataGridView tablodaki verileri cekecegimiz kismi olusturuyor.


    public class ProductDal//publice cektik.Dal=data access layer=veri erişim katmani
    {//Bu classimizda urunleri listeleme,silme,ekleme,güncelleme gibi işlemleri yapicaz.



        //veritabani ile baglanti kurmak ıcın SqlConnection sinifini kullaniyoruz.
        //SqlConnection'in icine baglanti bilgilerini giriyoruz.
        //Baglanacagimizi bildirdigimiz yer server=(localdb)\mssqllocaldb
        // '\' ters slasin c#'da bir anlami oldugu icin tamamini string algilamasi icin @ ısaretı eklenır.
        //initial catalog hangi veritabanina baglanicagimizi gosterir.(ETrade veritabanina baglanicaz.)
        //integrated security=true veritabanina windows authentication ile baglan demek.(bilgisayara login oldugumuz hesapla acmak yani localde acmak.)
        //eger integrated security=false yapsaydik uzak bir veritabanina baglanmak istiyoruz anlamina gelirdi ve bu islemden sonra uid=Muhammet;password=12345 gibi yazmaliydik.
        //nesneyi classin icinde ve motodlarin disinda tanimladigimiz icin _ kullanilir.
        //Baglanma islemini herseferinde yapmamak icin en ustte tanimladik.
        SqlConnection _connection = new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=ETrade;integrated security=true");
        //baglantı nesnesı olusturduk.Baglantıyı ConnectionControl ile kontrol edıyoruz acik deilse aciyoruz.
        private void ConnectionControl()//baglantinin kontrolunude her yerde yazmamak icin metod icinde kontrol ettik.
        {
            if (_connection.State == ConnectionState.Closed)//baglantinin durumunu kontrol ettik eger zaten aciksa tekrar acmaya calismak sikinti cikarir.
            {
                _connection.Open();//baglanti kapaliysa bu sekilde acmis olduk.

            }
        }

        //liste biciminde Product donduren metod.
        public List<Product> GetAll()
        {
            ConnectionControl();//Baglantıyı kontrol ettik acik deilse acildi.

            //veritabaniyla ilsetisim kurabilmek icin SqlCommand kullanilir.Bu komutu kullanarak veri cekme gibi islemleri yapiyoruz. 
            SqlCommand command = new SqlCommand("Select * from Products", _connection);//Bizden string formatinda komut istiyor.Yazdigimiz komut urunleri listeler.Bu sorguyu connection'a(Baglantiya) yollariz.
            //sorguyu olusturduk fakat calıstırmadık onuda reader ıle yapıcaz.
            SqlDataReader reader = command.ExecuteReader();//ExecuteReader metoduyla sorguyu calistiriyoruz.ExcuteReader'in sunucusu SqlDataREader'dir ve onu dondurur.Referansini atadigimiz icin newlemeye gerek yok.

            List<Product> products = new List<Product>();
            while (reader.Read())//Read metodu reader'daki verileri tek tek okuyor.okuyabildigi surece calısır.
            {
                Product product = new Product//readerdaki verileri product nesnesine atıp products listesine ekliyor.
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name=Convert.ToString(reader["Name"]),
                    UnitPrice=Convert.ToDecimal(reader["UnitPrice"]),
                    StockAmount=Convert.ToInt32(reader["StockAmount"])
                };
                products.Add(product);
            }

            reader.Close();//reader'i kapattik.(sorgu calısmaya devam etmesın dıye.)
            _connection.Close();//Baglantıyı kapattik.
            return products;//sonucu dondurduk.


        }




        // DataTable biçiminde Product donduren GetAll metodu.Urunleri listeleyecegiz.
        //DataTable pahali bir nesnedir.
        public DataTable GetAll2()
        {
            ConnectionControl();//Baglantıyı kontrol ettik acik deilse acildi.

            //veritabaniyla ilsetisim kurabilmek icin SqlCommand kullanilir.Bu komutu kullanarak veri cekme gibi islemleri yapiyoruz. 
            SqlCommand command = new SqlCommand("Select * from Products", _connection);//Bizden string formatinda komut istiyor.Yazdigimiz komut urunleri listeler.Bu sorguyu connection'a(Baglantiya) yollariz.
            //sorguyu olusturduk fakat calıstırmadık onuda reader ıle yapıcaz.
            SqlDataReader reader = command.ExecuteReader();//ExecuteReader metoduyla sorguyu calistiriyoruz.ExcuteReader'in sunucusu SqlDataREader'dir ve onu dondurur.Referansini atadigimiz icin newlemeye gerek yok.

            DataTable dataTable = new DataTable();//dataTable kullanarak verileri tabloya aktariyoruz
            //calıstırdıgımız sorguyu dataTableye aktarıyoruz.
            dataTable.Load(reader);//Bizden IDataReader istiyor readeri ekliyoruz.(SqlDataReader'da bir IDataReader'dir.) dataTable'i reader ile doldurduk.

            reader.Close();//reader'i kapattik.(sorgu calısmaya devam etmesın dıye.)
            _connection.Close();//Baglantıyı kapattik.
            return dataTable;//sonucu dondurduk.


        }

        public void Add(Product product)//verilen Product veritabanına eklenir.
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Insert into Products values(@name,@unitPrice,@stockAmount)", _connection);//values'i parametre olarak Product'dan alıyoruz.
            command.Parameters.AddWithValue("@name",product.Name);//gırılen deger olan product.name'i @name'e atıyoruz.
            command.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@StockAmount", product.StockAmount);
            command.ExecuteNonQuery();//calıstırmak ıcın kullandık.
            _connection.Close();
        }
        public void Update(Product product)//verilen Product veritabanına eklenir.
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Update  Products set Name=@name,UnitPrice=@unitPrice,StockAmount=@stockAmount where Id=@id", _connection);//guncellenecek degere tıkladıgımızda gelen degerler.
            command.Parameters.AddWithValue("@name", product.Name);//yeni girilen  deger olan product.name'i @name'e atıyoruz.
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.Parameters.AddWithValue("@id", product.Id);
            command.ExecuteNonQuery();//calıstırmak ıcın kullandık.
            _connection.Close();
        }

        public void Delete(int id)//verilen id'ye gore silme yapilir.  
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Delete From Products where Id=@id",_connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();//calıstırmak ıcın kullandık.
            _connection.Close();
        }
    }
}
