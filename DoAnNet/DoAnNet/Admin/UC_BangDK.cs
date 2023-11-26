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
    public partial class UC_BangDK : UserControl
    {
        function fn = new function();
        String query;
        DataSet ds;
        public UC_BangDK()
        {
            InitializeComponent();
        }

        private void UC_BangDK_Load(object sender, EventArgs e)
        {
            query = "select count (userRole) from users where userRole = 'Admin'";
            ds= fn.getData(query);
            setLable(ds, lblAdmin);

            query = "select count (userRole) from users where userRole = 'Duoc si'";
            ds = fn.getData(query);
            setLable(ds, lblUser);
        }
        private void setLable (DataSet ds, Label lbl) 
        {
            if (ds.Tables[0].Rows.Count != 0)
            {
                lbl.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                lbl.Text = "0";
            }
        }

        private void btnSyn_Click(object sender, EventArgs e)
        {
            UC_BangDK_Load(this,null);
        }
    }
}
