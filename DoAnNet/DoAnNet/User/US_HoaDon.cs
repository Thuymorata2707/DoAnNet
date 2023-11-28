using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DoAnNet.User
{
    public partial class US_HoaDon : UserControl
    {
        function fn = new function();
        String query;
        DataSet ds;

        public US_HoaDon()
        {
            InitializeComponent();
        }

        public void getData()
        {
            string query = string.Format("select * from HoaDon where NgayMua is not null");
            DataTable tb = fn.LayDuLieu(query);
            dgvHoaDon.DataSource = tb;
            

        }

        public void setText(bool a)
        {
            txtMaHD.Enabled = a;
            txtNgayBan.Enabled = a;
            txtQuanlity.Enabled = a;
            txtThanhTien.Enabled = a;
            txtCTHD.Enabled = a;
            txtTenThuoc.Enabled = a;
            txtSoLuong.Enabled = a;
            txtThanhTien.Enabled = a;
        }
        public void getCTHD()
        {
            string querry = string.Format("select MaCTHD, mname, SoLuong, ThanhTien from CTHoaDon, medic where CTHoaDon.Id = medic.Id and  MaHD = '" + txtMaHD.Text + "'");
            DataTable tbb = fn.LayDuLieu(querry);
            dgvCTHD.DataSource = tbb;
        }

        

        private void US_HoaDon_Load(object sender, EventArgs e)
        {
            getData();
            getCTHD();
            setText(false);
        }

        private void txtMediName_TextChanged(object sender, EventArgs e)
        {

        }

     

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                txtMaHD.Text = dgvHoaDon.Rows[r].Cells["MaHD"].Value.ToString();
                txtNgayBan.Text = dgvHoaDon.Rows[r].Cells["NgayMua"].Value.ToString();
                txtQuanlity.Text = dgvHoaDon.Rows[r].Cells["TongTien"].Value.ToString();
                getCTHD() ;
            }
        }

        private void dgvCTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                txtCTHD.Text = dgvCTHD.Rows[r].Cells["MaCTHD"].Value.ToString();
                txtTenThuoc.Text = dgvCTHD.Rows[r].Cells["mname"].Value.ToString();
                txtSoLuong.Text = dgvCTHD.Rows[r].Cells["SoLuong"].Value.ToString();
                txtThanhTien.Text = dgvCTHD.Rows[r].Cells["ThanhTien"].Value.ToString();
            }
        }
    }
}
