using DOAN;
using DoAn_2;
using QUANLYGARAGE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTIEMBANLAPTOP
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
         // Application.Run(new FMainControl());
            Application.Run(new Flogin());
        //    Application.Run(new FSanPham());
          //Application.Run(new FKhachHang());


        }
    }
}
