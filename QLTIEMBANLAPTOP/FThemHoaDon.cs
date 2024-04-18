
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
    public partial class FThemHoaDon : Form
    {

        KetNoi db = new KetNoi();
        DataTable dataTable = new DataTable();

        public FThemHoaDon()
        {
            InitializeComponent();

            TaoBangSanPhamDaChon();
            TaoMaHDRandom();
            LoadBangSanPhamHoaDon();
            loadHoaDonBanHang();

        }


        public void loadHoaDonBanHangchitiet()
        {
            SqlCommand cmd = new SqlCommand("select * from V_ChiTietHoaDonBanHang", db.getConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvChiTietHDBH.DataSource = dt;
            dgvChiTietHDBH.Columns["MaHDBH"].HeaderText = "Mã hoá đơn Bán hàng";
            dgvChiTietHDBH.Columns["NgayGD"].HeaderText = "Ngày giao dịch";
            dgvChiTietHDBH.Columns["MaKH"].HeaderText = "Tên nhà cung cấp";
            dgvChiTietHDBH.Columns["MaNV"].HeaderText = "Mã nhân viên";
            dgvChiTietHDBH.Columns["TriGiaHD"].HeaderText = "Trị giá hoá đơn";
            // Các cột từ bảng ChiTietHDBH
            dgvChiTietHDBH.Columns["MaSP"].HeaderText = "Mã sản phẩm";
            dgvChiTietHDBH.Columns["SoLuong"].HeaderText = "Số lượng";
            dgvChiTietHDBH.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvChiTietHDBH.Columns["ThanhTien"].HeaderText = "Thành tiền";
        }

        public void loadHoaDonBanHang()
        {
            SqlCommand cmd = new SqlCommand("select * from V_HoaDonBanHang", db.getConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvHoaDonBanHang.DataSource = dt;
            dgvHoaDonBanHang.Columns["MaHDBH"].HeaderText = "Mã hoá đơn Bán hàng";
            dgvHoaDonBanHang.Columns["NgayGD"].HeaderText = "Ngày giao dịch";
            dgvHoaDonBanHang.Columns["MaKH"].HeaderText = "Tên nhà cung cấp";
            dgvHoaDonBanHang.Columns["MaNV"].HeaderText = "Mã nhân viên";
            dgvHoaDonBanHang.Columns["TriGiaHD"].HeaderText = "Trị giá hoá đơn";
        }
        private void TaoBangSanPhamDaChon()
        {
            dataTable.Columns.Add("MaSP", typeof(string));
            dataTable.Columns.Add("TenSP", typeof(string));
            dataTable.Columns.Add("SoLuong", typeof(int));
            dataTable.Columns.Add("DonGia", typeof(decimal));
        }
        private void button2_Click(object sender, EventArgs e)
        {

            db.openConnection();
            using (SqlCommand cmd = new SqlCommand("TimKhachHangTheoSDT", db.getConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@SDT", textSDT.Text));

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        textTenKH.Text = reader["HoTen"].ToString();
                        textMaKH.Text = reader["MaKH"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin khách hàng này");
                }
            }
            db.closeConnection();

        }

        private void TaoMaHDRandom()
        {
            const string chars = "0123456789";
            Random random = new Random();
            char[] randomArray = new char[4];

            for (int i = 0; i < 4; i++)
            {
                randomArray[i] = chars[random.Next(chars.Length)];
            }
            textMaHD.Text = "HDBH" + new string(randomArray);
        }

        private void buttonTimSP_Click(object sender, EventArgs e)
        {
            FTimSanPham f = new FTimSanPham();
            f.SanPhamSelected += (maSP, tenSP, giaSP) =>
            {
                textMaSP.Text = maSP;
                textTenSP.Text = tenSP;
                textGia.Text = giaSP.ToString();
            };
            f.Show();

        }

        private void buttonThemSP_Click(object sender, EventArgs e)
        {
            try
            {
                int soluong = (int)numSoLuong.Value;

                if (soluong > 0)
                {
                    string maSP = textMaSP.Text;
                    string tenSP = textTenSP.Text;
                    decimal donGia = decimal.Parse(textGia.Text);

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
                        newRow["DonGia"] = donGia;
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
                dgvSanPham.Columns.Add("DonGia", "Đơn Giá");
                dgvSanPham.Columns.Add("TongTien", "Tổng Tiền");
            }

            dgvSanPham.Rows.Clear();

            // Load dữ liệu từ DataTable vào DataGridView
            foreach (DataRow row in dataTable.Rows)
            {
                string maSP = row["MaSP"].ToString();
                string tenSP = row["TenSP"].ToString();
                int soLuong = Convert.ToInt32(row["SoLuong"]);
                decimal donGia = Convert.ToDecimal(row["DonGia"]);
                dgvSanPham.Rows.Add(maSP, tenSP, soLuong, donGia, soLuong * donGia);
                TongCong += soLuong * donGia;
            }

            textTongCong.Text = TongCong.ToString();
            // Tính toán ThanhTien dựa trên thông tin khách hàng từ bảng KhachHang
            // ...
            textThanhTien.Text = TongCong.ToString();
        }



        private void ButtonDongY_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textMaKH.Text))
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
                    // Thêm hóa đơn vào bảng "HoaDonBanHang"
                    SqlCommand command = new SqlCommand("proc_themHoaDonBanHang", db.getConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Transaction = transaction;
                    command.Parameters.Add("@MaHDBH", SqlDbType.NChar).Value = textMaHD.Text;
                    command.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = MaNV.Text;
                    command.Parameters.Add("@MaKH", SqlDbType.NChar).Value = textMaKH.Text;
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

                    // Thêm chi tiết hóa đơn vào bảng "ChiTietHDBH"
                    foreach (DataRow row in dataTable.Rows)
                    {
                        SqlCommand detailCommand = new SqlCommand("proc_themChiTietHoaDonBanHang", db.getConnection);
                        detailCommand.CommandType = CommandType.StoredProcedure;
                        detailCommand.Transaction = transaction;
                        detailCommand.Parameters.Add("@MaHDBH", SqlDbType.NChar).Value = textMaHD.Text;
                        detailCommand.Parameters.Add("@MaSP", SqlDbType.NChar).Value = textMaSP.Text;
                        detailCommand.Parameters.Add("@SoLuong", SqlDbType.Int).Value = Convert.ToInt32(row["SoLuong"]);
                        detailCommand.Parameters.Add("@DonGia", SqlDbType.Decimal).Value = Convert.ToDecimal(row["DonGia"]);
                        detailCommand.Parameters.Add("@ThanhTien", SqlDbType.Decimal).Value = Convert.ToDecimal(row["SoLuong"]) * Convert.ToDecimal(row["DonGia"]);
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

     

        private void buttonHuy_Click(object sender, EventArgs e)
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
                }
            }
        }
        private void dgvHoaDonBanHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy MaHDBH từ dòng được chọn trong DataGridView Hóa Đơn
                string maHDBH = dgvHoaDonBanHang.Rows[e.RowIndex].Cells["MaHDBH"].Value.ToString();

                // Hiển thị chi tiết hóa đơn tương ứng trong DataGridView Chi Tiết Hóa Đơn
                HienThiChiTietHoaDon(maHDBH);
            }
            panelchitiethoandon.Visible = true;
            dgvHoaDonBanHang.Dock = DockStyle.None;


        }
        private void HienThiChiTietHoaDon(string maHDBH)
        {
            // Tạo câu truy vấn SQL để lấy chi tiết hóa đơn có mã tương ứng
            string query = "SELECT * FROM V_ChiTietHoaDonBanHang WHERE MaHDBH = @MaHDBH";
            SqlCommand cmd = new SqlCommand(query, db.getConnection);
            cmd.Parameters.AddWithValue("@MaHDBH", maHDBH);

            // Thực thi câu truy vấn và hiển thị kết quả trong DataGridView Chi Tiết Hóa Đơn
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvChiTietHDBH.DataSource = dt;
        }

        private void buttExit_Click(object sender, EventArgs e)
        {
            panelchitiethoandon.Visible = false;
            dgvHoaDonBanHang.Dock = DockStyle.Bottom;
        }

        private void dgvSanPham_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSanPham.SelectedRows.Count > 0)
            {
                // Lấy mã sản phẩm được chọn từ DataGridView
                string maSP =dgvSanPham.SelectedRows[0].Cells["MaSP"].Value.ToString();

                // Truy vấn cơ sở dữ liệu để lấy thông tin khuyến mãi cho sản phẩm được chọn
                string query = "SELECT MaKM FROM KhuyenMai WHERE MaSP = @MaSP AND GETDATE() BETWEEN ThoiGianBatDau AND ThoiGianKetThuc";
                using (SqlCommand command = new SqlCommand(query, db.getConnection))
                {
                    command.Parameters.AddWithValue("@MaSP", maSP);
                    db.openConnection();
                    SqlDataReader reader = command.ExecuteReader();
                    // Xóa tất cả các mục trong ComboBox trước khi thêm mới
                    comboBoxMaKhuyenMai.Items.Clear();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Thêm các mã khuyến mãi còn hiệu lực vào ComboBox
                            string maKM = reader["MaKM"].ToString();
                            comboBoxMaKhuyenMai.Items.Add(maKM);
                        }
                    }
                    else
                    {
                        // Nếu không có mã khuyến mãi còn hiệu lực, đặt ComboBox thành null
                        comboBoxMaKhuyenMai.SelectedItem = null;
                    }
                    reader.Close();
                }
                
            }
        }
    }
}
