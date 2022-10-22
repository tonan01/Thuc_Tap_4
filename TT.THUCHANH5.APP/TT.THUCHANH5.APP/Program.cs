using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TT.THUCHANH5.APP;
using TT.THUCHANH5.DATA;

namespace TT.THUCHANH5.APP
{
    public class Program
    {
        static void Main(string[] args)
        {
            Class1 cl = new Class1();
            Console.WriteLine("Nhap so");
            int chon = Convert.ToInt32(Console.ReadLine());
            switch (chon)
            {
                case 1:
                    Console.WriteLine("Danh sach sinh vien thuc tap bang 0 ");
                    List<TBLSinhVien> lsSinhViensTT = cl.GetSinhVienDiemTTBangKhong();
                    for (int i = 0; i < lsSinhViensTT.Count; i++)
                    {
                        Console.WriteLine(lsSinhViensTT[i].Hotensv);
                    }
                    break;
                case 2:
                    Console.WriteLine("So luong sinh vien thuc tap: " + cl.CountSinhVienThucTap().ToString());
                    break;
                case 3:
                    Console.WriteLine("Danh sach hon va ten sinh vien ");
                    List<TBLSinhVien> lsSinhViens = cl.GetHoTenSinhVien();
                    for(int i=0;i<lsSinhViens.Count;i++)
                    {
                        Console.WriteLine(lsSinhViens[i].Hotensv);
                    }
                    break;
                case 4:
                    //Thêm một sinh viên tên: Ngô Nhật Long/2018/Bio/1993/Vung Tau 
                    if(cl.AddSinhVien(9, "Ngô Nhật Long", "Bio",1933,"Vung Tau"))
                    {
                        Console.WriteLine("Thanh cong");
                    }
                    else
                    {
                        Console.WriteLine("That bai");
                    }
                    break;
                case 5:
                    //Cập nhật sinh viên 'Tran Khac Trong' năm sinh 2018, Quê quán Ha nam
                    if (cl.UpdateSinhVien("Tran Khac Trong",1933, "Ha nam"))
                    {
                        Console.WriteLine("Thanh cong");
                    }
                    else
                    {
                        Console.WriteLine("That bai");
                    }
                    break;
                case 6:
                    //Xóa đề tài 'Dt03' 
                    if (cl.DeleteSinhVien("Dt03"))
                    {
                        Console.WriteLine("Thanh cong");
                    }
                    else
                    {
                        Console.WriteLine("That bai");
                    }
                    break;
                case 7:
                    cl.DemSoLuongSinhVienMoiDeTai();
                    break;
                default:
                    break;
            }
            Console.ReadKey();

        }
    }
}
