using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TT.THUCHANH4.DATA;
namespace TT.THUCHANH4.APP
{
    public class Program
    {
        static void Main(string[] args)
        {
            Class1 cl = new Class1();
            Console.WriteLine("nhap so de chuyen bai 1,2,3,4,5 và 0 là clear \n");
            int chon = Convert.ToInt32(Console.ReadLine());
            switch(chon)
            {
                case 1:
                    int SoSinhVienThucTap = cl.CountSoSinhVienThucTap();
                    Console.WriteLine("So sinh vien la: ==============" + SoSinhVienThucTap.ToString());
                    break;
                case 2:
                    List<string> lsHoTenSinhVien = cl.ShowHoTenSinhVien();
                    Console.WriteLine("Danh sach sinh vien");
                    for (int i=0;i<lsHoTenSinhVien.Count;i++)
                    {
                        Console.WriteLine(lsHoTenSinhVien[i]);
                    }
                    break;
                case 3:
                    //3.Thêm một sinh viên tên: Trần Nam Dương  / Geo / 1995 / Ho Chi Minh
                    if (cl.ThemSinhVien(9, "Trần Nam Dương", "Geo",1995, " Ho Chi Minh"))//thành công
                    {
                        Console.WriteLine(" Thêm thành công");
                    }  
                    else//thất Bại
                    {
                        Console.WriteLine("Thêm that bai kiem tra table TBLSinhVien co ton tai ma sinh vien khong");
                    }    
                    break;
                case 4:
                    //4.Cập nhật sinh viên Le Thi Van năm sinh 2018, Quê quán Ha nam
                    if (cl.CapNhatSinhVien("Le Thi Van", 2018, "Ha nam"))//thành công
                    {
                        Console.WriteLine("Cập nhật thành công");
                    }
                    else//thất Bại
                    {
                        Console.WriteLine("Cập nhật that bai kiem tra table TBLSinhVien");
                    }
                    break;
                case 5:
                    //5. Xóa đề tài Dt04
                    if (cl.XoaDeTai("Dt04"))//thành công
                    {
                        Console.WriteLine("Xóa thành công");
                    }
                    else//thất Bại
                    {
                        Console.WriteLine("Xóa that bai hay kiem tra table TBLHuongDan ");
                    }
                    break;
                default:
                    Console.Clear();
                    break;
            }
          Console.ReadKey();
        }
    }
}
