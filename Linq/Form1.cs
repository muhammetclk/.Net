using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Linq
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        



        ProductDal _productDal = new ProductDal();
        private void LoadProducts()
        {
            dgwProducts.DataSource = _productDal.GetAll();
        }
        private void SearchProducts(string key)//yeni bir metot olusturduk.Search kismina yazdigimiz harfler key olarak gelicek.
        {
            //urunleri getirdikten sonra sorgu atiyoruz.(Koleksiyona sorgu atıyoruz.)
            /*p=>p. bu bir delegasyondur.Her bir p icin yani listedeki her bir eleman icin Name'ıne bak  ve ıceriyor olsun
             key, search kısmına yazdıgımız harfleri icerenleri getirecek.Onu listeye cevirip datasource'a kaynak olarak gosterıyoruz.
             */
            //c# harf duyarlı oldugu ıcın buyu kucuk harflerı ayarlamalıyız(ToLower kullanıcaz).

            /* var result = _productDal.GetAll().Where(p=>p.Name.ToLower().Contains(key.ToLower())).ToList();
             dgwProducts.DataSource = result;*/





           var result2= _productDal.GetByName(key);//2.yol
            dgwProducts.DataSource = result2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            /* using (ETradeContext context = new ETradeContext())//Bu formatta bir kod yazılır.

             {                          //veritabanıyla baglantı kuran kod.
                 dgwProducts.DataSource=context.Products.ToList();// ıqueryable tipinde dönen nesneyi Listeye ceviriyoruz.
             }*/



            LoadProducts();
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
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)
            });
            LoadProducts();
            MessageBox.Show("Product Deleted");
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProducts(tbxSearch.Text);//metoda yazdıgımız seyle gıdıcek(Key'e gıdıcek)
            
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            _productDal.GetById(3);
        }
    }
}
