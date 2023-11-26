using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnNet.Admin
{
    public partial class UC_AddUser : UserControl
    {
        function fn = new function();
        String query;
        public UC_AddUser()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            String role= txtRole.Text;
            String name = txtName.Text;
            String dob = txtDob.Text;
            Int64 mobile = Int64.Parse(txtPhoneNumber.Text);
            String email= txtEmail.Text;
            String pass= txtPassword.Text;
            String username = txtUserName.Text;

            try
            {
                query = "insert into users (userRole,name,dob,mobile,email,username,pass) values ('" + role + "','" + name + "','" + dob + "'," + mobile + ",'" + email + "', '" + username + "','" + pass + "')";
                fn.setData(query, "Đăng ký thành công.");
            }
            catch (Exception) 
            { 
                MessageBox.Show("Username đã tồn tại.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            clearAll();
        }
        public void clearAll()
        {
            txtName.Clear();
            txtDob.ResetText();
            txtEmail.Clear();
            txtPhoneNumber.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            txtRole.SelectedIndex = -1;
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            query = "select * from users where username = '" + txtUserName.Text + "'";
            DataSet ds =fn.getData(query);

            if (ds.Tables[0].Rows.Count == 0)
            {
                pictureAddUser.ImageLocation = @"D:\.Net\DoAnNet\image_pharmacy\yes.png";
            }
            else
            {
                pictureAddUser.ImageLocation = @"D:\.Net\DoAnNet\image_pharmacy\no.png";
            }
        }
    }
}
