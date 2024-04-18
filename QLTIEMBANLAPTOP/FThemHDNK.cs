using QLTIEMBANLAPTOP;
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

namespace TiemDien
{
    public partial class FThemHDNK : Form
    {
        KetNoi db=new KetNoi();
        DataTable nhacungcaps;
        DataTable dataTable=new DataTable();


        public FThemHDNK()
        {
            InitializeComponent();
            LoadTabXemHDNK();
            LoadTabThemHDNK();
            

        }
        private void LoadTabXemHDNK()
        {
            loadHoaDonNhapKho();
        }

        public void loadHoaDonNhapKho()
        {
            SqlCommand cmd = new SqlCommand("select * from V_HoaDonNhapKho", db.getConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvHoaDonNhapKho.DataSource = dt;
            dgvHoaDonNhapKho.Columns["MaHDNK"].HeaderText = "Mã hoá đơn nhập kho";
            dgvHoaDonNhapKho.Columns["NgayGD"].HeaderText = "Ngày giao dịch";
            dgvHoaDonNhapKho.Columns["TenNCC"].HeaderText = "Tên nhà cung cấp";
            dgvHoaDonNhapKho.Columns["MaNV"].HeaderText = "Mã nhân viên";
            dgvHoaDonNhapKho.Columns["TriGiaHD"].HeaderText = "Trị giá hoá đơn";
        }

        private void LoadTabThemHDNK()
        {
            TaoBangSanPhamDaChon();
            TaoMaHDNKRandom();
            LoadComboBoxCungCap();
            LoadBangSanPhamHoaDon();
        }
        private void TaoBangSanPhamDaChon()
        {
            dataTable.Columns.Add("MaSP", typeof(string));
            dataTable.Columns.Add("TenSP", typeof(string));
            dataTable.Columns.Add("SoLuong", typeof(int));
            dataTable.Columns.Add("GiaNhap", typeof(decimal));
        }

        private void button2_Click(object sender, EventArgs e)
        {
        
        }

        private void TaoMaHDNKRandom()
        {
            const string chars = "0123456789";
            Random random = new Random();
            char[] randomArray = new char[4];

            for (int i = 0; i < 4; i++)
            {
                randomArray[i] = chars[random.Next(chars.Length)];
            }
            textMaHD.Text ="HDNK"+ new string(randomArray);
        }

    

        private void LoadBangSanPhamHoaDon()
        {
            decimal ThanhTien = 0;
            decimal TongCong = 0;
            dgvSanPham.Columns.Clear();

            // Thêm cột vào DataGridView nếu chưa tồn tại
            if (dgvSanPham.Columns.Count == 0)
            {
                dgvSanPham.Columns.Add("MaSP", "Mã Sản Phẩm");
                dgvSanPham.Columns.Add("TenSP", "Tên Sản Phẩm");
                dgvSanPham.Columns.Add("SoLuong", "Số Lượng");
                dgvSanPham.Columns.Add("GiaNhap", "Gia Nhập");
                dgvSanPham.Columns.Add("TongTien", "Tổng Tiền");
            }

            dgvSanPham.Rows.Clear();

            // Load dữ liệu từ DataTable vào DataGridView
            foreach (DataRow row in dataTable.Rows)
            {
                string maSP = row["MaSP"].ToString();
                string tenSP = row["TenSP"].ToString();
                int soLuong = Convert.ToInt32(row["SoLuong"]);
                decimal donGia = Convert.ToDecimal(row["GiaNhap"]);
                dgvSanPham.Rows.Add(maSP, tenSP, soLuong, donGia, soLuong * donGia);
                TongCong += soLuong * donGia;
            }

            textThanhTien.Text = TongCong.ToString();
 
        }





        public bool themHoaDonNK(string MaHDNK, string MaNV, string MaNCC, DateTime NgayGD, decimal TriGiaHD)
        {
            SqlCommand command = new SqlCommand("proc_themHoaDonNhapKho", db.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaHDNK", SqlDbType.NChar).Value = MaHDNK;
            command.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = MaNV;
            command.Parameters.Add("@MaNCC", SqlDbType.NChar).Value = MaNCC;
            command.Parameters.Add("@NgayGD", SqlDbType.NChar).Value = NgayGD;
            command.Parameters.Add("@TriGiaHD", SqlDbType.Float).Value = TriGiaHD;
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




    


        public DataTable getAllNhaCungCap()
        {
            SqlCommand cmd = new SqlCommand("select * from V_NhaCungCap", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
        public void LoadComboBoxCungCap()
        {
            nhacungcaps = getAllNhaCungCap();
            cboMaNCC.Items.Clear();
            foreach (DataRow row in nhacungcaps.Rows)
            {
                cboMaNCC.Items.Add(row["MaNCC"].ToString());
            }
            cboMaNCC.SelectedIndexChanged += CboMaNCC_SelectedIndexChanged;
        }
        private void CboMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maNCC = cboMaNCC.SelectedItem.ToString();
            DataRow[] rows = nhacungcaps.Select("MaNCC = '" + maNCC + "'");
            if (rows.Length > 0)
            {
                string tenNCC = rows[0]["TenNCC"].ToString();
                textTenNCC.Text = tenNCC;
            }
            else
            {
                textTenNCC.Text = "";
            }
        }

   

        private void buttonTimSP_Click_1(object sender, EventArgs e)
        {
            FTimSanPham f = new FTimSanPham();
            f.SanPhamSelected += (maSP, tenSP, giaSP) =>
            {
                textMaSP.Text = maSP;
                textTenSP.Text = tenSP;
            };
            f.Show();
        }

        private void buttonThemSP_Click_1(object sender, EventArgs e)
        {
            try
            {
                int soluong = (int)numSoLuong.Value;

                if (soluong > 0)
                {
                    string maSP = textMaSP.Text;
                    string tenSP = textTenSP.Text;
                    decimal gianhap = decimal.Parse(textGia.Text);

                    // Kiểm tra xem sản phẩm đã tồn tại trong DataTable chưa
                    DataRow existingRow = dataTable.AsEnumerable().FirstOrDefault(row => row.Field<string>("MaSP") == maSP);
                    if (existingRow != null)
                    {
                        // Nếu sản phẩm đã tồn tại, cộng số lượng
                        int existingQuantity = existingRow.Field<int>("SoLuong");
                        existingRow.SetField("SoLuong", existingQuantity + soluong);
                    }
                    else
                    {
                        // Nếu sản phẩm chưa tồn tại, thêm dòng mới vào DataTable
                        DataRow newRow = dataTable.NewRow();
                        newRow["MaSP"] = maSP;
                        newRow["TenSP"] = tenSP;
                        newRow["SoLuong"] = soluong;
                        newRow["GiaNhap"] = gianhap;
                        dataTable.Rows.Add(newRow);
                    }

                    LoadBangSanPhamHoaDon();
                }
                else
                {
                    throw new Exception("Số lượng phải lớn hơn 0.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonDongY_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cboMaNCC.Text))
                {
                    throw new Exception("Vui lòng nhập mã khách cung cấp.");
                }
                if (string.IsNullOrEmpty(textMaNV.Text))
                {
                    throw new Exception("Vui lòng nhập mã khách hàng.");
                }

                if (dataTable.Rows.Count == 0)
                {
                    throw new Exception("Danh sách sản phẩm trống. Vui lòng thêm sản phẩm.");
                }

                // Mở kết nối và bắt đầu transaction
                db.openConnection();
                SqlTransaction transaction = db.getConnection.BeginTransaction();
                try
                {
                    // Thêm hóa đơn vào bảng "HoaDonBanNhapKho"
                    SqlCommand command = new SqlCommand("proc_themHoaDonNhapKho", db.getConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Transaction = transaction;
                    command.Parameters.Add("@MaHDNK", SqlDbType.NChar).Value = textMaHD.Text;
                    command.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = textMaNV.Text;
                    command.Parameters.Add("@MaNCC", SqlDbType.NChar).Value = cboMaNCC.Text;
                    try
                    {
                        // Mã lệnh có thể gây ra lỗi
                        command.Parameters.Add("@NgayGD", SqlDbType.Date).Value = textNgayGiaoDich.Value.ToString("yyyy-MM-dd");
                    }
                    catch (Exception ex)
                    {
                        // Hiển thị thông báo lỗi cụ thể
                        MessageBox.Show("Đã xảy ra lỗi khi thiết lập tham số NgayGD: " + ex.Message);
                    }

                    command.Parameters.Add("@TriGiaHD", SqlDbType.Decimal).Value = Convert.ToDecimal(textThanhTien.Text);

                    command.ExecuteNonQuery();

                    // Thêm chi tiết hóa đơn vào bảng "ChiTietHDNK"
                    foreach (DataRow row in dataTable.Rows)
                    {
                        SqlCommand detailCommand = new SqlCommand("proc_themChiTietHoaDonNhapKho", db.getConnection);
                        detailCommand.CommandType = CommandType.StoredProcedure;
                        detailCommand.Transaction = transaction;
                        detailCommand.Parameters.Add("@MaHDNK", SqlDbType.NChar).Value = textMaHD.Text;
                        detailCommand.Parameters.Add("@MaSP", SqlDbType.NChar).Value = textMaSP.Text;
                        detailCommand.Parameters.Add("@SoLuong", SqlDbType.Int).Value = Convert.ToInt32(row["SoLuong"]);
                        detailCommand.Parameters.Add("@DonGia", SqlDbType.Decimal).Value = Convert.ToDecimal(row["GiaNhap"]);
                        detailCommand.Parameters.Add("@ThanhTien", SqlDbType.Decimal).Value = Convert.ToDecimal(row["SoLuong"]) * Convert.ToDecimal(row["GiaNhap"]);
                        detailCommand.ExecuteNonQuery();
                    }

                    // Commit transaction nếu không có lỗi
                    transaction.Commit();
                    MessageBox.Show("Tạo thành công hóa đơn.");
                }
                catch (Exception ex)
                {
                    // Rollback transaction nếu có lỗi
                    transaction.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void buttonHuy_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Đảm bảo chỉ xử lý khi double-click vào một ô hợp lệ
            {
                // Hiển thị thông báo xác nhận
                DialogResult result = MessageBox.Show("Bạn có muốn xóa dòng hiện tại không?", "Xác nhận xóa", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    // Lấy mã sản phẩm từ cột "MaSP" của dòng được chọn
                    string maSP = dgvSanPham.Rows[e.RowIndex].Cells["MaSP"].Value.ToString();

                    // Xóa dòng hiện tại khỏi DataGridView
                    dgvSanPham.Rows.RemoveAt(e.RowIndex);

                    // Tìm dòng trong DataTable có mã sản phẩm tương tự và xóa nó
                    DataRow[] rows = dataTable.Select("MaSP = '" + maSP + "'");
                    foreach (DataRow row in rows)
                    {
                        dataTable.Rows.Remove(row);
                    }
                    LoadBangSanPhamHoaDon();
                }
            }
        }

        private void dgvHoaDonNhapKho_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy MaHDBH từ dòng được chọn trong DataGridView Hóa Đơn
                string maHDNK = dgvHoaDonNhapKho.Rows[e.RowIndex].Cells["MaHDNK"].Value.ToString();

                // Hiển thị chi tiết hóa đơn tương ứng trong DataGridView Chi Tiết Hóa Đơn
                HienThiChiTietHoaDon(maHDNK);
            }
            panelchitiethoandon.Visible = true;
            dgvHoaDonNhapKho.Dock = DockStyle.None;

        }
        private void HienThiChiTietHoaDon(string maHDNK)
        {
            // Tạo câu truy vấn SQL để lấy chi tiết hóa đơn có mã tương ứng
            string query = "SELECT * FROM V_ChiTietHoaDonNhapKho WHERE MaHDNK = @MaHDNK";
            SqlCommand cmd = new SqlCommand(query, db.getConnection);
            cmd.Parameters.AddWithValue("@MaHDNK", maHDNK);

            // Thực thi câu truy vấn và hiển thị kết quả trong DataGridView Chi Tiết Hóa Đơn
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvChiTietHDNK.DataSource = dt;
        }


        private void buttExit_Click_1(object sender, EventArgs e)
        {
            panelchitiethoandon.Visible = false;
            dgvHoaDonNhapKho.Dock = DockStyle.Bottom;

        }
    }
}
