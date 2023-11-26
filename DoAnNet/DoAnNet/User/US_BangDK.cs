using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace DoAnNet.User
{
    public partial class US_BangDK : UserControl
    {
        function fn = new function();
        String query;
        DataSet ds;
        Int64 count;
        
        public US_BangDK()
        {
            InitializeComponent();
        }

        private void US_BangDK_Load(object sender, EventArgs e)
        {
           loadChart(); 
        }
       /* public void loadChart()
        {
            DateTime date = DateTime.Now;
            string formattedDate = date.ToString("dd/MM/yyyy");

            query = "select count(mname) from medic where eDate > '" + formattedDate + "'";
            ds = fn.getData(query);
            count = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            this.chart1.Series["Valid Medicines"].Points.AddXY("Medicine Validity Chart", count);

            query = "select count(mname) from medic where eDate <= '" + formattedDate + "'";
            ds = fn.getData(query);
            count = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            this.chart1.Series["Expried Medicines"].Points.AddXY("Medicine Validity Chart", count);
        }*/
        public void loadChart()
        { 
            query = "select count(mname) from medic where eDate >= getDate()";
            ds = fn.getData(query);
            count = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            this.chart1.Series["Thuốc Còn Hạn"].Points.AddXY("Medicine Validity Chart", count);

            query = "select count(mname) from medic where eDate <= getDate()";
            ds = fn.getData(query);
            count = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            this.chart1.Series["Thuốc Hết Hạn"].Points.AddXY("Medicine Validity Chart", count);
            //DateTime sqlDate = DateTime.Parse(ds.Tables[0].Rows[0][0].ToString());
            //string formattedDate = ConvertToDDMMYY(sqlDate);
        }
        private string ConvertToDDMMYY(DateTime sqlDate)
        {
            return sqlDate.ToString("dd/MM/yy");
        }
        
        // Sử dụng formattedDate trong biểu đồ của bạn

        /* public void loadChart()
         {
             // Truy vấn số lượng thuốc còn hạn sử dụng (eDate >= getDate())
             query = "select count(mname) from medic where eDate >= CONVERT(NVARCHAR, GETDATE(), 103)";
             ds = fn.getData(query);
             count = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
             this.chart1.Series["Thuoc Con Han"].Points.AddXY("Medicine Validity Chart", count);

             // Truy vấn số lượng thuốc đã hết hạn (eDate <= getDate())
             query = "select count(mname) from medic where eDate <= CONVERT(NVARCHAR, GETDATE(), 103)";
             ds = fn.getData(query);
             count = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
             this.chart1.Series["Thuoc Het Han"].Points.AddXY("Medicine Validity Chart", count);
         }
        */
        private void btnReload_Click(object sender, EventArgs e)
        {
            chart1.Series["Thuốc Còn Hạn"].Points.Clear();
            chart1.Series["Thuốc Hết Hạn"].Points.Clear();
            loadChart();
        }

      
    }
}
