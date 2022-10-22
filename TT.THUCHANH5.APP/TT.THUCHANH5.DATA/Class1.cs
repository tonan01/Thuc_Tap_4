using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TT.THUCHANH5.DATA
{
    public class Class1
    {
        ThucTapEntities _thucTapEntities=new ThucTapEntities();
        #region 1.	Đưa ra danh sách gồm mã số, họ tên các sinh viên có điểm thực tập bằng 0 
        public List<TBLSinhVien> GetSinhVienDiemTTBangKhong()
        {
            var dsSinhVienTTBangKhong = (from sv in _thucTapEntities.TBLSinhViens
                                         join hd in _thucTapEntities.TBLHuongDans on sv.Masv equals hd.Masv
                                         where hd.KetQua==0 && hd.KetQua!=null select sv).ToList();
            return dsSinhVienTTBangKhong;
        }
        #endregion

        #region 2.	Đếm số lượng sinh viên thực thập
        public int CountSinhVienThucTap()
        {
            int SoLuong = _thucTapEntities.TBLHuongDans.Count();
            return SoLuong;
        }
        #endregion

        #region 3.	In ra màn hình danh sách HoTen sinh viên
        public List<TBLSinhVien> GetHoTenSinhVien()
        {
            var dSHoTen=_thucTapEntities.TBLSinhViens.ToList();
            return dSHoTen;
        }
        #endregion

        #region 4.	Thêm một sinh viên tên: Ngô Nhật Long/2018/Bio/1993/Vung Tau 
        public bool AddSinhVien(int MaSinhVien,string Ten,string MaKhoa,int NamSinh,string QueQuan)
        {
            try
            {
                TBLSinhVien sv = new TBLSinhVien();
                sv.Masv = MaSinhVien;
                sv.Hotensv = Ten;
                sv.Makhoa = MaKhoa;
                sv.Namsinh = NamSinh;
                sv.Quequan = QueQuan;
                _thucTapEntities.TBLSinhViens.Add(sv);
                _thucTapEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 5.	Cập nhật sinh viên 'Tran Khac Trong' năm sinh 2018, Quê quán Ha nam
        public bool UpdateSinhVien( string Ten, int NamSinh, string QueQuan)
        {
            try
            {
                TBLSinhVien sv = _thucTapEntities.TBLSinhViens.Single(s => s.Hotensv == Ten);
                sv.Namsinh = NamSinh;
                sv.Quequan = QueQuan;
                _thucTapEntities.TBLSinhViens.AddOrUpdate(sv);
                _thucTapEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 6.	Xóa đề tài 'Dt03' 
        public bool DeleteSinhVien(string MaDeTai)
        {
            try
            {
                TBLDeTai sv = _thucTapEntities.TBLDeTais.Single(s => s.Madt == MaDeTai);
                _thucTapEntities.TBLDeTais.Remove(sv);
                _thucTapEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 7.	Đếm số lượng sinh viên của mỗi đề tài
        public void DemSoLuongSinhVienMoiDeTai()
        {
            var dsSoLuongSVMoiDeTai = (from dt in _thucTapEntities.TBLDeTais
                                       join hd in _thucTapEntities.TBLHuongDans on dt.Madt equals hd.Madt
                                       join sv in _thucTapEntities.TBLSinhViens on hd.Masv equals sv.Masv
                                       group dt by dt.Madt into g
                                       select new { MaDT=g.Key, count=g.Count() }).ToList();
            foreach(var ds in dsSoLuongSVMoiDeTai)
            {
                Console.WriteLine("Ma de tai :"+ ds.MaDT + " :So luong sinh vien: " + ds.count);
            }    
        }
        
        #endregion
    }
}
