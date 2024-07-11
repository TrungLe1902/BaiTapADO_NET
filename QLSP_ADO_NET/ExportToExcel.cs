using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_ADO_NET
{
    public class ExportToExcel
    {
        public static void ExportProductsToExcel(string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Lấy danh sách sản phẩm từ cơ sở dữ liệu
            List<QLProducts> products = SQLDBHelper.GetQLSPMayTinhs();

            // Tạo một package Excel
            using (ExcelPackage package = new ExcelPackage())
            {
                // Tạo một worksheet mới
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Products");

                // Định dạng header
                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Category";
                worksheet.Cells[1, 3].Value = "Name";
                worksheet.Cells[1, 4].Value = "CPU";
                worksheet.Cells[1, 5].Value = "ScreenSize";
                worksheet.Cells[1, 6].Value = "RAM";
                worksheet.Cells[1, 7].Value = "Price";

                // Đổ dữ liệu vào từ danh sách sản phẩm
                for (int i = 0; i < products.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = products[i].ID;
                    worksheet.Cells[i + 2, 2].Value = products[i].CategoryId;
                    worksheet.Cells[i + 2, 3].Value = products[i].Name;
                    worksheet.Cells[i + 2, 4].Value = products[i].CPU;
                    worksheet.Cells[i + 2, 5].Value = products[i].ScreenSize;
                    worksheet.Cells[i + 2, 6].Value = products[i].RAM;
                    worksheet.Cells[i + 2, 7].Value = products[i].Price;
                }

                // Lưu file Excel
                FileInfo excelFile = new FileInfo(filePath);
                package.SaveAs(excelFile);
            }

            Console.WriteLine($"Đã xuất dữ liệu vào file Excel: {filePath}");
        }
    }
}
