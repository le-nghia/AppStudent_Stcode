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
    public partial class ThemNhom : Form
    {
        KetNoi_SQL db;
        Nhom nhom;
        public ThemNhom(Nhom _nhom = null)
        {
            InitializeComponent();

            nhom = _nhom;
            if (nhom != null)
            {
                txtTenN.Text = nhom.TenNhom;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nhom == null)
            {
                //Thêm
                nhom = new Nhom
                {
                    MaNhom = Guid.NewGuid().ToString(),
                    TenNhom = txtTenN.Text
                };
                db = new KetNoi_SQL();
                db.Nhoms.Add(nhom);
                db.SaveChanges();
                MessageBox.Show("Bạn đã thêm Thành Công ' " + nhom.TenNhom + " '.", "Thông Báo");
                DialogResult = DialogResult.OK;
            }
            else
            {
                // Cập nhật.
                db = new KetNoi_SQL();
                var _lopHoc = db.Nhoms.Where(t => t.MaNhom == nhom.MaNhom).FirstOrDefault();
                if (_lopHoc != null)
                {
                    _lopHoc.TenNhom = txtTenN.Text;
                    db.SaveChanges();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    throw new Exception("Lỗi Không Tìm Thấy Lớp.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void txtTenN_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
