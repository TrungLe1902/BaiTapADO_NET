using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_ADO_NET
{
    public class ThemSuaXoa : IThemSuaXoa
    {
        //Hiển thị sản phẩm
        public void ShowAllProducts()
        {
            var list = SQLDBHelper.GetQLSPMayTinhs();
            if (list.Count == 0)
            {
                Console.WriteLine("Không có dữ liệu nào trong danh sách.");
                return;
            }
            Console.WriteLine("| {0, -5} | {1, -10} | {2, -25} | {3, -10} | {4, -15} | {5, -10} | {6, -10} |",
                 "ID", "Category", "Name", "CPU", "ScreenSize", "RAM", "Price");
            Console.WriteLine("---------------------------------------------------------------------------------------------------");

            foreach (var item in list)
            {
                Console.WriteLine("| {0, -5} | {1, -10} | {2, -25} | {3, -10} | {4, -15} | {5, -10} | {6, -10} |",
                    item.ID, item.CategoryId, item.Name, item.CPU, item.ScreenSize, item.RAM, item.Price);
            }

            Console.WriteLine("---------------------------------------------------------------------------------------------------");
        }

        //Thêm sản phẩm
        public void AddProduct()
        {
            
            int newCategoryId = CheckValidate.ValidateIntInput("Nhập CategoryId: ");
            string newName = CheckValidate.ValidateStringInput("Nhập tên sản phẩm mới: ");
            string newCPU = CheckValidate.ValidateStringInput("Nhập CPU: ");
            string newScreenSize = CheckValidate.ValidateStringInput("Nhập kích thước màn hình: ");
            string newRAM = CheckValidate.ValidateStringInput("Nhập RAM: ");
            int newPrice = CheckValidate.ValidateIntInput("Nhập giá sản phẩm: ");

            QLProducts newProduct = new QLProducts
            {
             
                CategoryId = newCategoryId,
                Name = newName,
                CPU = newCPU,
                ScreenSize = newScreenSize,
                RAM = newRAM,
                Price = newPrice
            };
            SQLDBHelper.AddProduct(newProduct);
            Console.WriteLine("Đã thêm sản phẩm mới.");
        }

        public void AddCategory()
        {
            string newName = CheckValidate.ValidateStringInput("Nhập tên thể loại mới: ");

            QLCategory newCategory = new QLCategory
            {
                CategoryName = newName
            };
            SQLDBHelper.AddCategory(newCategory);
            Console.WriteLine("Đã thêm sản phẩm mới.");
        }

        //Sửa sản phẩm
        public void UpdateProduct()
        {
            int productIdToUpdate = CheckValidate.ValidateIntInput("Nhập ID sản phẩm cần sửa: ");

            List<QLProducts> products = SQLDBHelper.GetQLSPMayTinhs();
            QLProducts productToUpdate = products.Find(p => p.ID == productIdToUpdate);

            if (productToUpdate != null)
            {
                productToUpdate.Name = CheckValidate.ValidateStringInput("Nhập tên mới: ");
                productToUpdate.CPU = CheckValidate.ValidateStringInput("Nhập CPU mới: ");
                productToUpdate.ScreenSize = CheckValidate.ValidateStringInput("Nhập kích thước màn hình mới: ");
                productToUpdate.RAM = CheckValidate.ValidateStringInput("Nhập RAM mới: ");
                productToUpdate.Price = CheckValidate.ValidateIntInput("Nhập giá mới: ");

                SQLDBHelper.UpdateProduct(productToUpdate);
                Console.WriteLine("Đã cập nhật thông tin sản phẩm.");
            }
            else
            {
                Console.WriteLine("Không tìm thấy sản phẩm có ID này.");
            }
        }
        //Xoá sản phẩm
        public void DeleteProduct()
        {
            int productIdToDelete = CheckValidate.ValidateIntInput("Nhập ID sản phẩm cần xóa: ");
         /*   Console.Write("Nhập ID sản phẩm cần xóa: ");
            int productIdToDelete = int.Parse(Console.ReadLine());*/

            SQLDBHelper.DeleteProduct(productIdToDelete);
            Console.WriteLine("Đã xóa sản phẩm.");
        }

    }
}
