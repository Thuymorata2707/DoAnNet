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
    public partial class UC_TKDoanhThu : UserControl
    {
        public UC_TKDoanhThu()
        {
            InitializeComponent();
        }

        function fn = new function();
        String query;
        DataSet ds;

        public void loadRevenueChart()
        {
            // Truy vấn để lấy doanh thu từ bảng hóa đơn theo tháng
            query = "SELECT MONTH(CONVERT(datetime, NgayMua, 103)) AS Thang, SUM(TongTien) AS DoanhThu " +
                    "FROM HoaDon " +
                    "WHERE YEAR(CONVERT(datetime, NgayMua, 103)) = YEAR(GETDATE()) " +
                    "GROUP BY MONTH(CONVERT(datetime, NgayMua, 103))";

            // Lấy dữ liệu từ cơ sở dữ liệu
            ds = fn.getData(query);

            // Duyệt qua các dòng dữ liệu và thêm vào biểu đồ
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                int thang = Convert.ToInt32(row["Thang"]);
                float doanhThu = Convert.ToSingle(row["DoanhThu"]);

                // Thêm dữ liệu vào biểu đồ
                this.chart1.Series["Doanh Thu Theo Tháng"].Points.AddXY($"T{thang}", doanhThu);
            }
        }

    private void btnReload_Click(object sender, EventArgs e)
        {
            loadRevenueChart();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
