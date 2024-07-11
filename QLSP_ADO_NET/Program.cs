using System;
using System.Text;
using System.Collections.Generic;

namespace QLSP_ADO_NET
{
    class Program
    {
        static void Main(string[] args)
        {
            IThemSuaXoa qlsp = new ThemSuaXoa();
            while (true)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("===== Menu Quản Lý Sản Phẩm =====");
                Console.WriteLine("1. Hiển thị danh sách sản phẩm");
                Console.WriteLine("2. Thêm sản phẩm mới");
                Console.WriteLine("3. Thêm thể loại mới");
                Console.WriteLine("4. Sửa thông tin sản phẩm");
                Console.WriteLine("5. Xoá sản phẩm");
                Console.WriteLine("6. Xuât file excel");
                Console.WriteLine("0. Thoát chương trình");
                Console.Write("Nhập lựa chọn của bạn: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập lại.");
                    continue;
                }

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Đã thoát chương trình.");
                        return;
                    case 1:
                        qlsp.ShowAllProducts();
                        break;
                    case 2:
                        qlsp.AddProduct();
                        break;
                    case 3:
                        qlsp.AddCategory();
                        break;
                    case 4:
                        qlsp.UpdateProduct();
                        break;
                    case 5:
                        qlsp.DeleteProduct();
                        break;
                    case 6:
                        Console.Write("Nhập đường dẫn và tên file Excel để lưu danh sách sản phẩm: ");
                        string filePath = Console.ReadLine();
                        ExportToExcel.ExportProductsToExcel(filePath);
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập lại.");
                        break;
                }
            }
        }

       
    }
}
