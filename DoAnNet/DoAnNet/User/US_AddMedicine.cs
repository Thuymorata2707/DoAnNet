using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnNet.User
{
    public partial class US_AddMedicine : UserControl
    {
        function fn = new function();
        String query;
        public US_AddMedicine()
        {
            InitializeComponent();
        }

        private void btnAddP_Click(object sender, EventArgs e)
        {
           if(txtMediId.Text !="" && txtMediNumber.Text!= "" && txtMediNumber.Text!= "" && txtQuanlity.Text != "" && txtPricePerUnit.Text!= "")
           {
                String mid = txtMediId.Text;
                String mname = txtMediName.Text;
                String mnumber = txtMediNumber.Text;
                String mdate = txtManuFact.Text;
                String edate = txtExpriceMedi.Text;
                Int64 quanlity = Int64.Parse(txtQuanlity.Text);
                Int64 perunit = Int64.Parse(txtPricePerUnit.Text);

                query = "insert into medic (mid, mname, mnumber, mDate, eDate, quantity, perUnit) values ('" + mid + "','" + mname + "','" + mnumber + "', '" + mdate + "', '" + edate + "'," + quanlity + "," + perunit + " )";
                fn.setData(query, "Thuốc được thêm vào dữ liệu!");
           }
           else
           {
                MessageBox.Show("Nhập tất cả dữ liệu.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning );
           }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            clearAll();
        }
        public void clearAll()
        {
            txtMediId.Clear();
            txtMediName.Clear();
            txtMediNumber.Clear();
            txtPricePerUnit.Clear();
            txtQuanlity.Clear();
            txtManuFact.ResetText();
            txtExpriceMedi.ResetText();
        }

        private void US_AddMedicine_Load(object sender, EventArgs e)
        {

        }
    }
}
