using DoAnNet.Admin;
using DoAnNet.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DoAnNet
{
    public partial class frmUser : Form
    {

        public frmUser()
        {
            InitializeComponent();
        }
        public frmUser(String userName)
        {
            InitializeComponent();
            lblUser.Text = userName;
        }
       
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void btnDashbord_Click(object sender, EventArgs e)
        {
            uS_BangDK1.Visible = true;
            uS_BangDK1.BringToFront();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            uS_BangDK1.Visible=false;
            uS_AddMedicine1.Visible = false;
            uS_ViewMedicine1.Visible=false;
            uS_UpdateMedicine1.Visible = false;
            uS_ViewCheckValidity1.Visible = false;
            uS_SellMedicine1.Visible = false;
            btnDashbord.PerformClick();
            uS_HoaDon1.Visible = false;
        }

        private void btnAddMedicine_Click(object sender, EventArgs e)
        {
            uS_AddMedicine1.Visible = true;
            uS_AddMedicine1.BringToFront();

        }

        private void btnViewMedicine_Click(object sender, EventArgs e)
        {
            uS_ViewMedicine1.Visible=true;
            uS_ViewMedicine1.BringToFront();
        }

        private void btnUpdateMedi_Click(object sender, EventArgs e)
        {
            uS_UpdateMedicine1.Visible = true;
            uS_UpdateMedicine1.BringToFront();
        }

        private void btnMeVaChk_Click(object sender, EventArgs e)
        {
            uS_ViewCheckValidity1.Visible = true;
            uS_ViewCheckValidity1.BringToFront();
        }

        private void btnSellMedicine_Click(object sender, EventArgs e)
        {
            uS_SellMedicine1.Visible = true;
            uS_SellMedicine1.BringToFront();
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            uS_RevenueStatistics1.Visible = true;
            uS_RevenueStatistics1.BringToFront();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            uS_HoaDon1.Visible = true;
            uS_HoaDon1.BringToFront();
        }

        private void uS_HoaDon1_Load(object sender, EventArgs e)
        {

        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }
    }
}
