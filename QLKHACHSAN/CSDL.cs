using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace QLKHACHSAN
{
    class CSDL
    {

        public static String server = @"Data Source=desktop-7p198qb\sqlexpress;Initial Catalog = QLKHACHSAN; Integrated Security = True";
        public static DataTable dt = new DataTable();
        public static SqlConnection con = new SqlConnection(server);
        public static DataTable ketnoi(String y)
        {
            DataTable db = new DataTable();
            CSDL.con = new SqlConnection(CSDL.server);// kết lối csdl với chuỗi kết nối là y 
            CSDL.con.Open();// mở kết nỗi
            SqlDataAdapter da = new SqlDataAdapter(y, CSDL.con);
            //biến SqlDataAdapter lấy dữ liệu theo câu lệnh select 
            da.Fill(db);// đổ dữ liệu vào table tạm 
            CSDL.con.Close();// đóng kết nối
            return db;
        }
        public static int Luucsdl(String y)
        {
            try
            {
                CSDL.con.Open();
                SqlCommand com = new SqlCommand(y, CSDL.con);
                com.ExecuteNonQuery();
                CSDL.con.Close();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }
   
   
}