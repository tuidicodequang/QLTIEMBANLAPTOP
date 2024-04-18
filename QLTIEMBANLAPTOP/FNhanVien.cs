using FontAwesome.Sharp;
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
    public partial class FNhanVien : Form
    {
        KetNoi db=new KetNoi();
        public FNhanVien()
        {
            InitializeComponent();
        }

        private void FNhanVien_Load(object sender, EventArgs e)
        {
            LoadBangNhanVien();
        }



        public DataTable getAllNhanVien()
        {
            SqlCommand cmd = new SqlCommand("select * from V_ThongTinNhanVien", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
        public void LoadBangNhanVien()
        {
            DataTable nhanviens = getAllNhanVien();
            dgvNhanVien.DataSource = nhanviens;
        }

   
        

        public bool themNhanVien(string MaNV, string TenDangNhap, string HoTen, string MatKhau, string SDT, string ChucVu)
        {
            SqlCommand command = new SqlCommand("proc_ThemTaiKhoan", db.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = MaNV;
            command.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar).Value = TenDangNhap;
            command.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = HoTen;
            command.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = MatKhau;
            command.Parameters.Add("@SDT", SqlDbType.NVarChar).Value = SDT;
            command.Parameters.Add("@ChucVu", SqlDbType.NVarChar).Value = ChucVu;

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


        public bool xoaNhanVien(string MaNV)
        {
            SqlCommand command = new SqlCommand("proc_XoaTaiKhoan", db.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = MaNV;

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

  

        public bool suaThongTinNhanVien(string MaNV, string TenDangNhap, string HoTen, string MatKhau, string SDT, string ChucVu)
        {
            SqlCommand command = new SqlCommand("proc_SuaThongTinTaiKhoan", db.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = MaNV;
            command.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar).Value = TenDangNhap;
            command.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = HoTen;
            command.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = MatKhau;
            command.Parameters.Add("@SDT", SqlDbType.NVarChar).Value = SDT;
            command.Parameters.Add("@ChucVu", SqlDbType.NVarChar).Value = ChucVu;

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


     



  
        private void btXoa_Click(object sender, EventArgs e)
        {
            string MaNV = txtMaNV.Text;
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa nhân viên không?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bool result = xoaNhanVien(MaNV);
                if (result)
                {
                    MessageBox.Show("Xóa nhân viên thành công!");
                }
                else
                {
                    MessageBox.Show("Xóa nhân viên thất bại!");
                }
                LoadBangNhanVien();
            }
            else
            {
                MessageBox.Show("Thao tác xóa đã bị hủy bởi người dùng.");
            }
        }

  

        private void buttExit_Click(object sender, EventArgs e)
        {
            panelUpdate.Visible = false;
            dgvNhanVien.Dock = DockStyle.Bottom;
        }

        private void dgvNhanVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btXoa.Visible = true;
            dgvNhanVien.Dock = DockStyle.None;
            panelUpdate.Visible = true;
            labelUpDate.Text = "Cập nhật nhân viên";
            btThem.Visible = false;
            btUpdate.Visible = true;
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin của dòng được chọn
                DataGridViewRow selectedRow = dgvNhanVien.Rows[e.RowIndex];

                // Lấy giá trị của các cột trong dòng được chọn
                txtMaNV.Text = selectedRow.Cells["MaNV"].Value.ToString();
                txtTenNV.Text = selectedRow.Cells["HoTen"].Value.ToString();
                txtMatKhau.Text = selectedRow.Cells["MatKhau"].Value.ToString();
                txtTendanhnhap.Text = selectedRow.Cells["Tendangnhap"].Value.ToString();
                cboChucVu.Text = selectedRow.Cells["ChucVu"].Value.ToString();
                txtSDT.Text = selectedRow.Cells["SDT"].Value.ToString();

            }
        }

        private void btADD_Click(object sender, EventArgs e)
        {
            btXoa.Visible = false;
            txtMaNV.Text = null;
            txtMatKhau.Text = null;
            txtSDT.Text = null;
            txtTenNV.Text= null;
            txtTendanhnhap.Text = null;
            btThem.Visible = true;
            dgvNhanVien.Dock = DockStyle.None;
            panelUpdate.Visible = true;
            labelUpDate.Text = "Thêm nhân viên mới";
            btUpdate.Visible = false;
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            string MaNV = txtMaNV.Text;
            string TenDangNhap = txtTendanhnhap.Text;
            string HoTen = txtTenNV.Text;
            string MatKhau = txtMatKhau.Text;
            string SDT = txtSDT.Text;
            string ChucVu = cboChucVu.Text;
            bool result = themNhanVien(MaNV, TenDangNhap, HoTen, MatKhau, SDT, ChucVu);
            if (result)
            {
                MessageBox.Show("Thêm tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại!");
            }
            LoadBangNhanVien();
        }

        private void btUpdate_Click_1(object sender, EventArgs e)
        {
            string MaNV = txtMaNV.Text;
            string TenDangNhap = txtTendanhnhap.Text;
            string HoTen = txtTenNV.Text;
            string MatKhau = txtMatKhau.Text;
            string SDT = txtSDT.Text;
            string ChucVu = cboChucVu.Text;
            bool result = suaThongTinNhanVien(MaNV, TenDangNhap, HoTen, MatKhau, SDT, ChucVu);
            if (result)
            {
                MessageBox.Show("Cập nhật nhân viên thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật nhân viên thất bại!");
            }
            LoadBangNhanVien();
        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {
            string searchString = bunifuTextBox2.Text.Trim();

            // Mở kết nối với cơ sở dữ liệu
            db.openConnection();

            // Tạo một đối tượng Command để thực thi câu lệnh SELECT từ table-valued function
            using (SqlCommand command = new SqlCommand("SELECT * FROM func_getNhanVienListByString(@string)", db.getConnection))
            {
                // Thêm tham số cho hàm tìm kiếm khách hàng
                command.Parameters.AddWithValue("@string", searchString);

                // Tạo một đối tượng Adapter để lấy dữ liệu từ table-valued function
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    // Tạo một đối tượng DataTable để chứa dữ liệu
                    DataTable table = new DataTable();

                    // Đổ dữ liệu từ Adapter vào DataTable
                    adapter.Fill(table);

                    // Đặt dữ liệu từ DataTable vào DataGridView dgvKhachHang
                    dgvNhanVien.DataSource = table;
                }
            }
        }
    }
}
