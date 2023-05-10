using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //connection stringini(server=(localdb)\mssqllocaldb;initial catalog=ETrade;integrated security=true) 
        //daha profosyonel olmasi acisindan konfıgırasyon dosyasına yazariz.(App.Config)
        //<configiration> etiketinin icine yeni bir etiket acıyyoruz.(<ConnectionStrings>)
        //daha sonra add ile name veriyoruz.(Veritabanında dırek (ETradeContext) ile baglantı kurmasi icin)
        //connectionString ini veriyoruz.
        //ekstra olarak providerName="System.Data.SqlClient" konfigurasyonunu yazıyoruz.



        ProductDal _productDal = new ProductDal();
        private void LoadProducts()
        {
            dgwProducts.DataSource = _productDal.GetAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //urunleri listeleyecek kodu yaziyoruz.
            //ETrade Context pahali bir nesnedir.

            //method bittigi zaman dotnet'in memory yoneticisi isi biten nesneleri bellekten atmaya baslar.Bunuda Garbage Collector(Cop toplayici) sistemiyle yapıyor.

            //(ETradeContext context = new ETradeContext(); bu sekildede yazabilirdik.Fakat)

            //Using kullanılmasının amacı blok'u({}) bittigi anda cop toplayiciyi beklemeden bellekte fazla yer kaplayan ETradeContext'i bellekten atıyoruz.
            //bu isleme dispose operasyonu denir.DbContext in icinde bulunur(inherit edilmistir.).

            /* using (ETradeContext context = new ETradeContext())//Bu formatta bir kod yazılır.

             {                          //veritabanıyla baglantı kuran kod.
                 dgwProducts.DataSource=context.Products.ToList();// ıqueryable tipinde dönen nesneyi Listeye ceviriyoruz.
             }*/



            LoadProducts();//Adonet kısmında yaptıgımızın aynısına cevirdik.
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                Name = tbxName.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbxStockAmount.Text)

            });
            MessageBox.Show("Product Added");
            LoadProducts();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product
            {
                Name = tbxNameUpdate.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text),
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)

            });
            LoadProducts();
            MessageBox.Show("Product Updated");


        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product
            {
                Id  = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)
            });
            LoadProducts();
            MessageBox.Show("Product Deleted"); 
        }
    }
}
