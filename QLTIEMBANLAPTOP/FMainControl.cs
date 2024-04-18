using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.IO;

using System.Windows.Media.Media3D;
using QLTIEMBANLAPTOP;
using QUANLYGARAGE;
using DashboardApp;
using DOAN;
using TiemDien;

namespace DoAn_2
{
    public partial class FMainControl : Form
    {
        public string TK { get; set; }
    
        private IconButton currentbtn;
        private Panel lefborderbtn;


        public FMainControl()
        {
           
            InitializeComponent();
            lefborderbtn = new Panel();
            lefborderbtn.Size = new Size(7, 50);
            PanelMenu.Controls.Add(lefborderbtn);
            labelcon.Text = "Trang Chủ";
            FdoanhThu f = new FdoanhThu();
            OpenchildForm(f);
            timer1.Start();//dong ho
            
        }
        private Form currentFormChild;
        private void OpenchildForm(Form childFrom)
        {
            if (currentFormChild != null)
            {
                
                currentFormChild.Close();
               
            }
            currentFormChild = childFrom;
            childFrom.TopLevel = false;
            childFrom.FormBorderStyle = FormBorderStyle.None;
            childFrom.Dock = DockStyle.Fill;
            paneltrangcon.Controls.Add(childFrom);
            paneltrangcon.Tag = childFrom;
            childFrom.BringToFront();
            childFrom.Show();
        }

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172,126,241);
            public static Color color2 = Color.FromArgb(249,118,176);
            public static Color color3 = Color.FromArgb(253,138,114);
            public static Color color4 = Color.FromArgb(95,77,221);
            public static Color color5 = Color.FromArgb(249,88,155);
            public static Color color6 = Color.FromArgb(24,161,251);
            public static Color color7 = Color.FromArgb(251, 192, 17);

        }

        private void activebtn(object senderbtn, Color color)
        {
            if(senderbtn != null)
            {
                disablebtn();
                //button
                currentbtn = (IconButton)senderbtn;
                currentbtn.BackColor = Color.FromArgb(37,36,81);
                currentbtn.ForeColor = color;
                currentbtn.TextAlign = ContentAlignment.MiddleCenter;
                currentbtn.IconColor = color;
                currentbtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentbtn.ImageAlign = ContentAlignment.MiddleRight;

                //left border btn
                lefborderbtn.BackColor = color;
                lefborderbtn.Location = new Point(0,currentbtn.Location.Y);
                lefborderbtn.Visible = true;
                lefborderbtn.BringToFront();

                //icon small
                iconmenusmall.IconChar = currentbtn.IconChar;
                iconmenusmall.IconColor = color;

            }
        }

        private void disablebtn()
        {
            if(currentbtn != null)
            {
                //button

                currentbtn.BackColor = Color.FromArgb(34, 36, 49);
                currentbtn.ForeColor = Color.Gainsboro;
                currentbtn.TextAlign = ContentAlignment.MiddleLeft;
                currentbtn.IconColor = Color.Gainsboro;
                currentbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentbtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
       
        private void btnhome_Click(object sender, EventArgs e)
        {
            activebtn(sender, RGBColors.color2);
            FdoanhThu f=new FdoanhThu();
            OpenchildForm(f);
            labelcon.Text = "Trang Chủ";
        }

        private void btnorders_Click(object sender, EventArgs e)
        {
            FNhanVien f  = new FNhanVien();
            OpenchildForm(f);
            activebtn(sender, RGBColors.color1);
           
            labelcon.Text = btnNV.Text;
        }

       

        private void btndashboard_Click(object sender, EventArgs e)
        {
            activebtn(sender, RGBColors.color4);
            FThemHoaDon f=new FThemHoaDon();
            OpenchildForm(f);
            labelcon.Text = btnHD.Text;
        }

        private void btnnhanvien_Click(object sender, EventArgs e)
        {
            activebtn(sender, RGBColors.color6);
            FThongTinKhachHang f =new FThongTinKhachHang();
            OpenchildForm(f);
            labelcon.Text=btnKH.Text;
        }

        private void btnluong_Click(object sender, EventArgs e)
        {
            activebtn(sender, RGBColors.color3);
        FSanPham f =new FSanPham(); 
            OpenchildForm(f);
            labelcon.Text = btnSP.Text;
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            activebtn(sender, RGBColors.color7);
            this.Hide();
            Flogin formLogin = (Flogin)Application.OpenForms["flogin"];
            this.Close();
            formLogin.Show();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam );

        private void panelTitlebar_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

       

        private void iconExit_Click(object sender, EventArgs e)
        {
            Flogin formLogin = (Flogin)Application.OpenForms["flogin"];
            formLogin.Close();
        }

        private void iconMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void iconZoom_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }

        }

        private void MainControl_Load(object sender, EventArgs e)
        {
       
            Flogin f=new Flogin();
            LabelUser.Text = "xin chào: "+TK;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            this.lbDateTime.Text = datetime.ToString("dd/MM/yyyy HH:mm:ss");
            
        }

        

        private void iconButton1_Click(object sender, EventArgs e)
        {
            activebtn(sender, RGBColors.color5);
             FThemHDNK f=new FThemHDNK();
            OpenchildForm(f);
            labelcon.Text = ButDT.Text;
        }

        private void labelGioBig_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            activebtn(sender, RGBColors.color7);
            FKhuyenMai f=new FKhuyenMai();
            OpenchildForm(f);
            labelcon.Text = ButKhuyenmai.Text;
        }
    }
}
