using LeNghia.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeNghia.add
{
    public partial class ThemLienLac : Form
    {

        KetNoi_SQL db;
        LienLac lienLac;
        public ThemLienLac(LienLac _lienlac = null)
        {
            InitializeComponent();

            lienLac = _lienlac;
            if (lienLac != null)
            {
                txtTen.Text = lienLac.TenGoi;
                txtMail.Text = lienLac.Email;
                //txtSDT.Text = lienLac.SoDienThoai;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lienLac == null)
            {
                //Thêm
                lienLac = new LienLac
                {
                    MaLienLac = Guid.NewGuid().ToString(),
                    MaNhom = Guid.NewGuid().ToString(),
                    TenGoi = txtTen.Text,
                    Email = txtMail.Text,
                    //   SoDienThoai = txtSDT.Text;
                };
                db = new KetNoi_SQL();
                db.LienLacs.Add(lienLac);
                db.SaveChanges();
                MessageBox.Show("Bạn đã thêm Thành Công ' " + lienLac.TenGoi + " '.", "Thông Báo");
                DialogResult = DialogResult.OK;
            }
        }
    }
}
