using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adonet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //heryerde yazmamak icin disarda tanimladim.
        ProductDal _productDal = new ProductDal();//DataSource bizden obje istiyor ve onu kaynak olarak gosterecek.(productDal)
        private void LoadProducts() {
            dgwProducts.DataSource = _productDal.GetAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Form1'in loadina geldik.(Formun acilis event'i)
            //burdan gride ulasicaz.nesnelere daha rahat ulasmak icin adini dgwProducts yaptik.


            LoadProducts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product { //Add metodunu calıstırdık ve bızden Product ıstedı.New Product dıyıp kullanıcınin gırdıgı degerlerle eslestirdik ve database kaydettık..
                Name = tbxName.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbxStockAmount.Text),


            }) ;
            MessageBox.Show("Product Added");//mesajı ekranda gosterıcek.
            LoadProducts();//urunlerı tekrar gosterıcek.
        }





        //cellclick'i eventlerden ekledik dgw'deki her hucreye tikladiginda gelmesini saglar.
        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dgw de uzerine bastıgımız hucreyı textbox'a getirecek kod.
            //dgwProducts'in secili satirinin(CurrenRow) 1. hucresinin(Cells) valuesini stringe cevir
            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product//yeni girilen degerleri atadık ve update metoduna yolladık.
            {
                Id =Convert.ToInt32( dgwProducts.CurrentRow.Cells[0].Value),
                Name = tbxNameUpdate.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text)


            };

            _productDal.Update(product);
            MessageBox.Show("Product Updated");
            LoadProducts();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value);
            _productDal.Delete(id);
            MessageBox.Show("Product Deleted");
            LoadProducts();
        }
    }
}
