using LeNghia.add;
using LeNghia.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeNghia
{
    public partial class Form1 : Form
    {
        SQL.KetNoi_SQL db;
        SqlConnection con;

        public Form1()
        {
            InitializeComponent();

            db = new SQL.KetNoi_SQL();
            LoaiDSNhom();
        }

        void LoaiDSNhom()
        {
            var ls = db.Nhoms.ToList();
            dataGridView2.AutoGenerateColumns = false;
            dbNhom.DataSource = ls;
            dataGridView2.DataSource = dbNhom;
        }

        void LoadLienLac()
        {
            db = new SQL.KetNoi_SQL();
            var ls = db.LienLacs.ToList();
            dataGridView1.AutoGenerateColumns = false;
            dbLienLac.DataSource = ls;
            dataGridView1.DataSource = dbLienLac;
        }
        void LoadNhom()
        {
            db = new SQL.KetNoi_SQL();
            var ls = db.Nhoms.ToList();
            dataGridView2.AutoGenerateColumns = false;
            dbNhom.DataSource = ls;
            dataGridView2.DataSource = dbNhom;
        }
        void LoaiDsLienLac(Nhom nhom)
        {
            var ls = db.LienLacs.Where(e => e.MaNhom == nhom.MaNhom).ToList();

            dataGridView1.AutoGenerateColumns = false;
            dbLienLac.DataSource = ls;
            dataGridView1.DataSource = dbLienLac;
        }

        private void dbNhom_CurrentChanged(object sender, EventArgs e)
        {
            var nhom = dbNhom.Current as Nhom;
            if (nhom != null)
            {
                LoaiDsLienLac(nhom);
            }
        }

        private void bntXoaNhom_Click(object sender, EventArgs e)
        {
            var nhom = dbNhom.Current as Nhom;
            var ob1 = db.Nhoms.Where(t => t.MaNhom == nhom.MaNhom).FirstOrDefault();


            if (ob1 == null)
            {
                MessageBox.Show("Không thể xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var rs = MessageBox.Show("Bạn có muốn xóa Nhóm ' " + nhom.TenNhom + " ' không ?",
                "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (rs == DialogResult.OK)
            {

                if (nhom != null)
                {
                    db.Nhoms.Remove(ob1);
                }
                db.SaveChanges();
                var lop = dbNhom.Current as Nhom;
                LoaiDsLienLac(lop);
                MessageBox.Show("Xóa Thành Công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bntXoaLienLac_Click(object sender, EventArgs e)
        {
            var lienlac = dbLienLac.Current as LienLac;
            var ob1 = db.LienLacs.Where(t => t.MaLienLac == lienlac.MaLienLac).FirstOrDefault();


            if (ob1 == null)
            {
                MessageBox.Show("Không thể xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var rs = MessageBox.Show("Bạn có muốn xóa Nhóm ' " + lienlac.TenGoi + " ' không ?",
                "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (rs == DialogResult.OK)
            {

                if (lienlac != null)
                {
                    db.LienLacs.Remove(ob1);
                }
                db.SaveChanges();
                var lop = dbLienLac.Current as Nhom;
                LoaiDsLienLac(lop);
                MessageBox.Show("Xóa Thành Công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            var f = new ThemNhom();
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadDSLop();
            }
        }
        void LoadDSLop()
        {
            var ls = db.Nhoms.ToList();
            dataGridView2.AutoGenerateColumns = false;
            dbNhom.DataSource = ls;
            dataGridView2.DataSource = dbNhom;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var f = new ThemLienLac();
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadDSLop();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            laTen.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            //laDiaChi.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            laEmail.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            laSDT.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            LoadDS();
        }
        void LoadDS()
        {
            
            db = new KetNoi_SQL();
            var ls = db.LienLacs.ToList();
            dataGridView1.AutoGenerateColumns = false;
            dbLienLac.DataSource = ls;
            dataGridView1.DataSource = dbLienLac;
        }
        void LoadDSNhom()
        {
            db = new KetNoi_SQL();
            var s = db.LienLacs.ToList();
            dataGridView2.AutoGenerateColumns = false;
            dbNhom.DataSource = s;
            dataGridView2.DataSource = dbNhom;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            LoadDSNhom();
        }
    }
}
