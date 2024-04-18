
using QLTIEMBANLAPTOP;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardApp.Models
{
    public struct RevenueByDate
    {
        public string Date { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class Dashboard: KetNoi
    {
       
        private DateTime startDate;
        private DateTime endDate;
        private int numberDays;

        public int NumCustomers { get; private set; }
        public int NumSuppliers { get; private set; }
        public int NumProducts { get; private set; }
        public List<KeyValuePair<string, int>> TopProductsList { get; private set; }
        public List<KeyValuePair<string, int>> UnderstockList { get; private set; }
        public List<RevenueByDate> GrossRevenueList { get; private set; }
        public int NumOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalProfit { get; set; }
        
        public Dashboard ()
        {
        
        }
   
    

        
        private void GetNumberItems()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                   // Tổng khách hàng
                    command.CommandText = "select count(MaKH) from KhachHang";
                    NumCustomers = (int)command.ExecuteScalar();

                    // Tổng nhà cung cấp
                    command.CommandText = "select count(MaNCC) from NhaCungCap";
                    NumSuppliers = (int)command.ExecuteScalar();

                    //tổng số sản phẩm
                    command.CommandText = "select count(MaSP) from LapTop";
                    NumProducts = (int)command.ExecuteScalar();

                    //Số hóa đơn theo ngày
                    command.CommandText = @"select count(MaHDBH) from [HoaDonBanHang]" +
                                          "where NgayGD between  @fromDate and @toDate";
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    NumOrders = (int)command.ExecuteScalar();
                }
            }
        }
        private void GetProductAnalysis()
        {
            TopProductsList = new List<KeyValuePair<string, int>>();
            UnderstockList = new List<KeyValuePair<string, int>>();

            using (var connection = GetConnection())
            {
                connection.Open ();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;

                    // Lấy top 5 sản phẩm bán chạy
                    command.CommandText = "Top5SanPhamBanChay";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TopProductsList.Add(new KeyValuePair<string, int>(reader[0].ToString(), (int)reader[1]));
                    }
                    reader.Close();

                    // Lấy danh sách sản phẩm sắp hết hàng
                    command.CommandText = "SanSanPhamSapHetHang";
                    command.Parameters.Clear(); // Xóa các tham số trước đó
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        UnderstockList.Add(new KeyValuePair<string, int>(reader[0].ToString(), (int)reader[1]));
                    }
                    reader.Close();
                }
            }
        }

        private void GetOrderAnalysis()
        {
            GrossRevenueList = new List<RevenueByDate>();
            TotalProfit = 0;
            TotalRevenue = 0;

            using (var connection = GetConnection())
            {
                connection.Open();

                // Tính tổng doanh thu theo ngày
                using (var revenueCommand = new SqlCommand())
                {
                    revenueCommand.Connection = connection;
                    revenueCommand.CommandText = "DoanhThuTheoNgay";
                    revenueCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    revenueCommand.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    revenueCommand.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;

                    using (var revenueReader = revenueCommand.ExecuteReader())
                    {
                        while (revenueReader.Read())
                        {
                            var ngay = (DateTime)revenueReader["Ngay"];
                            var totalRevenue = (decimal)revenueReader["TotalRevenue"];

                            TotalRevenue += totalRevenue;

                            GrossRevenueList.Add(new RevenueByDate
                            {
                                Date = ngay.ToString("dd MMM"),
                                TotalAmount = totalRevenue
                            });
                        }
                    }
                }

                // Tính tổng lợi nhuận theo ngày
                using (var profitCommand = new SqlCommand())
                {
                    profitCommand.Connection = connection;
                    profitCommand.CommandText = "LoiNhuanTheoNgay";
                    profitCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    profitCommand.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    profitCommand.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;

                    using (var profitReader = profitCommand.ExecuteReader())
                    {
                        while (profitReader.Read())
                        {
                            var totalProfit = (decimal)profitReader["TotalProfit"];
                            TotalProfit += totalProfit;
                        }
                    }
                }
            }

            // Group kết quả theo yêu cầu
            if (numberDays <= 30)
            {
                // Group by Days
                GrossRevenueList = GrossRevenueList.GroupBy(x => x.Date)
                                                     .Select(group => new RevenueByDate
                                                     {
                                                         Date = group.Key,
                                                         TotalAmount = group.Sum(x => x.TotalAmount)
                                                     }).ToList();
            }
            else if (numberDays <= 92)
            {
                // Group by Weeks
                GrossRevenueList = GrossRevenueList.GroupBy(x => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                                                     DateTime.ParseExact(x.Date, "dd MMM", CultureInfo.InvariantCulture),
                                                                     CalendarWeekRule.FirstDay, DayOfWeek.Monday))
                                                   .Select(group => new RevenueByDate
                                                   {
                                                       Date = "Week " + group.Key.ToString(),
                                                       TotalAmount = group.Sum(x => x.TotalAmount)
                                                   }).ToList();
            }
            else if (numberDays <= (365 * 2))
            {
                // Group by Months
                GrossRevenueList = GrossRevenueList.GroupBy(x => DateTime.ParseExact(x.Date, "dd MMM", CultureInfo.InvariantCulture).ToString("MMM yyyy"))
                                                   .Select(group => new RevenueByDate
                                                   {
                                                       Date = group.Key,
                                                       TotalAmount = group.Sum(x => x.TotalAmount)
                                                   }).ToList();
            }
            else
            {
                // Group by Years
                GrossRevenueList = GrossRevenueList.GroupBy(x => DateTime.ParseExact(x.Date, "dd MMM", CultureInfo.InvariantCulture).ToString("yyyy"))
                                                   .Select(group => new RevenueByDate
                                                   {
                                                       Date = group.Key,
                                                       TotalAmount = group.Sum(x => x.TotalAmount)
                                                   }).ToList();
            }
        }



        //Public methods
        public bool LoadData(DateTime startDate, DateTime endDate)
        {
            endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day,
                endDate.Hour, endDate.Minute, 59);
            if (startDate != this.startDate || endDate != this.endDate)
            {
                this.startDate = startDate;
                this.endDate = endDate;
                this.numberDays = (endDate - startDate).Days;

                GetNumberItems();
                GetProductAnalysis();
                GetOrderAnalysis();
                Console.WriteLine("Refreshed data: {0} - {1}", startDate.ToString(), endDate.ToString());
                return true;
            }
            else
            {
                Console.WriteLine("Data not refreshed, same query: {0} - {1}", startDate.ToString(), endDate.ToString());
                return false;
            }
        }
    }
}



