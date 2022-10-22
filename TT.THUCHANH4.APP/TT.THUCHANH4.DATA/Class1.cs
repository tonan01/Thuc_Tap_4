using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TT.THUCHANH4.DATA
{
    public class Class1
    {
        #region Kết nối
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-K7BRREB; Initial Catalog=ThucTap; User ID=sa;Password=123");
        //mở kết nói
        public void openConnection()
        {
            if (con.State == ConnectionState.Closed)//nếu nó đang đóng
            {
                con.Open();//mở kết nối
            }
        }
        //Đống kết nối
        public void closeConnection()
        {
            if (con.State == ConnectionState.Open)//nếu nó đang mở
            {
                con.Close();//Đóng kết nối
            }
        }
        #endregion

        #region 1.	Đếm số lượng sinh viên thực thập
        public int CountSoSinhVienThucTap()
        {
            try
            {
                openConnection();
                string sql = "select COUNT(*) from TBLHuongDan ";
                SqlCommand cmd = new SqlCommand(sql, con);
                int kq=(int)cmd.ExecuteScalar();//trả về 1 số
                closeConnection();
                return kq;
            }
            catch
            {
                return -1;//lỗi
            }
        }
        #endregion

        #region 2.	In ra màn hình danh sách HoTen sinh viên
        public List<string> ShowHoTenSinhVien()
        {
            try
            {
                openConnection();
                List<string> listSinhVien = new List<string>();
                string sql = "select Hotensv from TBLSinhVien";
                SqlCommand cmd = new SqlCommand(sql, con);
                var reader  = cmd.ExecuteReader();//trả về 1 số
                while(reader.Read())
                {
                    listSinhVien.Add(reader["Hotensv"].ToString());
                }    
                closeConnection();
                return listSinhVien;
                
            }
            catch
            {
                return null;//lỗi
            }
        }
        #endregion

        #region 3.	Thêm một sinh viên tên: Trần Nam Dương/2018/Geo/1995/Ho Chi Minh
        public bool ThemSinhVien(int IDSinhVien,string Ten,string MaKhoa,int NamSinh,string QueQuan)
        {
            try
            {
                openConnection();
                string sql = "insert into TBLSinhVien values("+ IDSinhVien+",'"+Ten+"','"+MaKhoa+"',"+NamSinh+",'"+QueQuan+"')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();//Thực thi câu lệnh thêm xóa sửa
                closeConnection();
                return true;//thành công

            }
            catch
            {
                return false;//lỗi
            }
        }
        #endregion

        #region 4.	Cập nhật sinh viên Le Thi Van năm sinh 2018, Quê quán Ha nam
        public bool CapNhatSinhVien(string Ten, int NamSinh, string QueQuan)
        {
            try
            {
                openConnection();
                string sql = "update TBLSinhVien set Namsinh="+NamSinh+",Quequan='"+QueQuan+"' where Hotensv='"+Ten+"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();//Thực thi câu lệnh thêm xóa sửa
                closeConnection();
                return true;//thành công

            }
            catch
            {
                return false;//lỗi
            }
        }
        #endregion

        #region 5.	Xóa đề tài Dt04
        public bool XoaDeTai(string MaDeTai)
        {
            try
            {
                openConnection();
                string sql = "delete TBLDeTai where Madt='"+MaDeTai+"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();//Thực thi câu lệnh thêm xóa sửa
                closeConnection();
                return true;//thành công

            }
            catch
            {
                return false;//lỗi
            }
        }
        #endregion
    }
}
