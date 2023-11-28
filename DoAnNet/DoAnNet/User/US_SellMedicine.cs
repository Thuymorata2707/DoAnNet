using System;
using DGVPrinterHelper;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace DoAnNet.User
{
    public partial class US_SellMedicine : UserControl
    {
        function fn = new function();
        String query;
        DataSet ds;
        public US_SellMedicine()
        {
            InitializeComponent();
        }

        private void US_SellMedicine_Load(object sender, EventArgs e)
        {
            US_SellMedicine_Load(sender, e, ds);
            TenDuocSi();
        }

        private void US_SellMedicine_Load(object sender, EventArgs e, DataSet ds)
        {
            listBoxMedicines.Items.Clear();
            query = "select mname from medic WHERE TRY_CONVERT(datetime, eDate, 103) >= GETDATE() AND quantity > 0\r\n";
            ds = fn.getData(query);

            for(int i = 0; i < ds.Tables[0].Rows.Count; i++) 
            {
                listBoxMedicines.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            listBoxMedicines.Items.Clear();
            query = "select mname from medic where mname like '" + txtSearch.Text + "%' and TRY_CONVERT(datetime, eDate, 103) >= GETDATE()  and quantity > '0'";
            ds = fn.getData(query);

            for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBoxMedicines.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        public void TenDuocSi()
        {
            string query = string.Format("select name from users where id = {0}", GlobalData.Instance.GlobalCounter);
            DataTable tb = fn.LayDuLieu(query);
            foreach (DataRow dr in tb.Rows)
            {
                txtDuocSi.Text = dr["name"].ToString();
            }
        }

        private void listBoxMedicines_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNoOfUnit.Clear();

            String name = listBoxMedicines.GetItemText(listBoxMedicines.SelectedItem);
            txtMediName.Text = name;
            query = "select id, eDate, perUnit from medic where mname = '" + name + "'";
            ds = fn.getData(query);
            txtMedicineId.Text = ds.Tables[0].Rows[0][0].ToString();
            txtExpriceDate.Text = ds.Tables[0].Rows[0][1].ToString();
            txtPricePerUnit.Text = ds.Tables[0].Rows[0][2].ToString();
        }

        private void txtNoOfUnit_TextChanged(object sender, EventArgs e)
        {
            if(txtNoOfUnit.Text != "")
            {
                Int64 unitPrice = Int64.Parse(txtPricePerUnit.Text);
                Int64 noOfUnit = Int64.Parse(txtNoOfUnit.Text);
                Int64 totalAmount = unitPrice * noOfUnit;
                txtTotalPrice.Text = totalAmount.ToString();
            }
            else
            {
                txtTotalPrice.Clear();
            }
        }
        protected int n, totalAmount = 0;
        protected Int64 quantity, newQuantity;
        private void btnAddToCard_Click(object sender, EventArgs e)
        {
            if(txtMedicineId.Text != "")
            {
                query ="select quantity from medic where id = '" + txtMedicineId.Text + "'";
                DataSet ds = fn.getData(query);

                quantity = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                newQuantity = Int64.Parse(txtNoOfUnit.Text);

                if(quantity - newQuantity >= 0)
                {
                    n = guna2DataGridView1.Rows.Add();
                    guna2DataGridView1.Rows[n].Cells[0].Value = txtMedicineId.Text;
                    guna2DataGridView1.Rows[n].Cells[1].Value = txtMediName.Text;
                    guna2DataGridView1.Rows[n].Cells[2].Value = txtExpriceDate.Text;
                    guna2DataGridView1.Rows[n].Cells[3].Value = txtPricePerUnit.Text;
                    guna2DataGridView1.Rows[n].Cells[4].Value = txtNoOfUnit.Text;
                    guna2DataGridView1.Rows[n].Cells[5].Value = txtTotalPrice.Text;

                    totalAmount = totalAmount + int.Parse(txtTotalPrice.Text);
                    lblTotal.Text = "Rs. " + totalAmount.ToString();
                    txtTotal.Text = totalAmount.ToString();

                    query = "update medic set quantity = '" + (quantity - newQuantity) + "' where id = '" + txtMedicineId.Text + "'";
                    fn.setData(query, "Thuốc đã được thêm vào hoá đơn.");

                }
                else
                {
                    MessageBox.Show("Thuốc hết hàng.\n Chỉ số" + quantity + " Sau ","Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                clearAll();
                US_SellMedicine_Load(this, null);
            }
            else
            {
                MessageBox.Show("Chọn thuốc trước tiên.", " Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        int valueAmount;
        String valueId;
        protected Int64 noOfUnit;

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                valueAmount = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                valueId = guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                noOfUnit = Int64.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            }
            catch(Exception )
            {

            }
            
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(valueId != null)
            {
                try
                {
                    guna2DataGridView1.Rows.RemoveAt(this.guna2DataGridView1.SelectedRows[0].Index);
                }
                catch
                {

                }
                finally 
                {
                    query = "select quantity from medic where mid = '" + valueId + "'";
                    ds = fn.getData(query);
                    quantity = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                    newQuantity = quantity + noOfUnit;

                    query = "update medic set quantity = '" + newQuantity + "' where mid = '" + valueId + "'";
                    fn.setData(query, "Thuốc đã được loại bỏ khỏi hoá đơn");
                    totalAmount = totalAmount - valueAmount;
                    lblTotal.Text = "Rs. " + totalAmount.ToString();
                    txtTotal.Text = "Rs. " + totalAmount.ToString();

                }
                US_SellMedicine_Load(this, null);
            }

        }

        

        private void btnPurChasePrint_Click(object sender, EventArgs e)
        {
            DGVPrinter print = new DGVPrinter();
            print.Title = "Hoá Đơn Thuốc";
            print.SubTitle = String.Format("Ngày :{0}", DateTime.Now.Date);
            print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            print.PageNumbers = true;
            print.PageNumberInHeader = false;
            print.PorportionalColumns = true;
            print.HeaderCellAlignment = StringAlignment.Near;
            print.Footer = "Tổng số tiền phải trả : " + lblTotal.Text;
            print.Footer = "Dược sĩ : " + txtDuocSi.Text;
            print.FooterSpacing = 15;
            print.PrintDataGridView(guna2DataGridView1);

            totalAmount = 0;
            lblTotal.Text = "Rs. 00";
            guna2DataGridView1.DataSource = 0;
            if (lblTotal.Text != "" && txtMaHD.Text != "")
            {
                String MaHD = txtMaHD.Text;
                String NgayMua = txtNgayMua.Text;
                Int64 TongTien = Int64.Parse(txtTotal.Text);

                query = "update HoaDon set NgayMua = '" + NgayMua + "', TongTien = " + TongTien + " where MaHD = '" + MaHD + "'";
                fn.setData(query, "HD được thêm vào dữ liệu!");
            }
            else
            {
                MessageBox.Show("Nhập tất cả dữ liệu.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            
        }

        private void btnThemCTHD_Click(object sender, EventArgs e)
        {
            if (txtNoOfUnit.Text != "" && txtTotalPrice.Text != "" && txtMaHD.Text != "" && txtNoOfUnit.Text != "")
            {
                String MaHD = txtMaHD.Text;
                String id = txtMedicineId.Text;
                String SoLuong = txtNoOfUnit.Text;
                Int64 ThanhTien = Int64.Parse(txtTotalPrice.Text);

                query = "insert into CTHoaDon (MaHD, id, SoLuong, ThanhTien) values ('" + MaHD + "','" + id + "','" + SoLuong + "', '" + ThanhTien + "')";
                fn.setData(query, "CTHD được thêm vào dữ liệu!");
            }
            else
            {
                MessageBox.Show("Nhập tất cả dữ liệu.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            US_SellMedicine_Load(this, null);
        }

        private void clearAll()
        {
            txtMedicineId.Clear();
            txtMediName.Clear();
            txtExpriceDate.ResetText();
            txtPricePerUnit.Clear();
            txtNoOfUnit.Clear();
        }

    }
}
