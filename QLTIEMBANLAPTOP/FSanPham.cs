
using FontAwesome.Sharp;
using QLTIEMBANLAPTOP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;


namespace DOAN
{
    public partial class FSanPham : Form
    {
        KetNoi db = new KetNoi();


        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dt = new DataTable();
        public FSanPham()
        {
            InitializeComponent();
            LoadBangSanPham();
            load_combobox();
            LoadBangTSKT();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public DataTable getAllTSKT()
        {
            SqlCommand cmd = new SqlCommand("select * from V_TSKT", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
        public void LoadBangTSKT()
        {
            DataTable TSKT = getAllTSKT();
            dgvTSKT.DataSource = TSKT;
        }

        //Thêm LapTop Mới
        public bool themSanPham(string MaSP, string TenSP, string TenLoaiSP, string HangSX, float DonGia, float GiaNhap, int SoLuong, string TinhTrang, int ThoiGianBH, byte[] HinhAnh, string IDThongso)
        {
            SqlCommand command = new SqlCommand("proc_themSanPhamMoi", db.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaSP", SqlDbType.NVarChar).Value = MaSP;
            command.Parameters.Add("@TenSP", SqlDbType.NVarChar).Value = TenSP;
            command.Parameters.Add("@LoaiSP", SqlDbType.NVarChar).Value = TenLoaiSP;
            command.Parameters.Add("@HangSX", SqlDbType.NVarChar).Value = HangSX;
            command.Parameters.Add("@GiaBan", SqlDbType.Decimal).Value = DonGia;
            command.Parameters.Add("@GiaNhap", SqlDbType.Decimal).Value = GiaNhap;
            command.Parameters.Add("@SoLuong", SqlDbType.Int).Value = SoLuong;
            command.Parameters.Add("@TinhTrang", SqlDbType.NVarChar).Value = TinhTrang;
            command.Parameters.Add("@ThoiHanBaoHanh", SqlDbType.Int).Value = ThoiGianBH;
            command.Parameters.Add("@HinhAnh", SqlDbType.VarBinary).Value = HinhAnh;
            command.Parameters.Add("@IDThongSoKT", SqlDbType.NVarChar).Value = IDThongso;

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

        //Sửa Thông Tin Sản Phẩm
        public bool suaSanPham(string MaSP, string TenSP, string TenLoaiSP, string HangSX, float DonGia, float GiaNhap, int SoLuong, string TinhTrang, int ThoiGianBH, byte[] HinhAnh, string IDThongso)
        {
            SqlCommand command = new SqlCommand("proc_suaSanPham", db.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MaSP", SqlDbType.NVarChar).Value = MaSP;
            command.Parameters.Add("@TenSP", SqlDbType.NVarChar).Value = TenSP;
            command.Parameters.Add("@LoaiSP", SqlDbType.NVarChar).Value = TenLoaiSP;
            command.Parameters.Add("@HangSX", SqlDbType.NVarChar).Value = HangSX;
            command.Parameters.Add("@GiaBan", SqlDbType.Decimal).Value = DonGia;
            command.Parameters.Add("@GiaNhap", SqlDbType.Decimal).Value = GiaNhap;
            command.Parameters.Add("@SoLuong", SqlDbType.Int).Value = SoLuong;
            command.Parameters.Add("@TinhTrang", SqlDbType.NVarChar).Value = TinhTrang;
            command.Parameters.Add("@ThoiHanBaoHanh", SqlDbType.Int).Value = ThoiGianBH;
            command.Parameters.Add("@HinhAnh", SqlDbType.VarBinary).Value = HinhAnh;
            command.Parameters.Add("@IDThongSoKT", SqlDbType.NVarChar).Value = IDThongso;

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

        //Tìm Kiếm LapTop
        public DataTable getDSSanPhamByString(string str)
        {
            string fnName = "func_getLaptopListByString";
            SqlCommand command = new SqlCommand("Select * from " + fnName + " (@string)", db.getConnection);
            command.Parameters.Add("@string", SqlDbType.NChar).Value = str;
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            return table;
        }

        private void load_combobox()
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("select distinct IDThongSoKT FROM LapTop", db.getConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<string> list = new List<string>();
            while (reader.Read())
            {
                string str = reader["IDThongSoKT"].ToString();
                list.Add(str);

            }
            comboBoxThongSo.DataSource = list;
            db.closeConnection();
        }


        private void LoadBangSanPham()
        {
            try
            {
                db.openConnection();
                cmd = new SqlCommand("select * from LapTop", db.getConnection);
                adt = new SqlDataAdapter(cmd);
                dt.Clear();
                adt.Fill(dt);

                dgvSanPham.DataSource = dt;

                // Kiểm tra nếu cột chứa hình ảnh tồn tại
                if (dgvSanPham.Columns.Contains("HinhAnh"))
                {
                    // Duyệt qua từng dòng trong DataGridView và kiểm tra giá trị của cột HinhAnh
                    foreach (DataGridViewRow row in dgvSanPham.Rows)
                    {
                        // Kiểm tra nếu giá trị của cột HinhAnh là DBNull
                        if (row.Cells["HinhAnh"].Value == DBNull.Value)
                        {
                            // Nếu là DBNull, gán một hình ảnh mặc định hoặc thực hiện xử lý phù hợp
                            row.Cells["HinhAnh"].Value = QLTIEMBANLAPTOP.Properties.Resources._default;
                        }
                        else
                        {
                            // Nếu không phải DBNull, chuyển đổi giá trị sang kiểu Image
                            byte[] imgBytes = (byte[])row.Cells["HinhAnh"].Value;
                            using (MemoryStream ms = new MemoryStream(imgBytes))
                            {
                                Image img = Image.FromStream(ms);
                                row.Cells["HinhAnh"].Value = img;
                              
                                
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiện truy vấn: " + ex.Message);
            }
            finally
            {
                db.closeConnection();
            }

        }


        public static byte[] ConvertImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (var bitmap = new Bitmap(image))
                {
                    bitmap.Save(ms, image.RawFormat);
                    return ms.ToArray();
                }
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
                    string MaSP = textBoxMaSP.Text;
                    string TenSP = textBoxTenSP.Text;
                    string TenLoaiSP = textBoxLoaiSP.Text;
                    string HangSX = textBoxHangSX.Text;
                    float DonGia = float.Parse(textBoxGiaBan.Text);
                    float GiaNhap = float.Parse(textBoxGiaNhap.Text);
                    int SoLuong = int.Parse(textBoxSoLuong.Text);
                    string TinhTrang = textBoxTinhTrang.Text;
                    int ThoiGianBH = int.Parse(textBoxBaoHanh.Text);
                    byte[] HinhAnh = ConvertImageToByteArray(picSanPham.Image);
                    string IDThongso = comboBoxThongSo.Text;
                    if (suaSanPham(MaSP, TenSP, TenLoaiSP, HangSX, DonGia, GiaNhap, SoLuong, TinhTrang, ThoiGianBH, HinhAnh, IDThongso))
                        MessageBox.Show("Sửa Thành Công.");
                    else
                        MessageBox.Show("Sửa Không Thành Công.");
                    LoadBangSanPham();

                    
}

private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
{
if (e.RowIndex >= 0)
{
    // Lấy row hiện tại mà người dùng đã click vào
    DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];
    // Đặt giá trị cho các TextBox tương ứng
    textBoxMaSP.Text = row.Cells["MaSP"].Value.ToString();
    textBoxTenSP.Text = row.Cells["TenSP"].Value.ToString();
    textBoxLoaiSP.Text = row.Cells["LoaiSP"].Value.ToString();
    textBoxHangSX.Text = row.Cells["HangSX"].Value.ToString();
    textBoxGiaBan.Text = row.Cells["GiaBan"].Value.ToString();
    textBoxGiaNhap.Text = row.Cells["GiaNhap"].Value.ToString();
    textBoxSoLuong.Text = row.Cells["SoLuong"].Value.ToString();
    textBoxTinhTrang.Text = row.Cells["TinhTrang"].Value.ToString();
    textBoxBaoHanh.Text = row.Cells["ThoiHanBaoHanh"].Value.ToString();
    // Kiểm tra nếu cột HinhAnh tồn tại và giá trị không phải DBNull
    if (dgvSanPham.Columns.Contains("HinhAnh") && row.Cells["HinhAnh"].Value != DBNull.Value)
    {
        try
        {
            // Chuyển đổi giá trị từ byte[] sang hình ảnh
            byte[] imgBytes = (byte[])row.Cells["HinhAnh"].Value;
            using (MemoryStream ms = new MemoryStream(imgBytes))
            {
                Image img = Image.FromStream(ms);
                picSanPham.Image = img;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi hiển thị hình ảnh: " + ex.Message);
        }
    }
    else
    {
        // Nếu giá trị là DBNull hoặc cột không tồn tại, bạn có thể gán một hình ảnh mặc định hoặc thực hiện xử lý phù hợp
        picSanPham.Image = QLTIEMBANLAPTOP.Properties.Resources._default;
    }

    comboBoxThongSo.Text = row.Cells["IDThongSoKT"].Value.ToString();
        }
        dgvSanPham.Dock = DockStyle.None;
        panelUpdate.Visible = true;
        btUpdate.Visible = true;
        btThem.Visible = false;
    }

    private void buttExit_Click(object sender, EventArgs e)
                        {
                        panelUpdate.Visible = false;
                        dgvSanPham.Dock = DockStyle.Bottom;
                        }

    private void btThem_Click_1(object sender, EventArgs e)
    {
                        string MaSP = textBoxMaSP.Text;
                        string TenSP = textBoxTenSP.Text;
                        string TenLoaiSP = textBoxLoaiSP.Text;
                        string HangSX = textBoxHangSX.Text;
                        float DonGia = float.Parse(textBoxGiaBan.Text);
                        float GiaNhap = float.Parse(textBoxGiaNhap.Text);
                        int SoLuong = int.Parse(textBoxSoLuong.Text);
                        string TinhTrang = textBoxTinhTrang.Text;
                        int ThoiGianBH = int.Parse(textBoxBaoHanh.Text);
                        byte[] HinhAnh = ConvertImageToByteArray(picSanPham.Image); // Chuyển đổi hình ảnh từ PictureBox thành mảng byte
                        string IDThongso = comboBoxThongSo.SelectedItem.ToString();
                        if (themSanPham(MaSP, TenSP, TenLoaiSP, HangSX, DonGia, GiaNhap, SoLuong, TinhTrang, ThoiGianBH, HinhAnh, IDThongso))
                            MessageBox.Show("Thêm Thành Công.");
                        else
                            MessageBox.Show("Thêm Không Thành Công.");
                        LoadBangSanPham();
                        }

    private void ButtonAdd_Click(object sender, EventArgs e)
                        {
           picSanPham.Image = Image.FromFile("C:\\Users\\manno\\OneDrive\\Desktop\\hoc c#\\QLTIEMBANLAPTOP\\QLTIEMBANLAPTOP\\AnhSanPham\\default.jpg");
            textBoxMaSP.Text = null;
            textBoxTenSP.Text = null;
             textBoxLoaiSP.Text = null;
             textBoxHangSX.Text = null;
             textBoxGiaBan.Text = null;
             textBoxGiaNhap.Text = null;
              textBoxSoLuong.Text = null;
              textBoxTinhTrang.Text = null;
              textBoxBaoHanh.Text = null;
               dgvSanPham.Dock = DockStyle.None;
               panelUpdate.Visible = true;
               btUpdate.Visible = false;
               btThem.Visible = true;
    }

    private void btThemAnh_Click(object sender, EventArgs e)
    {
                    // Tạo một OpenFileDialog
                    OpenFileDialog openFileDialog = new OpenFileDialog();

                    // Thiết lập thư mục mặc định cho OpenFileDialog
                    string anhSanPhamFolderPath = Path.Combine(Application.StartupPath, "C:\\Users\\manno\\OneDrive\\Desktop\\hoc c#\\QLTIEMBANLAPTOP\\QLTIEMBANLAPTOP\\AnhSanPham\\");
                    openFileDialog.InitialDirectory = anhSanPhamFolderPath;

                    // Thiết lập bộ lọc cho các loại tệp hình ảnh
                    openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif)|*.jpg;*.jpeg;*.png;*.gif|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;

                    // Hiển thị hộp thoại mở tệp và chờ người dùng chọn tệp
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            // Lấy đường dẫn của tệp đã chọn
                            string filePath = openFileDialog.FileName;

                            // Kiểm tra xem đường dẫn của tệp có nằm trong thư mục "AnhSanPham" hay không
                            if (filePath.StartsWith(anhSanPhamFolderPath, StringComparison.OrdinalIgnoreCase))
                            {
                                // Nếu tệp được chọn nằm trong thư mục "AnhSanPham", bạn có thể tiếp tục xử lý ảnh.
                                // Hiển thị ảnh trong PictureBox
                                picSanPham.Image = Image.FromFile(filePath);
                            }
                            else
                            {
                                // Nếu tệp được chọn không nằm trong thư mục "AnhSanPham", hiển thị thông báo cảnh báo.
                                MessageBox.Show("Vui lòng chọn ảnh từ thư mục AnhSanPham.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi mở ảnh: " + ex.Message);
                        }
                    }

                    }

   

        private void dgvTSKT_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
         
            if (e.RowIndex >= 0 && e.RowIndex < dgvTSKT.RowCount)
            {
                DataGridViewRow selectedRow = dgvTSKT.Rows[e.RowIndex];
                txtIDThongSoKT.Text = selectedRow.Cells["IDThongSoKT"].Value.ToString();
                txtManHinh.Text = selectedRow.Cells["ManHinh"].Value.ToString();
                txtBoNho.Text = selectedRow.Cells["BoNho"].Value.ToString();
                txtRam.Text = selectedRow.Cells["Ram"].Value.ToString();
                txtChip.Text = selectedRow.Cells["Chip"].Value.ToString();
                txtCardDoHoa.Text = selectedRow.Cells["CardDoHoa"].Value.ToString();
                txtDungLuongPin.Text = selectedRow.Cells["DungLuongPin"].Value.ToString();
                txtCongKetNoi.Text = selectedRow.Cells["CongKetNoi"].Value.ToString();
                txtTrongLuong.Text = selectedRow.Cells["TrongLuong"].Value.ToString();
            }

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            string iDThongSoKT = txtIDThongSoKT.Text;
            string manHinh = txtManHinh.Text;
            string boNho = txtBoNho.Text;
            string ram = txtRam.Text;
            string chip = txtChip.Text;
            string cardDH = txtCardDoHoa.Text;
            string dungLuongPin = txtDungLuongPin.Text;
            string congKetNoi = txtCongKetNoi.Text;
            string trongLuong = txtTrongLuong.Text;

            bool result = ThemThongSoKyThuat(iDThongSoKT, manHinh, boNho, ram, chip, cardDH, dungLuongPin, congKetNoi, trongLuong);

            if (result == true)
            {
                MessageBox.Show("Thêm thành công!");
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
            LoadBangTSKT();
        }
        public bool ThemThongSoKyThuat(string iDThongSoKT, string manHinh, string boNho, string ram, string chip, string cardDH, string dungLuongPin, string congKetNoi, string trongLuong)
        {
            SqlCommand command = new SqlCommand("proc_ThemThongSoKyThuat", db.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@IDThongSoKT", SqlDbType.NVarChar).Value = iDThongSoKT;
            command.Parameters.Add("@ManHinh", SqlDbType.NVarChar).Value = manHinh;
            command.Parameters.Add("@BoNho", SqlDbType.NVarChar).Value = boNho;
            command.Parameters.Add("@Ram", SqlDbType.NVarChar).Value = ram;
            command.Parameters.Add("@Chip", SqlDbType.NVarChar).Value = chip;
            command.Parameters.Add("@CardDoHoa", SqlDbType.NVarChar).Value = cardDH;
            command.Parameters.Add("@DungLuongPin", SqlDbType.NVarChar).Value = dungLuongPin;
            command.Parameters.Add("@CongKetNoi", SqlDbType.NVarChar).Value = congKetNoi;
            command.Parameters.Add("@TrongLuong", SqlDbType.NVarChar).Value = trongLuong;

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

        public bool CapNhatThongSoKyThuat(string idThongSoKT, string manHinh, string boNho, string ram, string chip, string cardDoHoa, string dungLuongPin, string congKetNoi, string trongLuong)
        {
            SqlCommand command = new SqlCommand("proc_suaThongSoKyThuat", db.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@IDThongSoKT", SqlDbType.NVarChar).Value = idThongSoKT;
            command.Parameters.Add("@ManHinh", SqlDbType.NVarChar).Value = manHinh;
            command.Parameters.Add("@BoNho", SqlDbType.NVarChar).Value = boNho;
            command.Parameters.Add("@Ram", SqlDbType.NVarChar).Value = ram;
            command.Parameters.Add("@Chip", SqlDbType.NVarChar).Value = chip;
            command.Parameters.Add("@CardDoHoa", SqlDbType.NVarChar).Value = cardDoHoa;
            command.Parameters.Add("@DungLuongPin", SqlDbType.NVarChar).Value = dungLuongPin;
            command.Parameters.Add("@CongKetNoi", SqlDbType.NVarChar).Value = congKetNoi;
            command.Parameters.Add("@TrongLuong", SqlDbType.NVarChar).Value = trongLuong;

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

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

        }

        private void FSanPham_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cUAHANGLAPTOPDataSet.ThongSoKyThuat' table. You can move, or remove it, as needed.
       

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            string idThongSoKT = txtIDThongSoKT.Text;

            bool result = XoaThongSoKyThuat(idThongSoKT);

            if (result == true)
            {
                MessageBox.Show("Xóa thông số kỹ thuật thành công!");
            }
            else
            {
                MessageBox.Show("Xóa thông số kỹ thuật thất bại!");
            }
            LoadBangTSKT();
        }
        public bool XoaThongSoKyThuat(string idThongSoKT)
        {
            SqlCommand command = new SqlCommand("proc_xoaThongSoKyThuat", db.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@IDThongSoKT", SqlDbType.NVarChar).Value = idThongSoKT;

            try
            {
                db.openConnection();
                int rowsAffected = command.ExecuteNonQuery();
                db.closeConnection();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            string IDThongSoKT = txtIDThongSoKT.Text;
            string ManHinh = txtManHinh.Text;
            string BoNho = txtBoNho.Text;
            string Ram = txtRam.Text;
            string Chip = txtChip.Text;
            string CardDoHoa = txtCardDoHoa.Text;
            string DungLuongPin = txtDungLuongPin.Text;
            string CongKetNoi = txtCongKetNoi.Text;
            string TrongLuong = txtTrongLuong.Text;

            bool result = CapNhatThongSoKyThuat(IDThongSoKT, ManHinh, BoNho, Ram, Chip, CardDoHoa, DungLuongPin, CongKetNoi, TrongLuong);

            if (result)
            {
                MessageBox.Show("Cập nhật thông số kỹ thuật thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật thông số kỹ thuật thất bại!");
            }
            LoadBangTSKT();
        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

            string searchString = bunifuTextBox3.Text.Trim();

            // Mở kết nối với cơ sở dữ liệu
            db.openConnection();

            // Tạo một đối tượng Command để thực thi câu lệnh SELECT từ table-valued function
            using (SqlCommand command = new SqlCommand("SELECT * FROM func_getSanPhamListByString(@string)", db.getConnection))
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
                    dgvSanPham.DataSource = table;
                }
            }
        }
    }
}
