using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLTIEMBANLAPTOP;


namespace TiemDien
{
    public partial class FTimSanPham : Form
    {
        public event Action<string, string, decimal> SanPhamSelected;
       
        KetNoi db = new KetNoi();
       

        public FTimSanPham()
        {
            InitializeComponent();
        }

        private void FTimSanPham_Load(object sender, EventArgs e)
        {
            db.openConnection();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM V_DanhSachSanPham", db.getConnection))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dgvSanPham.Columns.Clear();

                    // Thêm cột vào DataGridView
                    dgvSanPham.Columns.Add("MaSP", "Mã SP");
                    dgvSanPham.Columns.Add("TenSP", "Tên SP");
                    dgvSanPham.Columns.Add("LoaiSP", "Loại SP");
                    dgvSanPham.Columns.Add("GiaBan", "Giá");

                    while (reader.Read())
                    {
                        dgvSanPham.Rows.Add(
                            reader["MaSP"].ToString(),
                            reader["TenSP"].ToString(),
                            reader["LoaiSP"].ToString(),
                            reader["GiaBan"].ToString()
                        );
                    }
                }
                else
                {
                    MessageBox.Show("Danh sách sản phẩm trống. Vui lòng thêm sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            db.closeConnection();
        }

        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvSanPham.Rows.Count)
            {
                string selectedMaSP = dgvSanPham.Rows[e.RowIndex].Cells["MaSP"].Value.ToString();
                string selectedTenSP = dgvSanPham.Rows[e.RowIndex].Cells["TenSP"].Value.ToString();
                decimal selectedGiaSP = decimal.Parse(dgvSanPham.Rows[e.RowIndex].Cells["GiaBan"].Value.ToString());
                SanPhamSelected?.Invoke(selectedMaSP, selectedTenSP, selectedGiaSP);
                this.Close();
            }
        }
    }
}
