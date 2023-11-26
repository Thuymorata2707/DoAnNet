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
    public partial class US_UpdateMedicine : UserControl
    {
        function fn = new function();
        String query;
        public US_UpdateMedicine()
        {
            InitializeComponent();
        }
        private void clearAll()
        {
            txtMedicineId.Clear();
            txtMediName.Clear();
            txtMediNumber.Clear();
            txtMDate.ResetText();
            txtEDate.ResetText();
            txtAddQuantity.Clear();
            txtAvailableQuantity.Clear();
            txtPricePerUnit.Clear();

            if (txtAddQuantity.Text != "0")
            {
                txtAddQuantity.Text = "0";
            }
            else
            {
                txtAddQuantity.Text = "0";
            }
        }
        Int64 totalQuantity;
        private void btnUpDate_Click(object sender, EventArgs e)
        {
            String mname = txtMediName.Text;
            String mnumber = txtMediNumber.Text;
            String mdate = txtMDate.Text;
            String edate = txtEDate.Text;
            Int64 quantity = Int64.Parse(txtAvailableQuantity.Text);
            Int64 addquantity = Int64.Parse(txtAddQuantity.Text);
            Int64 unitprice = Int64.Parse(txtPricePerUnit.Text);

            totalQuantity = quantity + addquantity;

            query = "update medic set mname = '" + mname + "', mnumber = '" + mnumber + "', mDate = '" + mdate + "', eDate = '" + edate + "', quantity = " + totalQuantity + ", perUnit = " + unitprice + " where mid = '" + txtMedicineId.Text + "'";
            fn.setData(query, "Đã cập nhật chi tiết thuốc");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtMedicineId.Text != "") 
            {
                query = "select * from medic where mid = '" + txtMedicineId.Text + "'";
                DataSet ds = fn.getData(query);
                if (ds.Tables[0].Rows.Count != 0)
                { 
                    txtMediName.Text = ds.Tables[0].Rows[0][2].ToString();
                    txtMediNumber.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtMDate.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtEDate.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtAvailableQuantity.Text = ds.Tables[0].Rows[0][6].ToString();
                    txtPricePerUnit.Text = ds.Tables[0].Rows[0][7].ToString();
                }
                else
                {
                    MessageBox.Show("Không có thuốc giống ID này: " + txtMedicineId.Text + " hiện hữu.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information );
                }
            }
            else
            {
                clearAll();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
