using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet
{
    public class GlobalData
    {
        private static GlobalData instance;

        // Biến toàn cục
        public int GlobalCounter { get; set; }

        private GlobalData()
        {
            // Khởi tạo các giá trị mặc định nếu cần
            GlobalCounter = 0;
        }

        public static GlobalData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GlobalData();
                }
                return instance;
            }
        }
    }

}
