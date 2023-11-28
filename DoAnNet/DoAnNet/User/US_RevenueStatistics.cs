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
using TheArtOfDevHtmlRenderer.Adapters;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace DoAnNet.User
{
    public partial class US_RevenueStatistics : UserControl
    {
        function fn = new function();
        String query;
        DataSet ds;
        public US_RevenueStatistics()
        {
            InitializeComponent();
        }

        public void getData()
        {
            //string ngayChon = txtTuNgay.Value.ToString("dd-MM-yyyy");
            //txtTuNgay.Text = ngayChon;
            //string ngayDen = txtDenNgay.Value.ToString("dd-MM-yyyy");
            //txtDenNgay.Text = ngayDen;
            string query = string.Format(
                        "SELECT * " +
                        "FROM HoaDon " +
                        "WHERE TRY_CONVERT(datetime, NgayMua, 103) BETWEEN '" + txtTuNgay.Text + "' AND '" + txtDenNgay.Text + "'");
            DataTable tb = fn.LayDuLieu(query);
            dgvHoaDon.DataSource = tb;
        }

        private void btnUpDate_Click(object sender, EventArgs e)
        {
            getData();
        }
    }
}
