using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTIEMBANLAPTOP
{
    public partial class FKhuyenMai : Form
    {
        KetNoi db=new KetNoi();
        public FKhuyenMai()
        {
            InitializeComponent();
            LoadBangKhuyenMai();
           
        }
        public DataTable getAllKhuyenMai()
        {
            SqlCommand cmd = new SqlCommand("select * from V_KhuyenMai", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
        public void LoadBangKhuyenMai()
        {
            DataTable nhacungcaps = getAllKhuyenMai();
            dgvKhuyenMai.DataSource = nhacungcaps;
        }

        private void FKhuyenMai_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string MaKM = txtMaKM.Text;
            string MaSP = txtMaSP.Text;
            decimal GiaTriKhuyenMai= Convert.ToDecimal(txtGiaTriKhuyenMai.Text);
            int Soluong = Convert.ToInt32 (txtSoLuong.Text);
            DateTime thoigianbatdau = dateTimePicker1.Value;
            DateTime thoigianketthuc=dateTimePicker2.Value;
            bool result = themKhuyenMai(MaKM, MaSP, GiaTriKhuyenMai, Soluong, thoigianbatdau, thoigianketthuc);
            if (result)
            {
                MessageBox.Show("Thêm khuyến mãi thành công!");
            }
            else
            {
                MessageBox.Show("Thêm khuyến mãi thất bại!");
            }
            LoadBangKhuyenMai();
        }
        public bool themKhuyenMai(string MaKM, string MaSP, decimal GiaTriKhuyenMai, int SoLuong, DateTime thoigianbatdau, DateTime thoigianketthuc)
        {
            SqlCommand command = new SqlCommand("proc_InsertNewKhuyenMai", db.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaKM", SqlDbType.VarChar).Value = MaKM;
            command.Parameters.Add("@MaSP", SqlDbType.VarChar).Value = MaSP;
            command.Parameters.Add("@GiaTriKhuyenMai", SqlDbType.Decimal).Value = GiaTriKhuyenMai;
            command.Parameters.Add("@SoLuong", SqlDbType.Int).Value = SoLuong;
            command.Parameters.Add("@ThoiGianBatDau", SqlDbType.Date).Value = thoigianbatdau;
            command.Parameters.Add("@ThoiGianKetThuc", SqlDbType.Date).Value = thoigianketthuc;

            db.openConnection();
            if (command.ExecuteNonQuery() > 0)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

       
        public bool suaThongTinKhuyenMai(string MaKM, string MaSP, decimal GiaTriKhuyenMai, int SoLuong, DateTime ThoiGianBatDau, DateTime ThoiGianKetThuc)
        {
            SqlCommand command = new SqlCommand("proc_suaKhuyenMai", db.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaKM", SqlDbType.NVarChar).Value = MaKM;
            command.Parameters.Add("@MaSP", SqlDbType.NVarChar).Value = MaSP;
            command.Parameters.Add("@GiaTriKhuyenMai", SqlDbType.Decimal).Value = GiaTriKhuyenMai;
            command.Parameters.Add("@SoLuong", SqlDbType.Int).Value = SoLuong;
            command.Parameters.Add("@ThoiGianBatDau", SqlDbType.Date).Value = ThoiGianBatDau;
            command.Parameters.Add("@ThoiGianKetThuc", SqlDbType.Date).Value = ThoiGianKetThuc;

            db.openConnection();
            try
            {
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    db.closeConnection();
                    return true;
                }
                else
                {
                    db.closeConnection();
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Lỗi SQL: " + ex.Message);
                return false;
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            string MaKM = txtMaKM.Text;
            string MaSP = txtMaSP.Text;
            decimal GiaTriKhuyenMai = Convert.ToDecimal(txtGiaTriKhuyenMai.Text);
            int SoLuong = Convert.ToInt32(txtSoLuong.Text);
            DateTime ThoiGianBatDau = dateTimePicker1.Value;
            DateTime ThoiGianKetThuc = dateTimePicker2.Value;

            bool result = suaThongTinKhuyenMai(MaKM, MaSP, GiaTriKhuyenMai, SoLuong, ThoiGianBatDau, ThoiGianKetThuc);
            if (result)
            {
                MessageBox.Show("Cập nhật khuyến mãi thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật khuyến mãi thất bại!");
            }
            LoadBangKhuyenMai();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            string MaKM = txtMaKM.Text; // hoặc lấy từ dòng được chọn trong DataGridView

            // Gọi hàm xóa khuyến mãi
            bool result = XoaKhuyenMai(MaKM);

            // Hiển thị thông báo kết quả
            if (result)
            {
                MessageBox.Show("Xóa khuyến mãi thành công!");
            }
            else
            {
                MessageBox.Show("Xóa khuyến mãi thất bại!");
            }

            // Sau khi xóa, cần load lại danh sách khuyến mãi để cập nhật
            LoadBangKhuyenMai();
        }

        public bool XoaKhuyenMai(string MaKM)
        {
            SqlCommand command = new SqlCommand("proc_XoaKhuyenMai", db.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaKM", SqlDbType.NVarChar).Value = MaKM;

            db.openConnection();
            if (command.ExecuteNonQuery() > 0)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

        private void dgvKhuyenMai_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvKhuyenMai.RowCount)
            {
                DataGridViewRow selectedRow = dgvKhuyenMai.Rows[e.RowIndex];
                txtMaKM.Text = selectedRow.Cells["MaKM"].Value.ToString();
                txtMaSP.Text = selectedRow.Cells["MaSP"].Value.ToString();
                txtGiaTriKhuyenMai.Text = selectedRow.Cells["GiaTriKhuyenMai"].Value.ToString();
                txtSoLuong.Text = selectedRow.Cells["SoLuong"].Value.ToString();
                dateTimePicker1.Value = (DateTime)selectedRow.Cells["ThoiGianBatDau"].Value;
                dateTimePicker2.Value = (DateTime)selectedRow.Cells["ThoiGianKetThuc"].Value;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dgvKhuyenMai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }

}
