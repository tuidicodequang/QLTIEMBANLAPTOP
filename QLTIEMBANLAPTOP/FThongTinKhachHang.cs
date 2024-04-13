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
    public partial class FThongTinKhachHang : Form
    {
        KetNoi db =new KetNoi();
        public FThongTinKhachHang()
        {
            InitializeComponent();
        }

        private void FThongTinKhachHang_Load(object sender, EventArgs e)
        {
            LoadBangKhachHang();
        }
        public DataTable getAllKhachHang()
        {
            SqlCommand cmd = new SqlCommand("select * from V_KhachHang", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
        public void LoadBangKhachHang()
        {
            DataTable khachhangs = getAllKhachHang();
            dgvKhachHang.DataSource = khachhangs;
        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {
            string MaKH = txtMKH.Text;
            string TenKH = txtTenKH.Text;
            string SDT = txtSDT.Text;
            string DC = txtDC.Text;
            if (string.IsNullOrEmpty(MaKH))
            {
                MessageBox.Show("Please enter a valid value for 'MaKH'.");
                return;
            }
            db.openConnection();
            SqlCommand cmd = new SqlCommand("InsertNewKhachHang", db.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaKH", SqlDbType.NChar).Value = MaKH;
            cmd.Parameters.Add("@TenKH", SqlDbType.NVarChar).Value = TenKH;
            cmd.Parameters.Add("@SDT", SqlDbType.NChar).Value = SDT;
            cmd.Parameters.Add("@DC", SqlDbType.NChar).Value = DC;
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Thêm thành công!", "Add Customer", MessageBoxButtons.OK,
               MessageBoxIcon.Information);
                db.closeConnection();
            }
            else
            {
                MessageBox.Show("Thêm thất bại", "Add Customer", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                db.closeConnection();
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
          
                string MaKH = txtMKH.Text;
                string TenKH = txtTenKH.Text;
                string SDT = txtSDT.Text;
                string DC = txtDC.Text;
                if (string.IsNullOrEmpty(MaKH))
                {
                    MessageBox.Show("Please select a customer to update.");
                    return;
                }
                db.openConnection();
                SqlCommand cmd = new SqlCommand("UpdateKhachHang", db.getConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaKH", SqlDbType.NChar).Value = MaKH;
                cmd.Parameters.Add("@TenKH", SqlDbType.NVarChar).Value = TenKH;
                cmd.Parameters.Add("@SDT", SqlDbType.NChar).Value = SDT;
                cmd.Parameters.Add("@DC", SqlDbType.NChar).Value = DC;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Cập nhật thành công!", "Update Customer", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                    db.closeConnection();
                    LoadBangKhachHang(); // Cập nhật lại danh sách khách hàng sau khi sửa
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại", "Update Customer", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                    db.closeConnection();
                }
            }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin của dòng được chọn
                DataGridViewRow selectedRow = dgvKhachHang.Rows[e.RowIndex];

                // Lấy giá trị của các cột trong dòng được chọn
                txtMKH.Text = selectedRow.Cells["MaKH"].Value.ToString();
                txtTenKH.Text = selectedRow.Cells["HoTen"].Value.ToString();
                txtDC.Text = selectedRow.Cells["DiaChi"].Value.ToString();
                txtSDT.Text = selectedRow.Cells["SDT"].Value.ToString();
            }
        }
    }
    }

