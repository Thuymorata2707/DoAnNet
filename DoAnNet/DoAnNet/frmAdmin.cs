using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnNet
{
    public partial class frmAdmin : Form
    {
        String user = "";
        public frmAdmin()
        {
            InitializeComponent();
        }
        public string ID
        {
            get { return user.ToString(); }
        }
        public frmAdmin (String userName)
        {
            InitializeComponent();
            lblUserName.Text = userName;
            user = userName;
            uC_ViewUser1.ID = ID;
            uC_Profile1.ID = ID;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();    
        }

        private void btnDashbord_Click(object sender, EventArgs e)
        {
            uC_BangDK1.Visible = true;
            uC_BangDK1.BringToFront();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            uC_BangDK1.Visible=false;
            btnDashbord.PerformClick();
            uC_ViewUser1.Visible=false;
            uC_AddUser1.Visible = false;    
            uC_Profile1.Visible=false;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            uC_AddUser1.Visible = true;
            uC_AddUser1.BringToFront(); 
        }

     

        private void btnViewUser_Click(object sender, EventArgs e)
        {
            uC_ViewUser1.Visible = true;
            uC_ViewUser1.BringToFront();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            uC_Profile1.Visible = true;
            uC_Profile1.BringToFront();
        }
    }
}
