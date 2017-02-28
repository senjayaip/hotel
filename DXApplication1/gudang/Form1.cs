using System;
using DevExpress.XtraEditors;
using gudang.Event.Login;
using DevExpress.XtraBars.Navigation;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace gudang
{
    public partial class Form1 : XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var x = new Login();
            var status = x.AuthLogin(textUsername.Text, textPassword.Text);

            if (status == true)
            {
                nav.SelectedPage = PageMenu;
            }else
            {
                XtraMessageBox.Show("wrong username or password");
            }
        }

        private void textUsername_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void textPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void barStock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GenerateKodeItem(); // hapus
            navigationFrame1.SelectedPage = gudang_add_barang;
            var data = new items()
            {
                kode_item = 123456789,
                nama_item = "sabun mandi",
                harga_beli = 5000,
                harga_jual = 6000,
                quantity = 200
            };
            item.Add(data);
            RefreshData();
        }

        public class items
        {
            public int kode_item;
            public string nama_item;
            public int harga_beli;
            public int harga_jual;
            public int quantity;
        }

        private List<items> item = new List<items>();
        private void addItem_Click(object sender, EventArgs e)
        {
            GenerateKodeItem(); // hapus


            try
            {
                var data = new items()
                {
                    kode_item = Convert.ToInt32(labelControl1.Text),
                    nama_item = textNamaItem.Text,
                    harga_beli = Convert.ToInt32(textHargaBeli.Text),
                    harga_jual = Convert.ToInt32(textHargaJual.Text),
                    quantity = Convert.ToInt32(textQuantity.Text)
                };
                item.Add(data);
            }
            catch (Exception)
            {
                //error message
            }


            //hapus
            RefreshData();
            GenerateKodeItem();
        }

        private void RefreshData()
        {
            gridControl1.DataSource = item.Select( x => new { x.kode_item, x.nama_item, x.harga_beli, x.harga_jual, x.quantity });
        }

        private void GenerateKodeItem()
        {
            var rnd = new Random();
            labelControl1.Text = rnd.Next(1, 10).ToString();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            navigationFrame1.SelectedPage = gudang_laporan;
        }
    }
}
